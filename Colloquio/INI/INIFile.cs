using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Colloquio
{
    public class INIFile        //ini configuration / reading / writing
    {
        public string path { get; private set; }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public INIFile(string INIPath)      //constructor read path
        {
            path = INIPath;
        }
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        public string IniReadValue(string Section, string Key)      //read INI
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }
        public static (string[],string[],string []) LoadConfigurationINI()       //load config ini file
        {
            string basePath = System.Environment.CurrentDirectory + "\\" + "Settings";
            INIFile ini = new INIFile(basePath + "\\" + "Settings.ini");
            string[] stampaServer = new string[Predefiniti_StampaServer.ValueProperty.Length];
            string[] archivio = new string[Predefiniti_Archivio.ValueProperty.Length];
            string[] dicom = new string[Predefiniti_Dicom.ValueProperty.Length];
            if (!Directory.Exists(basePath))        //if ini file does not exist create a default one
            {
                Directory.CreateDirectory(basePath);
                ini.IniWriteValue("DefaultNames", "default", "1");
                Debug.WriteLine("ini configuration created on path : " + basePath);
            }
            else
            {             //read configuration from ini file. if ini file empty, read from default static class
                Debug.WriteLine("static classes configuration is loading");
                Debug.WriteLine(Predefiniti_StampaServer.Section);
                
                Debug.WriteLine("[" + Predefiniti_StampaServer.Section + "] config");
                for (int i = 0; i < Predefiniti_StampaServer.ValueProperty.Length; i++)
                {
                    string stampaServerStaticClass = Predefiniti_StampaServer.ValueProperty[i];
                    string stampaServerIni = ini.IniReadValue(Predefiniti_StampaServer.Section, Predefiniti_StampaServer.Key[i]);
                    if(stampaServerIni == "")
                    {
                        stampaServer[i] = stampaServerStaticClass;
                    }
                    else
                    {
                        stampaServer[i] = stampaServerIni;
                    }
                    Debug.WriteLine(Predefiniti_StampaServer.Key[i] + " = " + stampaServer[i]);
                }
                Debug.WriteLine("[" + Predefiniti_Archivio.Section + "]  config");
                for (int i = 0; i < Predefiniti_Archivio.ValueProperty.Length; i++)
                {
                    string archivioStaticClass = Predefiniti_Archivio.ValueProperty[i];
                    string archivioIni = ini.IniReadValue(Predefiniti_Archivio.Section, Predefiniti_Archivio.Key[i]);
                    if (archivioIni == "")
                    {
                        archivio[i] = archivioStaticClass;
                    }
                    else
                    {
                        archivio[i] = archivioIni;
                    }
                    Debug.WriteLine(Predefiniti_Archivio.Key[i] + " = " + archivio[i]);
                }
                Debug.WriteLine("[" + Predefiniti_Dicom.Section + "]  config");
                for (int i = 0; i < Predefiniti_Dicom.ValueProperty.Length; i++)
                {
                    string dicomStaticClass = Predefiniti_Dicom.ValueProperty[i];
                    string dicomIni = ini.IniReadValue(Predefiniti_Dicom.Section, Predefiniti_Dicom.Key[i]);
                    if (dicomIni == "")
                    {
                        dicom[i] = dicomStaticClass;
                    }
                    else
                    {
                        dicom[i] = dicomIni;
                    }
                    Debug.WriteLine(Predefiniti_Dicom.Key[i] + " = " + dicom[i]);
                }
                Debug.WriteLine("static classes configuration finished");
            }
            return (stampaServer, archivio, dicom);
        }
    }
}

