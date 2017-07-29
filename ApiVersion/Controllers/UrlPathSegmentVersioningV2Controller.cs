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
    [RoutePrefix("api/v{version:apiVersion}/UrlPathSegmentVersioning")]
    public class UrlPathSegmentVersioningV2Controller : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetV2()
        {
            var result = new
            {
                ControllerName = "UrlPathSegmentVersioningV2",
                ActionName = "GetV2",
                VersionNumber = "2.0"
            };
            return Ok(result);
        }
    }
}
