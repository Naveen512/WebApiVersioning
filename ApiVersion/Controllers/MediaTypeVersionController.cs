using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiVersion.Controllers
{
    [ApiVersion("1.0",Deprecated =true)]
    [RoutePrefix("api/MediaTypeVersion")]
    public class MediaTypeVersionController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetV1()
        {
            var result = new
            {
                ControllerName = "MediaTypeVersion",
                ActionName = "GetV1",
                VersionNumber = "V1.0"
            };
            return Ok(result);
        }
    }
}
