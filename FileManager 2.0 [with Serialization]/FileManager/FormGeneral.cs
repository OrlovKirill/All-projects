using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace FileManager
    {
    public partial class FormGeneral: Form
        {
        public static FormGeneral fGen;
        public static bool isDefault = true;
        public static string settingsPath = "settings.xml";
        public static string defaultSettingsPath = "defaultSettings.xml";

        List<DirectoryInfo> currentListOfDirectories;
        List<FileInfo> currentListOfFiles;
        DirectoryInfo currentDirectory;
        string source;
        bool isCut;
        FileSystemWatcher watcher;
        FormSettings formSettings;
        Settings settings;
        Settings defSettings;
        
        public FormGeneral ()
            {
            InitializeComponent();
            fGen = this;
            
            currentListOfDirectories = new List<DirectoryInfo>();
            currentListOfFiles = new List<FileInfo>();
            watcher = new FileSystemWatcher();
            watcher.Changed += RefreshList;
            watcher.Created += RefreshList;
            watcher.Deleted += RefreshList;
            watcher.Renamed += RefreshList;
            formSettings = new FormSettings();
            formSettings.Show();
            formSettings.Visible = false;
            //Settings.SetDefaultSettings();
            //Settings.GetSettings();
            RedrawForm();
            Start();
            }

        private void Start ()
            {
            currentListOfDirectories.Clear();
            currentListOfFiles.Clear();
            ListDirectory.Items.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                ListDirectory.Items.Add(String.Format("[{0}]" , drive.Name.Remove(1 , 2)));
                currentListOfDirectories.Add(drive.RootDirectory);
                }
            watcher.Path = DriveInfo.GetDrives()[0].ToString();

            currentDirectory = null;
            labelPath.Text = null;
            }

        public void RedrawForm ()
            {
            settings = Settings.GetSettings();
            isDefault = true;
            defSettings = Settings.GetSettings();
            isDefault = false;
            try
                {

                

                this.BackColor = (settings.cMainWin.Name == "0") ? defSettings.cMainWin : settings.cMainWin;

                ListDirectory.BackColor = (settings.cExpl.Name == "0") ? defSettings.cExpl : settings.cExpl;
                ListDirectory.Font = settings.fExpl;
                ListDirectory.ForeColor = (settings.fcExpl.Name == "0") ? defSettings.fcExpl : settings.fcExpl;

                labelPath.BackColor = (settings.cStrPath.Name == "0") ? defSettings.cStrPath : settings.cStrPath;
                labelPath.Font = settings.fStrPath;
                labelPath.ForeColor = (settings.fcStrPath.Name == "0") ? defSettings.fcStrPath : settings.fcStrPath;


                foreach (Button button in panel1.Controls)
                    {
                    button.BackColor = settings.cButns;
                    button.Font = settings.fButns;
                    button.ForeColor = settings.fcButns;
                    }
                }
            catch { }
            this.Update();
            this.TopMost = true;
            }

        private void ListDirectory_DoubleClick (object sender , EventArgs e)
            {
            try
                {
                currentDirectory = currentListOfDirectories[ListDirectory.SelectedIndex];
                currentListOfDirectories.Clear();
                currentListOfFiles.Clear();
                ListDirectory.Items.Clear();

                foreach (DirectoryInfo curDir in currentDirectory.GetDirectories())
                    {
                    ListDirectory.Items.Add(String.Format("{0}" , curDir.Name));
                    currentListOfDirectories.Add(curDir);
                    }
                foreach (FileInfo curFile in currentDirectory.GetFiles())
                    {
                    ListDirectory.Items.Add(String.Format("{0}" , curFile.Name));
                    currentListOfFiles.Add(curFile);
                    }

                watcher.Path = labelPath.Text = currentDirectory.FullName;
                watcher.EnableRaisingEvents = true;
                }
            catch
                {
                if (ListDirectory.SelectedItem != null && File.Exists(Path.Combine(currentDirectory.FullName , ListDirectory.SelectedItem.ToString())))
                    Process.Start(Path.Combine(currentDirectory.FullName , ListDirectory.SelectedItem.ToString()));
                else
                    {
                    MessageBox.Show("                                 Error!\n\nYou will be returned to the root directory.");
                    Start();
                    }
                }

            }

        private void buttonBack_Click (object sender , EventArgs e)
            {
            
            if (currentDirectory.Parent == null)
                Start();
            else
                {
                currentDirectory = currentDirectory.Parent;
                currentListOfDirectories.Clear();
                currentListOfFiles.Clear();
                ListDirectory.Items.Clear();
                foreach (DirectoryInfo curDir in currentDirectory.GetDirectories())
                    {
                    ListDirectory.Items.Add(String.Format("{0}" , curDir.Name));
                    currentListOfDirectories.Add(curDir);
                    }
                foreach (FileInfo curFile in currentDirectory.GetFiles())
                    {
                    ListDirectory.Items.Add(String.Format("{0}" , curFile.Name));
                    currentListOfFiles.Add(curFile);
                    }
                watcher.Path = labelPath.Text = currentDirectory.FullName;
                }
            
            }

        private void buttonDelete_Click (object sender , EventArgs e)
            {
            if (ListDirectory.SelectedItem == null || currentDirectory == null)
                MessageBox.Show("Select the directory or file to delete.");
            else
                {
                int selectedIndex = ListDirectory.SelectedIndex;
                if (File.Exists(Path.Combine(currentDirectory.FullName , ListDirectory.Items[selectedIndex].ToString())))
                    {
                    if (MessageBox.Show("Are you sure you want to delete this file?" , "CONFRIMATION" , MessageBoxButtons.YesNo , MessageBoxIcon.Warning) == DialogResult.Yes)
                        File.Delete(Path.Combine(currentDirectory.FullName , ListDirectory.Items[selectedIndex].ToString()));
                    }
                else
                    {
                    if (Directory.GetFileSystemEntries(Path.Combine(currentDirectory.FullName , ListDirectory.Items[selectedIndex].ToString())).Length == 0)
                        {
                        if (MessageBox.Show("Are you sure you want to delete this empty folder?" , "CONFRIMATION" , MessageBoxButtons.YesNo , MessageBoxIcon.Warning) == DialogResult.Yes)
                            Directory.Delete(Path.Combine(currentDirectory.FullName , ListDirectory.Items[selectedIndex].ToString()));
                        }
                    else
                        if (MessageBox.Show("Are you sure you want to delete this folder and all its contents?" , "CONFRIMATION" , MessageBoxButtons.YesNo , MessageBoxIcon.Warning) == DialogResult.Yes)
                        Directory.Delete(Path.Combine(currentDirectory.FullName , ListDirectory.Items[selectedIndex].ToString()) , true);
                    }
                }
            }

        private void RefreshList (object sender , FileSystemEventArgs e)
            {
                currentListOfDirectories.Clear();
                currentListOfFiles.Clear();
            this.Invoke((MethodInvoker)delegate
                { ListDirectory.Items.Clear(); });
            

                foreach (DirectoryInfo curDir in currentDirectory.GetDirectories())
                    {
                this.Invoke((MethodInvoker)delegate
                    { ListDirectory.Items.Add(String.Format("{0}" , curDir.Name));});
                
                    currentListOfDirectories.Add(curDir);
                    }
                foreach (FileInfo curFile in currentDirectory.GetFiles())
                    {
                this.Invoke((MethodInvoker)delegate
                    { ListDirectory.Items.Add(String.Format("{0}" , curFile.Name)); });
                    currentListOfFiles.Add(curFile);
                    }

                labelPath.Text = currentDirectory.FullName;
            }

        private void buttonRename_Click (object sender , EventArgs e)
            {
            if (ListDirectory.SelectedItem == null || currentDirectory == null)
                MessageBox.Show("Select the directory or file to rename.");
            else
                {
                textBoxRename.Visible = true;
                textBoxRename.Text = ListDirectory.SelectedItem.ToString();
                ListDirectory.Enabled = panel1.Enabled = false;
                }
            }

        private void textBox1Rename_KeyPress (object sender , KeyPressEventArgs e)
            {
            if (e.KeyChar == (char)Keys.Enter)
                {
                textBoxRename.Visible = false;
                ListDirectory.Enabled = panel1.Enabled = true;
                if (File.Exists(Path.Combine(currentDirectory.FullName ,ListDirectory.SelectedItem.ToString())))
                    {
                    FileInfo file = new FileInfo(Path.Combine(currentDirectory.FullName ,ListDirectory.SelectedItem.ToString()));
                    if (file.FullName != Path.Combine(file.DirectoryName , textBoxRename.Text , file.Extension))
                        File.Move(file.FullName , Path.Combine(file.DirectoryName,textBoxRename.Text));
                    }
                else
                    {
                    DirectoryInfo dir = new DirectoryInfo(Path.Combine(currentDirectory.FullName , ListDirectory.SelectedItem.ToString()));
                    if (dir.FullName != Path.Combine(dir.Parent.FullName , textBoxRename.Text))
                    Directory.Move(dir.FullName , Path.Combine(dir.Parent.FullName , textBoxRename.Text));
                    }
                textBoxRename.Clear();
                }
            }

        private void buttonCut_Click (object sender , EventArgs e)
            {
            if (ListDirectory.SelectedItem == null || currentDirectory == null)
                MessageBox.Show("Select the directory or file to cut.");
            else
                {
                source = Path.Combine(currentDirectory.FullName,ListDirectory.SelectedItem.ToString());
                isCut = true;
                }
            }

        private void buttonCopy_Click (object sender , EventArgs e)
            {
            if (ListDirectory.SelectedItem == null || currentDirectory == null)
                MessageBox.Show("Select the directory or file to copy.");
            else
                {
                source =Path.Combine(currentDirectory.FullName,ListDirectory.SelectedItem.ToString());
                isCut = false;
                }
        }

        private void buttonInsert_Click (object sender , EventArgs e)
            {
            if (isCut)
                if (File.Exists(source))
                    File.Move(source , currentDirectory.FullName);
                else
                    {
                    DirectoryCopy(source , currentDirectory.FullName);
                    Directory.Delete(source,true);
                    }
            else
                if (File.Exists(source))
                File.Copy(source , currentDirectory.FullName);
            else
                DirectoryCopy(source , currentDirectory.FullName);
            }

        private void DirectoryCopy (string source , string dest)
            {
            DirectoryInfo dir = new DirectoryInfo(source);
            DirectoryInfo[] dirs = dir.GetDirectories();
            
            dest = Directory.CreateDirectory(Path.Combine(dest,dir.Name)).FullName;

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
                {
                string temppath = Path.Combine(dest , file.Name);
                file.CopyTo(temppath , true);
                }

            foreach (DirectoryInfo subdir in dirs)
                {
                string temppath = Path.Combine(dest , subdir.Name);
                DirectoryCopy(subdir.FullName , temppath);
                }
                
            }

        private void buttonArchive_Click (object sender , EventArgs e)
            {
            if (ListDirectory.SelectedItem == null || currentDirectory == null || ListDirectory.SelectedItem.ToString().IndexOf(".zip") >= 0)
                MessageBox.Show("Select the directory or file to archive.");
            else
                {
                string dest = Path.Combine(currentDirectory.FullName , ListDirectory.SelectedItem.ToString());
                bool isFile = false;
                if (File.Exists(Path.Combine(currentDirectory.FullName , ListDirectory.SelectedItem.ToString())))
                    {
                    isFile = true;
                    FileInfo file = new FileInfo(Path.Combine(currentDirectory.FullName , ListDirectory.SelectedItem.ToString()));
                    dest = Directory.CreateDirectory(file.FullName.Remove(file.FullName.Length - file.Extension.Length  , file.Extension.Length)).FullName;
                    File.Copy(file.FullName , Path.Combine(dest , file.Name));
                    }
                    ZipFile.CreateFromDirectory(dest , dest + ".zip");
                if (isFile)
                    Directory.Delete(dest,true);
                }
            }

        private void buttonExtract_Click (object sender , EventArgs e)
            {
            if (ListDirectory.SelectedItem == null || currentDirectory == null || ListDirectory.SelectedItem.ToString().IndexOf(".zip") < 0)
                MessageBox.Show("Select the archive to extract.");
            else
                ZipFile.ExtractToDirectory(Path.Combine(currentDirectory.FullName , ListDirectory.SelectedItem.ToString()), Path.Combine(currentDirectory.FullName , ListDirectory.SelectedItem.ToString()).Remove(Path.Combine(currentDirectory.FullName , ListDirectory.SelectedItem.ToString()).Length-4,4));
            }

        private void buttonSettings_Click (object sender , EventArgs e)
            {
            formSettings.Visible = true;
            formSettings.TopMost = true;
            settings = Settings.GetSettings();
            FormSettings.textBoxLogin.Text = settings.login;
            FormSettings.textBoxPassword.Clear();
            for (int i = 0 ; i < settings.password.Length ; i++)
                FormSettings.textBoxPassword.Text += "*";
            }
        }
    }
