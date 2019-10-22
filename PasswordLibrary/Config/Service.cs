using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordLibrary.Config
{
    public class Service
    {
        public String Name { get; set; }
        public int Size { get; set; }
        public bool IncludeEspecialChar { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeUpperLower { get; set; }
        public bool OnlyNumbers { get; set; }
    }
}
