using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kodj.Api.Controllers
{
    [Route("status")]
    public class StatusController: Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public string Get()
        {
            return "ok";
        }
    }
}
