using PasswordLibrary.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordLibrary.PasswordService
{
    public static class PasswordServiceUtil
    {
        public static String GetPassword(Service service, String password)
        {
            var hash = PasswordUtil.HashString(service.Name, password);
            var rtn = String.Empty;
            if (service.OnlyNumbers)
            {
                rtn = hash.Substring(0, service.Size);
                for (var i = 0; (i < service.Size); i++)
                {
                    rtn = rtn.Substring(0, i) +
                          ((int)rtn[i] % 10).ToString() +
                          rtn.Substring(i + 1);
                }
            }
            else
            {
                var size = service.Size + ((service.IncludeEspecialChar) ? -1 : 0);
                rtn = hash.Substring(0, size) + ((service.IncludeEspecialChar) ? "." : "");
                if ((service.IncludeNumbers) && (!rtn.Any(char.IsDigit)))
                {
                    var penultimateIndex = rtn.Length - 2;
                    rtn = rtn.Substring(0, penultimateIndex) +
                          ((int)rtn[penultimateIndex] % 10).ToString() +
                          rtn.Substring(penultimateIndex + 1, 1);
                }
                if ((service.IncludeUpperLower) && !(rtn.Any(char.IsUpper) && rtn.Any(char.IsLower)))
                {
                    var antepenultimate = rtn.Length - 3;
                    var isUpper = rtn.Any(char.IsUpper);
                    rtn = rtn.Substring(0, antepenultimate) +
                          (isUpper ? Char.ToLower(rtn[antepenultimate]) : Char.ToLower(rtn[antepenultimate])).ToString() +
                          rtn.Substring(antepenultimate + 1, 2);
                }
            }
            return rtn;
        }
    }
}
