using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBreeze;
using System.IO;

namespace wcfTeenService
{
    static public class Settings
    {

        #region Static Private Fields
        static private List<DateTime> _lstAttendanceDates = new List<DateTime>();
        static private string _UserName = "";
        static private string _Password = "";
        static private string _Server = "";
        static private string _DBFilePath = "";
        static private readonly string RegKey = "Software\\SBS\\TeenCheckin";
        static private DBreezeEngine _Engine = null;
        #endregion
        #region Static Public Fields

        static public DBreezeEngine Engine
        {
            get { return _Engine; }
            set { _Engine = value; }
        }
        static public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                Code.TeenDataHelper.UserName = UserName;
            }
        }
        static public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                Code.TeenDataHelper.Password = _Password;
            }
        }
        static public string Server
        {
            get { return _Server; }
            set
            {
                _Server = value;
                Code.TeenDataHelper.ServerAddress = _Server; 
            }
        }

        static public string DBFilePath
        {
            get { return _DBFilePath; }
            set { _DBFilePath = value; }
        }
        #endregion
        #region Static Methods

        static private string ReadRegistryString(string key)
        {
            Microsoft.Win32.RegistryKey rkey;
            rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegKey, true);
            if (rkey == null)
            {
                rkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(RegKey);
            }

            if (rkey.GetValue(key) == null)
            {
                rkey.SetValue(key, "");
            }
            return rkey.GetValue(key).ToString();
        }

        static private void SetRegistryString(string key, string value)
        {
            Microsoft.Win32.RegistryKey rkey;

            rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegKey, true);
            if (rkey == null) rkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(RegKey);
            rkey.SetValue(key, value);
        }

        static private bool ReadRegistryBool(string key)
        {
            string val = ReadRegistryString(key);
            if (val.ToUpper() == "Y") return true; else return false;
        }

        static private void SetRegistryBool(string key, bool value)
        {
            if (value)
                SetRegistryString(key, "Y");
            else
                SetRegistryString(key, "N");
        }

        static public void LoadSettings()
        {
            Server = ReadRegistryString("Server");
            UserName = ReadRegistryString("UserName");
            Password = ReadRegistryString("Password");
            DBFilePath = ReadRegistryString("DBFilePath");

            if(DBFilePath.IsNullOrEmpty())
            {
                var AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                DBFilePath = Path.Combine(AppData, "TeenService\\data.db");
            }

            

        }

        static public void SaveSettings()
        {
            SetRegistryString("Server", Server);
            SetRegistryString("UserName", UserName);
            SetRegistryString("Password", Password);
            SetRegistryString("DBFilePath", DBFilePath);
        }

        static public void Initialize()
        {
            // Code.TeenDataHelper.ServerAddress = "james-pc";
            // Code.TeenDataHelper.UserName = "TeenApp";
            // Code.TeenDataHelper.Password = "passw0rd";
            Code.LogMan.Initialize("log.txt");
            Settings.LoadSettings();
            Engine = new DBreezeEngine(DBFilePath);
            
        }

        static public void FinalizeSettings()
        {
            Engine.Dispose();
            Engine = null;
        }
        #endregion

    }
}