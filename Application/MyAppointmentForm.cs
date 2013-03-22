using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;

namespace WorkStation
{
    public partial class MyAppointmentForm : DevExpress.XtraScheduler.UI.AppointmentForm
    {
        public MyAppointmentForm(SchedulerControl control, Appointment apt) : base(control, apt) { }

        protected override void UpdateForm()
        {
            InitializeComponent();
            base.UpdateForm();
        }

        protected override AppointmentFormController CreateController(SchedulerControl control, Appointment apt)
        {
            return new MyAppointmentFormController(control, apt);
        }

        protected override void UpdateCustomFieldsControls()
        {
            this.tbPost.Text = ((MyAppointmentFormController)base.Controller).Post;
            base.UpdateCustomFieldsControls();
        }

        private void tbPost_EditValueChanged(object sender, EventArgs e)
        {
            ((MyAppointmentFormController)base.Controller).Post = tbPost.Text.Trim();
        }
    }

    class MyAppointmentFormController : AppointmentFormController
    {
        public MyAppointmentFormController(SchedulerControl control, Appointment apt) : base(control, apt) { }

        public string Post
        {
            get
            {
                if(base.EditedAppointmentCopy.CustomFields["Post"]!=DBNull.Value)
                  return base.EditedAppointmentCopy.CustomFields["Post"].ToString();
                return "";
            }
            set
            {
                base.EditedAppointmentCopy.CustomFields["Post"] = value;
            }
        }
        public string SourcePost
        {
            get
            {
                return base.SourceAppointment.CustomFields["Post"].ToString();
            }
            set
            {
                base.SourceAppointment.CustomFields["Post"] = value;
            }
        }

        public override bool IsAppointmentChanged()
        {
            if (base.IsAppointmentChanged())  return true;
            return SourcePost == Post;
        }

        protected override void ApplyCustomFieldsValues()
        {
            base.SourceAppointment.CustomFields["Post"] = Post;
            base.ApplyCustomFieldsValues();
        }
    }
}
