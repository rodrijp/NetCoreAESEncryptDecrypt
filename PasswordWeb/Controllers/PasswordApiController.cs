using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PasswordLibrary.Config;
using PasswordLibrary.PasswordService;

namespace PasswordWeb.Controllers
{

    public class GetPasswordParam {
        public Service service {get; set;}
        public String key {get; set;}
    }

    public class GetPasswordResponse {
        public String password {get; set;}
    }

    public class AddServiceParam {
        public Service service {get; set;}
    }
    

    [ApiController]   
    [Route("[controller]")]
    public class PasswordApiController : ControllerBase
    {
        [HttpPost("GetPassword")]
        public GetPasswordResponse GetPassword([FromBody] GetPasswordParam getPasswordParam)
        {
            var res = new GetPasswordResponse();
            res.password = PasswordServiceUtil.GetPassword(getPasswordParam.service, getPasswordParam.key);
            return res;
        }

        [HttpPost("AddServiceParam")]
        public void AddService([FromBody] AddServiceParam addServiceParam)
        {
            ServiceUtil.Add(addServiceParam.service);
        }

        [HttpGet("GetServices")]
        public List<Service> GetServices(String service) {
            return ServiceUtil.ServiceConfig.Services;
        }

/*
        [HttpPost("Hola")]
        public String Hola([FromBody] GetPasswordParam getPasswordParam)
        {
            //String key = "hola";
            return getPasswordParam.key;
        }
 */

    }
}
