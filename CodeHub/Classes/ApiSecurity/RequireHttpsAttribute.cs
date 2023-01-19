using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CodeHub.Classes
{
    public class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        // MUA : This class is being added for API to handle HTTPS requests.
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Found);
                actionContext.Response.Content = new StringContent
                    ("<p>Use https instead of http</p>", Encoding.UTF8, "text/html");

                UriBuilder uriBuilder = new UriBuilder(actionContext.Request.RequestUri);
                uriBuilder.Scheme = Uri.UriSchemeHttps;
                uriBuilder.Port = 44337;

                actionContext.Response.Headers.Location = uriBuilder.Uri;
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}