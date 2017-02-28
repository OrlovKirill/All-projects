namespace Fathers_Work
    {
    partial class Form1
        {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose (bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent ()
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.WEEKEND = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.PLAN_THIS_MONTH = new System.Windows.Forms.Button();
            this.SHIFT_DATE = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WEEKEND
            // 
            this.WEEKEND.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.WEEKEND, "WEEKEND");
            this.WEEKEND.ForeColor = System.Drawing.Color.White;
            this.WEEKEND.Name = "WEEKEND";
            this.WEEKEND.UseMnemonic = false;
            this.WEEKEND.UseVisualStyleBackColor = false;
            this.WEEKEND.Click += new System.EventHandler(this.WEEKEND_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Name = "listBox1";
            // 
            // PLAN_THIS_MONTH
            // 
            resources.ApplyResources(this.PLAN_THIS_MONTH, "PLAN_THIS_MONTH");
            this.PLAN_THIS_MONTH.ForeColor = System.Drawing.Color.White;
            this.PLAN_THIS_MONTH.Name = "PLAN_THIS_MONTH";
            this.PLAN_THIS_MONTH.UseVisualStyleBackColor = true;
            this.PLAN_THIS_MONTH.Click += new System.EventHandler(this.PLAN_THIS_MONTH_Click);
            // 
            // SHIFT_DATE
            // 
            this.SHIFT_DATE.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.SHIFT_DATE, "SHIFT_DATE");
            this.SHIFT_DATE.ForeColor = System.Drawing.Color.White;
            this.SHIFT_DATE.Name = "SHIFT_DATE";
            this.SHIFT_DATE.UseVisualStyleBackColor = false;
            this.SHIFT_DATE.Click += new System.EventHandler(this.SHIFT_DATE_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Name = "dateTimePicker1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Name = "label1";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.SHIFT_DATE);
            this.Controls.Add(this.PLAN_THIS_MONTH);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.WEEKEND);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Button WEEKEND;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button PLAN_THIS_MONTH;
        private System.Windows.Forms.Button SHIFT_DATE;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        }
    }

