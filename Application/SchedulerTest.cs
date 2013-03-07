using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace WorkStation
{
    public partial class SchedulerTest : Form
    {
        public SchedulerTest()
        {
            InitializeComponent();
            //CheckPlanScheduleDataSource da = new CheckPlanScheduleDataSource(SqlHelper.ExecuteDataset("Select * from CheckPlan").Tables[0],DateTime.Parse("2013-1-1 12:30"));
            //this.schedulerStorage1.Appointments.AddRange(da.ConvertAppointment(5));
        }
    }
    /// <summary> 
    /// 自定义基类(数据展示基类) 
    /// </summary> 
    public class ScheduleItemBase : Appointment
    {
        protected DataRow _DataRow;
        protected int _ValidState;
        protected int _ID;

        public ScheduleItemBase() { }
        public ScheduleItemBase(DataRow row)
        {
            _DataRow = row;
            this.ConvertToAppointment(row);
        }

        public DataRow DataRow { get { return _DataRow; } }
        public int StateValue { get { return _ValidState; } }
        private string _ToolTip = "";

        /// <summary> 
        /// DataRow结构转换为Appointment对象 
        /// </summary> 
        /// <param name="row"></param> 
        public virtual void ConvertToAppointment(DataRow row)
        {
            _ValidState = Convert.ToInt32(row["ValidState"]);
            _ID = Convert.ToInt32(row["ID"]);

            this.Start = DateTime.Parse(row["StartTime"].ToString()); //用转换后的时间作为Start属性的值
            this.End = DateTime.Parse(row["EndTime"].ToString());
            this.Subject = Convert.ToString(row["Name"]);
            //this.Location = Convert.ToString(row[1]);
            //this.LabelId = Convert.ToInt32(row[1]);
            //this.StatusId = Convert.ToInt32(row[1]);

            //建议DataTable返回Description字段 
            //this.Description = Convert.ToString(row[TScheduleData.Subject]); 
        }

        public string ToolTip
        {
            get
            {
                if (_ToolTip == "") _ToolTip = this.GetToolTip();
                return _ToolTip;
            }
        }

        /// <summary> 
        /// 返回提示消息 
        /// </summary> 
        protected virtual string GetToolTip() { return "提示消息"; }
    }

    /// <summary> 
    /// CheckPlan数据单
    /// </summary> 
    public class CheckPlanAppointment : ScheduleItemBase
    {
        public CheckPlanAppointment() { }
        public CheckPlanAppointment(DataRow row) : base(row) { }

        /// <summary> 
        /// 返回提示消息 
        /// </summary> 
        protected override string GetToolTip()
        {
            string html = "单号:{0}</br>日期:{1}</br>进度:{2}";
            DateTime docDate = DateTime.Parse(_DataRow["StartTime"].ToString());
            string Location = "进——度";
            html = string.Format(html, _ID, docDate, Location);
            return html;
        }

        /// <summary> 
        /// 如有特殊字段，重写该方法转换Appointment对象 
        /// </summary> 
        /// <param name="row"></param> 
        public override void ConvertToAppointment(DataRow row)
        {
            base.ConvertToAppointment(row);
        }
    }

    /// <summary>
    /// 数据源接口
    /// </summary>
    public interface IScheduleDataSource
    {
        /// <summary>
        /// 数据表，原始数据
        /// </summary>
        DataTable DataSource { get; }

        /// <summary>
        /// 开始日期
        /// </summary>
        DateTime StartDate { get; }

        /// <summary>
        /// 将数据表转换成Appointment数组
        /// </summary>
        /// <param name="dayCount">只显示指定天数的数据</param>
        /// <returns></returns>
        Appointment[] ConvertAppointment(int dayCount);

        /// <summary>
        /// 跟据日期创建数据源
        /// </summary>
        IScheduleDataSource CreateDataSource(DateTime fromTime, DateTime toTime);
    }

    /// <summary> 
    /// 数据源基类,实现IScheduleDataSource接口 
    /// </summary> 
    public class ScheduleDataSourceBase : IScheduleDataSource
    {
        protected DataTable _DataSource;
        protected DateTime _StartDate;

        public ScheduleDataSourceBase(DataTable source, DateTime startDate)
        {
            _DataSource = source;
            _StartDate = startDate;
        }

        public virtual Appointment[] ConvertAppointment(int dayCount) { return null; }

        public DataTable DataSource { get { return _DataSource; } }
        public DateTime StartDate { get { return _StartDate; } }

        protected bool _IsGenerateFitField = false;

        /// <summary> 
        /// 生成Schedule控件的TimeRuler时间分隔数据 
        /// </summary> 
        /// <param name="interval">分钟数：5,10,15</param> 
        public void FitStartDate(int interval)
        {
            if (_IsGenerateFitField) return;


            _DataSource.Columns.Add("IntervalField", typeof(DateTime));

            DateTime begin = new DateTime(_StartDate.Year, _StartDate.Month, _StartDate.Day);
            DateTime temp = DateTime.MinValue;
            DateTime last = DateTime.MinValue;
            DateTime increase = DateTime.MinValue;

            foreach (DataRow row in _DataSource.Rows)
            {
                //取单据的开始时间 
                temp = DateTime.Parse(row["StartTime"].ToString());

                if (last != temp)
                {
                    increase = temp;
                    last = temp;
                }

                row["IntervalField"] = increase;
                increase = increase.AddMinutes(interval);
            }
            _DataSource.AcceptChanges();
            _IsGenerateFitField = true;
        }

        public virtual IScheduleDataSource CreateDataSource(DateTime fromTime, DateTime toTime) { return null; }
    }

    /// <summary>
    /// 数据源
    /// </summary>
    public class CheckPlanScheduleDataSource : ScheduleDataSourceBase
    {
        public CheckPlanScheduleDataSource(DataTable source, DateTime startDate) : base(source, startDate) { }

        public override Appointment[] ConvertAppointment(int dayCount)
        {
            Exception.Equals(_DataSource, null);
            //gai this.FitStartDate(15);//每15分钟时间线生成一条记录 
            //转换数据.DataTable -> Appointment[] 
            Appointment[] aps = new CheckPlanAppointment[_DataSource.Rows.Count];
            for (int i = 0; i <= _DataSource.Rows.Count - 1; i++)
                aps[i] = new CheckPlanAppointment(_DataSource.Rows[i]);

            return aps;
        }

        public override IScheduleDataSource CreateDataSource(DateTime fromTime, DateTime toTime)
        {
            DataTable dt = SqlHelper.ExecuteDataset("Select * from CheckPlan").Tables[0];
            DateTime start = DateTime.Parse(dt.Rows[0]["StartTime"].ToString());
            IScheduleDataSource source = new CheckPlanScheduleDataSource(dt, start);
            return source;
        }
    }

  
}
