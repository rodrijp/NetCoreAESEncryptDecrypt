using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordLibrary.Config
{
    public class ServiceConfig
    {
        public ServiceConfig() {
            Services = new List<Service>();
        }

        public String Salt {get; set;}
        public String Vector {get; set;}
        public List<Service> Services {get; set;}
    }
}

