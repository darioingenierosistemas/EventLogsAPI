namespace FormEventLog.Views
{
    partial class FormNewEvent
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
            this.cbxEventType = new System.Windows.Forms.ComboBox();
            this.txbDescription = new System.Windows.Forms.TextBox();
            this.dateTimeEventDate = new System.Windows.Forms.DateTimePicker();
            this.btnSaveEventLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxEventType
            // 
            this.cbxEventType.FormattingEnabled = true;
            this.cbxEventType.Items.AddRange(new object[] {
            "API",
            "MANUAL"});
            this.cbxEventType.Location = new System.Drawing.Point(12, 88);
            this.cbxEventType.Name = "cbxEventType";
            this.cbxEventType.Size = new System.Drawing.Size(121, 21);
            this.cbxEventType.TabIndex = 0;
            this.cbxEventType.SelectedIndexChanged += new System.EventHandler(this.cbxEventType_SelectedIndexChanged);
            // 
            // txbDescription
            // 
            this.txbDescription.Location = new System.Drawing.Point(12, 62);
            this.txbDescription.Name = "txbDescription";
            this.txbDescription.Size = new System.Drawing.Size(200, 20);
            this.txbDescription.TabIndex = 1;
            // 
            // dateTimeEventDate
            // 
            this.dateTimeEventDate.Location = new System.Drawing.Point(12, 36);
            this.dateTimeEventDate.Name = "dateTimeEventDate";
            this.dateTimeEventDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimeEventDate.TabIndex = 2;
            this.dateTimeEventDate.ValueChanged += new System.EventHandler(this.dateTimeEventDate_ValueChanged);
            // 
            // btnSaveEventLog
            // 
            this.btnSaveEventLog.Location = new System.Drawing.Point(12, 132);
            this.btnSaveEventLog.Name = "btnSaveEventLog";
            this.btnSaveEventLog.Size = new System.Drawing.Size(200, 23);
            this.btnSaveEventLog.TabIndex = 3;
            this.btnSaveEventLog.Text = "Guardar";
            this.btnSaveEventLog.UseVisualStyleBackColor = true;
            this.btnSaveEventLog.Click += new System.EventHandler(this.btnSaveEventLog_Click);
            // 
            // FormNewEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 210);
            this.Controls.Add(this.btnSaveEventLog);
            this.Controls.Add(this.dateTimeEventDate);
            this.Controls.Add(this.txbDescription);
            this.Controls.Add(this.cbxEventType);
            this.Name = "FormNewEvent";
            this.Text = "FormNewEvent";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormNewEvent_FormClosed);
            this.Load += new System.EventHandler(this.FormNewEvent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxEventType;
        private System.Windows.Forms.TextBox txbDescription;
        private System.Windows.Forms.DateTimePicker dateTimeEventDate;
        private System.Windows.Forms.Button btnSaveEventLog;
    }
}