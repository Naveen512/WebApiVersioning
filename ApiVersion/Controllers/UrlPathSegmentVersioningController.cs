using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiVersion.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/UrlPathSegmentVersioning")]
    public class UrlPathSegmentVersioningController : ApiController
    {

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetV1()
        {
            var result = new
            {
                ControllerName = "UrlPathSegmentVersioning",
                ActionName = "GetV1",
                VersionNumber = "v1.0"
            };
            return Ok(result);
        }
    }
}
