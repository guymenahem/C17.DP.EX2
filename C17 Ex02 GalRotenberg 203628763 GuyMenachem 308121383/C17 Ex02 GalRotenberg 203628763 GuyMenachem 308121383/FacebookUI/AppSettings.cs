using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace C17_Ex01_Gal_203628763_Guy_308121383
{
    public class AppSettings
    {
        private const string FILE_NAME = "AppSettings.xml";

        // App setting members
        public Size WindowSize { get; set; }

        public Point WindowsStart { get; set; }

        public bool RememberUser { get; set; }

        public string UserAccessToken { get; set; }

        public AppSettings()
        {
            WindowSize = new Size(891, 439);
            WindowsStart = new Point(0, 0);
            RememberUser = false;
            UserAccessToken = null;
        }

        public void SaveSettingsToFile()
        {
            if(!File.Exists(FILE_NAME))
            {
                File.Create(FILE_NAME).Close();    
            }

            using (Stream stream = new FileStream(FILE_NAME, FileMode.Truncate))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }

        public void LoadSettingsFromFile()
        {
            if(File.Exists(FILE_NAME))
            {
                using (Stream stream = new FileStream(FILE_NAME, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(this.GetType());
                    AppSettings obj = serializer.Deserialize(stream) as AppSettings;
                    this.WindowSize = obj.WindowSize;
                    this.WindowsStart = obj.WindowsStart;
                    this.UserAccessToken = obj.UserAccessToken;
                    this.RememberUser = obj.RememberUser;
                }
            }
        }
    }
}
