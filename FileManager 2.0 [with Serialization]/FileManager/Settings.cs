using System;
using System.IO;
using System.Drawing;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FileManager
    {
    public class Settings
        {

        public string login;
        public string password;

        [XmlIgnore]public Color cMainWin;
        [XmlElement("cMainWin")] public int cMainWinSer
            {
            get { return cMainWin.ToArgb(); }
            set { cMainWin = Color.FromArgb(value); }
            }

        [XmlIgnore] public Color cExpl { get; set; }
        [XmlElement("cExpl")] public int cExplSer
            {
            get { return cExpl.ToArgb(); }
            set { cExpl = Color.FromArgb(value); }
            }

        [XmlIgnore] public Color cStrPath { get; set; }
        [XmlElement("cStrPath")] public int cStrPathSer
            {
            get { return cStrPath.ToArgb(); }
            set { cStrPath = Color.FromArgb(value); }
            }

        [XmlIgnore] public Color cButns { get; set; }
        [XmlElement("cButns")] public int cButnsSer
            {
            get { return cButns.ToArgb(); }
            set { cButns = Color.FromArgb(value); }
            }

        [XmlIgnore] public Font fExpl;
        [XmlElement("fExpl")] public string fExplSer
            {
            get { return TypeDescriptor.GetConverter(typeof(Font)).ConvertToString(fExpl); }
            set { fExpl = (Font)TypeDescriptor.GetConverter(typeof(Font)).ConvertFromString(value); }
            }

        [XmlIgnore] public Font fStrPath;
        [XmlElement("fStrPath")] public string fStrPathSer
            {
            get { return TypeDescriptor.GetConverter(typeof(Font)).ConvertToString(fStrPath); }
            set { fStrPath = (Font)TypeDescriptor.GetConverter(typeof(Font)).ConvertFromString(value); }
            }

        [XmlIgnore] public Font fButns;
        [XmlElement("fButns")] public string fButnsSer
            {
            get { return TypeDescriptor.GetConverter(typeof(Font)).ConvertToString(fButns); }
            set { fButns = (Font)TypeDescriptor.GetConverter(typeof(Font)).ConvertFromString(value); }
            }

        [XmlIgnore] public Color fcExpl { get; set; }
        [XmlElement("fcExpl")] public int fcExplSer
            {
            get { return fcExpl.ToArgb(); }
            set { fcExpl = Color.FromArgb(value); }
            }

        [XmlIgnore] public Color fcStrPath { get; set; }
        [XmlElement("fcStrPath")] public int fcStrPathSer
            {
            get { return fcStrPath.ToArgb(); }
            set { fcStrPath = Color.FromArgb(value); }
            }

        [XmlIgnore] public Color fcButns { get; set; }
        [XmlElement("fcButns")] public int fcButnsSer
            {
            get { return fcButns.ToArgb(); }
            set { fcButns = Color.FromArgb(value); }
            }


        public static void SetDefaultSettings ()
            {
            Settings settings = new Settings();

            settings.login = "";
            settings.password = "";

            settings.cMainWin = FormGeneral.fGen.BackColor;
            settings.cExpl = FormGeneral.fGen.ListDirectory.BackColor;
            settings.cStrPath = FormGeneral.fGen.labelPath.BackColor;
            settings.cButns = FormGeneral.fGen.buttonBack.BackColor;

            settings.fExpl = FormGeneral.fGen.ListDirectory.Font;
            settings.fStrPath = FormGeneral.fGen.labelPath.Font;
            settings.fButns = FormGeneral.fGen.buttonBack.Font;

            settings.fcExpl = FormGeneral.fGen.ListDirectory.ForeColor;
            settings.fcStrPath = FormGeneral.fGen.labelPath.ForeColor;
            settings.fcButns = FormGeneral.fGen.buttonBack.ForeColor;

            string setPath = FormGeneral.defaultSettingsPath;
            XmlSerializer xSer = new XmlSerializer(typeof(Settings));

            if (File.Exists(setPath))
                File.Delete(setPath);

            using (FileStream fs = new FileStream(setPath , FileMode.Create))
                {
                xSer.Serialize(fs , settings);
                fs.Close();
                }
            }

        public void Save ()
            {
            if (!FormGeneral.isDefault)
                {

                string setPath = FormGeneral.settingsPath;

                if (File.Exists(setPath))
                    File.Delete(setPath);

                XmlSerializer xSer = new XmlSerializer(typeof(Settings));

                using (FileStream fs = new FileStream(setPath , FileMode.Create))
                    {
                    xSer.Serialize(fs , this);
                    fs.Close();
                    }
                }
            }

        public static Settings GetSettings ()
            {
            Settings settings = null;

            string setPath = (FormGeneral.isDefault||!File.Exists(FormGeneral.settingsPath)) ? FormGeneral.defaultSettingsPath : FormGeneral.settingsPath;

            XmlSerializer xSer = new XmlSerializer(typeof(Settings));

            using (FileStream fs = new FileStream(FormGeneral.settingsPath , FileMode.Open))
                {
                settings = (Settings)xSer.Deserialize(fs);
                fs.Close();
                }

            return settings;
            }
        }
    }
