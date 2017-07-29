using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using System.Web.Http.Routing;
using Microsoft.Web.Http.Routing;
using Microsoft.Web.Http.Versioning;

namespace ApiVersion
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["QueryStringVersion"]))
            {
                var constraintResolver = new DefaultInlineConstraintResolver
                {
                    ConstraintMap =
                    {
                        ["apiVersion"]= typeof(ApiVersionRouteConstraint)
                    }
                };
                config.MapHttpAttributeRoutes(constraintResolver);
                config.AddApiVersioning(o => o.ApiVersionReader = new QueryStringApiVersionReader("v"));
            }
            else if (Convert.ToBoolean(ConfigurationManager.AppSettings["UrlPathSegment"]))
            {
                var constraintResolver = new DefaultInlineConstraintResolver
                {
                    ConstraintMap =
                    {
                        ["apiVersion"]= typeof(ApiVersionRouteConstraint)
                    }
                };
                config.MapHttpAttributeRoutes(constraintResolver);
                config.AddApiVersioning();
            }
            else if (Convert.ToBoolean(ConfigurationManager.AppSettings["MediaTypeVersions"]))
            {
                var constraintResolver = new DefaultInlineConstraintResolver
                {
                    ConstraintMap =
                    {
                        ["apiVersion"]= typeof(ApiVersionRouteConstraint)
                    }
                };
                config.MapHttpAttributeRoutes(constraintResolver);
                config.AddApiVersioning(options =>
                {
                    options.ApiVersionReader = new MediaTypeApiVersionReader();
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    
                    options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
                });
            }
            else
            {
                // Web API routes
                config.MapHttpAttributeRoutes();
            }

          

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
