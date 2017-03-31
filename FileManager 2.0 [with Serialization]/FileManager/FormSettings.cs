using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
    {
    public partial class FormSettings: Form
        {

        Settings settings;

        public FormSettings ()
            {
            InitializeComponent();
            settings = new Settings();
            settings = Settings.GetSettings();
            textBoxLogin.Text = settings.login;
            for (int i = 0 ; i < settings.password.Length ; i++)
                textBoxPassword.Text += "*";
            }

        private void buttonCMainWin_Click (object sender , EventArgs e)
            {
            if (colorDialog1.ShowDialog()== DialogResult.OK)
            settings.cMainWin = colorDialog1.Color;
            }

        private void buttonCExpl_Click (object sender , EventArgs e)
            {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                settings.cExpl = colorDialog1.Color;
            }

        private void buttonCStrPath_Click (object sender , EventArgs e)
            {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                settings.cStrPath = colorDialog1.Color;
            }

        private void buttonCButtons_Click (object sender , EventArgs e)
            {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                settings.cButns = colorDialog1.Color;
            }

        private void buttonFExpl_Click (object sender , EventArgs e)
            {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                settings.fExpl = fontDialog1.Font;
            }

        private void buttonFStrPath_Click (object sender , EventArgs e)
            {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                settings.fStrPath = fontDialog1.Font;
            }

        private void buttonFButns_Click (object sender , EventArgs e)
            {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                settings.fButns = fontDialog1.Font;
            }

        private void buttonFCExpl_Click (object sender , EventArgs e)
            {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                settings.fcExpl = colorDialog1.Color;
            }

        private void buttonFCStrPath_Click (object sender , EventArgs e)
            {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                settings.fcStrPath = colorDialog1.Color;
            }

        private void buttonFCButns_Click (object sender , EventArgs e)
            {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                settings.fcButns = colorDialog1.Color;
            }

        private void buttonSave_Click (object sender , EventArgs e)
            {
            settings.login = textBoxLogin.Text;
            settings.password = textBoxPassword.Text;
            FormGeneral.isDefault = checkBoxDefault.Checked;
            this.Visible = false;
            settings.Save();
            FormGeneral.fGen.RedrawForm();
            }

        private void buttonCancel_Click (object sender , EventArgs e)
            {
            this.Visible = false;
            }

        private void checkBoxDefault_CheckedChanged (object sender , EventArgs e)
            {
            if (checkBoxDefault.Checked)
                {
                textBoxLogin.Clear();
                textBoxPassword.Clear();
                }
            panel1.Enabled = !checkBoxDefault.Checked;
            }
        }
    }
