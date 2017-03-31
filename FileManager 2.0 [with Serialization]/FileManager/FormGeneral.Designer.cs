namespace FileManager
    {
    partial class FormGeneral
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonExtract = new System.Windows.Forms.Button();
            this.buttonArchive = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonCut = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.ListDirectory = new System.Windows.Forms.ListBox();
            this.textBoxRename = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSettings);
            this.panel1.Controls.Add(this.buttonExtract);
            this.panel1.Controls.Add(this.buttonArchive);
            this.panel1.Controls.Add(this.buttonRename);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonInsert);
            this.panel1.Controls.Add(this.buttonCut);
            this.panel1.Controls.Add(this.buttonCopy);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 101);
            this.panel1.TabIndex = 0;
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonSettings.FlatAppearance.BorderSize = 3;
            this.buttonSettings.Font = new System.Drawing.Font("SimSun", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter, ((byte)(204)));
            this.buttonSettings.ForeColor = System.Drawing.Color.Black;
            this.buttonSettings.Location = new System.Drawing.Point(978, 3);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(193, 95);
            this.buttonSettings.TabIndex = 8;
            this.buttonSettings.Text = "SETTINGS";
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonExtract
            // 
            this.buttonExtract.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonExtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExtract.ForeColor = System.Drawing.Color.ForestGreen;
            this.buttonExtract.Location = new System.Drawing.Point(409, 52);
            this.buttonExtract.Name = "buttonExtract";
            this.buttonExtract.Size = new System.Drawing.Size(158, 46);
            this.buttonExtract.TabIndex = 7;
            this.buttonExtract.Text = "EXTRACT";
            this.buttonExtract.UseVisualStyleBackColor = false;
            this.buttonExtract.Click += new System.EventHandler(this.buttonExtract_Click);
            // 
            // buttonArchive
            // 
            this.buttonArchive.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonArchive.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonArchive.Location = new System.Drawing.Point(409, 3);
            this.buttonArchive.Name = "buttonArchive";
            this.buttonArchive.Size = new System.Drawing.Size(158, 46);
            this.buttonArchive.TabIndex = 6;
            this.buttonArchive.Text = "ARCHIVE";
            this.buttonArchive.UseVisualStyleBackColor = false;
            this.buttonArchive.Click += new System.EventHandler(this.buttonArchive_Click);
            // 
            // buttonRename
            // 
            this.buttonRename.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRename.ForeColor = System.Drawing.Color.DarkCyan;
            this.buttonRename.Location = new System.Drawing.Point(598, 3);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(153, 95);
            this.buttonRename.TabIndex = 5;
            this.buttonRename.Text = "RENAME";
            this.buttonRename.UseVisualStyleBackColor = false;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.ForeColor = System.Drawing.Color.Crimson;
            this.buttonDelete.Location = new System.Drawing.Point(788, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(153, 95);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "DELETE";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonInsert.ForeColor = System.Drawing.Color.Blue;
            this.buttonInsert.Location = new System.Drawing.Point(264, 3);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonInsert.Size = new System.Drawing.Size(122, 95);
            this.buttonInsert.TabIndex = 3;
            this.buttonInsert.Text = "INSERT";
            this.buttonInsert.UseVisualStyleBackColor = false;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonCut
            // 
            this.buttonCut.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCut.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCut.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonCut.Location = new System.Drawing.Point(136, 52);
            this.buttonCut.Name = "buttonCut";
            this.buttonCut.Size = new System.Drawing.Size(122, 46);
            this.buttonCut.TabIndex = 2;
            this.buttonCut.Text = "CUT";
            this.buttonCut.UseVisualStyleBackColor = false;
            this.buttonCut.Click += new System.EventHandler(this.buttonCut_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCopy.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonCopy.Location = new System.Drawing.Point(136, 3);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(122, 46);
            this.buttonCopy.TabIndex = 1;
            this.buttonCopy.Text = "COPY";
            this.buttonCopy.UseVisualStyleBackColor = false;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonBack.FlatAppearance.BorderSize = 3;
            this.buttonBack.Font = new System.Drawing.Font("MS PGothic", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter, ((byte)(204)));
            this.buttonBack.ForeColor = System.Drawing.Color.Black;
            this.buttonBack.Location = new System.Drawing.Point(3, 3);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(110, 95);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "BACK";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelPath
            // 
            this.labelPath.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPath.ForeColor = System.Drawing.Color.Indigo;
            this.labelPath.Location = new System.Drawing.Point(12, 116);
            this.labelPath.Margin = new System.Windows.Forms.Padding(0);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(1174, 41);
            this.labelPath.TabIndex = 1;
            this.labelPath.Text = "PATH";
            // 
            // ListDirectory
            // 
            this.ListDirectory.BackColor = System.Drawing.Color.Black;
            this.ListDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListDirectory.ForeColor = System.Drawing.Color.Yellow;
            this.ListDirectory.FormattingEnabled = true;
            this.ListDirectory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ListDirectory.ItemHeight = 29;
            this.ListDirectory.Location = new System.Drawing.Point(12, 157);
            this.ListDirectory.Margin = new System.Windows.Forms.Padding(0);
            this.ListDirectory.Name = "ListDirectory";
            this.ListDirectory.Size = new System.Drawing.Size(1174, 553);
            this.ListDirectory.TabIndex = 2;
            this.ListDirectory.DoubleClick += new System.EventHandler(this.ListDirectory_DoubleClick);
            // 
            // textBoxRename
            // 
            this.textBoxRename.Location = new System.Drawing.Point(12, 716);
            this.textBoxRename.Name = "textBoxRename";
            this.textBoxRename.Size = new System.Drawing.Size(1174, 22);
            this.textBoxRename.TabIndex = 3;
            this.textBoxRename.Visible = false;
            this.textBoxRename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1Rename_KeyPress);
            // 
            // FormGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1197, 746);
            this.Controls.Add(this.textBoxRename);
            this.Controls.Add(this.ListDirectory);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGeneral";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Manager";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonCut;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.TextBox textBoxRename;
        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.Button buttonArchive;
        private System.Windows.Forms.Button buttonSettings;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label labelPath;
        public System.Windows.Forms.ListBox ListDirectory;
        public System.Windows.Forms.Button buttonBack;
        }
    }

