using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiVersion.Controllers
{
    [ApiVersion("2.0")]
    [RoutePrefix("api/MediaTypeVersion")]
    public class MediaTypeVersionV2Controller : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetV2()
        {
            var result = new
            {
                ControllerName = "MediaTypeVersionV2",
                ActionName = "GetV2",
                VersionNumber = "v2.0"
            };
            return Ok(result);
        }
    }
}
