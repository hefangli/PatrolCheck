using DevExpress.XtraScheduler;
namespace WorkStation
{
    partial class SchedulerTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler4 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tbDayCount = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDayCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.AppointmentInserting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage1_AppointmentInserting);
            this.schedulerStorage1.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsChanged);
            this.schedulerStorage1.AppointmentDeleting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage1_AppointmentDeleting);
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.Location = new System.Drawing.Point(12, 55);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(687, 440);
            this.schedulerControl1.Start = new System.DateTime(2013, 3, 8, 0, 0, 0, 0);
            this.schedulerControl1.Storage = this.schedulerStorage1;
            this.schedulerControl1.TabIndex = 2;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.DayCount = 2;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler3);
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler4);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "显示天数：";
            // 
            // tbDayCount
            // 
            this.tbDayCount.EditValue = "2";
            this.tbDayCount.Location = new System.Drawing.Point(91, 19);
            this.tbDayCount.Name = "tbDayCount";
            this.tbDayCount.Properties.Mask.EditMask = "d";
            this.tbDayCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbDayCount.Size = new System.Drawing.Size(74, 21);
            this.tbDayCount.TabIndex = 4;
            this.tbDayCount.EditValueChanged += new System.EventHandler(this.tbDayCount_EditValueChanged);
            // 
            // SchedulerTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 507);
            this.Controls.Add(this.tbDayCount);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.schedulerControl1);
            this.Name = "SchedulerTest";
            this.Text = "SchedulerTest";
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDayCount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private SchedulerControl schedulerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit tbDayCount;
    }
}