using System.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace PasswordLibrary.Config
{
    public static class ServiceUtil
    {
        private static String _ServiceFile = @"\App_Data\services.xml";
        private static ServiceConfig _Services = null;

        public static ServiceConfig ServiceConfig { 
            get {
                if (_Services == null)
                {
                    _Services = GetFromFile();
                }
                return _Services;
            }
        }

        public static Service Get(String serviceName)
        {
            var service = ServiceConfig.Services.FirstOrDefault(x => String.Compare(x.Name, serviceName, true) == 0);
            return service;
        }

        public static void Add(Service serviceAdd)
        {
            var service = Get(serviceAdd.Name);
            if (service != null)
            {
                service.IncludeEspecialChar = serviceAdd.IncludeEspecialChar;
                service.IncludeNumbers = serviceAdd.IncludeNumbers;
                service.IncludeUpperLower = serviceAdd.IncludeNumbers;
                service.Size = serviceAdd.Size;
            } else
            {
                ServiceConfig.Services.Add(serviceAdd);
            }
            SetToFile();
        }

        private static ServiceConfig GetFromFile()
        {
                //var p = Directory.GetCurrentDirectory();
            var pathServiceFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + _ServiceFile;
            if (!File.Exists(pathServiceFile)) return new ServiceConfig();
            var serializer = new XmlSerializer(typeof(ServiceConfig));
            var fs = new FileStream(pathServiceFile, FileMode.Open);
            var rtn = (ServiceConfig) serializer.Deserialize(fs);
            fs.Close();
            return rtn;
        }


        private static void SetToFile()
        {
            var pathServiceFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + _ServiceFile;
            XmlSerializer serializer = new XmlSerializer(typeof(ServiceConfig));
            var writer = new StreamWriter(pathServiceFile);
            serializer.Serialize(writer, _Services);
            writer.Close();
        }

    }
}
