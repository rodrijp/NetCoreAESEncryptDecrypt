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
        private static String _ServiceFile = "App_Data/services.xml";
        private static List<Service> _Services = null;

        public static List<Service> Services { 
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
            var service = Services.FirstOrDefault(x => String.Compare(x.Name, serviceName, true) == 0);
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
                Services.Add(serviceAdd);
            }
            SetToFile();
        }

        private static List<Service> GetFromFile()
        {
            //var p = Directory.GetCurrentDirectory();
            if (!File.Exists(_ServiceFile)) return new List<Service>();
            var serializer = new XmlSerializer(typeof(List<Service>));
            var fs = new FileStream(_ServiceFile, FileMode.Open);
            var rtn = (List<Service>) serializer.Deserialize(fs);
            fs.Close();
            return rtn;
        }


        private static void SetToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Service>));
            var writer = new StreamWriter(_ServiceFile);
            serializer.Serialize(writer, _Services);
            writer.Close();
        }

    }
}
