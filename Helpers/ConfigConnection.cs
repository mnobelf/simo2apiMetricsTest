using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace simo2api.Helpers
{
    public class ConfigConnection
    {
        public JObject getAppSettings()
        {
                string path = System.IO.Directory.GetCurrentDirectory();
                JObject data = JObject.Parse(File.ReadAllText(path + "/appsettings.json"));
                return data;
        }
        public string getConnectionString()
        {
            JObject appset = getAppSettings();
            string connString = appset["ConnectionStrings"]["DevConnection"].ToString();
            return connString;
        }
        public MailSettings getConfigureEmail()
        {
            JObject appset = getAppSettings();
            MailSettings mailSettings = new MailSettings();
            mailSettings.Mail = appset["MailSettings"]["Mail"].ToString();
            mailSettings.DisplayName = appset["MailSettings"]["DisplayName"].ToString();
            mailSettings.Host = appset["MailSettings"]["Host"].ToString();
            mailSettings.Password = appset["MailSettings"]["Password"].ToString();

            string port = appset["MailSettings"]["Port"].ToString();
            mailSettings.Port = Int32.Parse(port);
            return mailSettings;
        }

    }
}
