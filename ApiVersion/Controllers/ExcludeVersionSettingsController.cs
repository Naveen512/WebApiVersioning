using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiVersion.Controllers
{
    [ApiVersionNeutral]
    [RoutePrefix("api/ExcludeVersionSettings")]
    public class ExcludeVersionSettingsController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = new
            {
                ControlleName = "ExcludeVersionSettings",
                ActionName = "Get",
                VersionNumber = "Version Neutral"
            };
            return Ok(result);
        }
    }
}
