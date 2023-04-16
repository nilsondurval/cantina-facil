using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CantinaFacil.Shared.Kernel.API.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CantinaFacilAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (SkipAuthorization(context))
                return;

            var cantinaFacilClient = context.HttpContext.Request.Headers.Any(x => x.Key.Equals("x-cantinafacil-client") && x.Value.Equals(""));

            if (!cantinaFacilClient)
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private bool SkipAuthorization(AuthorizationFilterContext context)
        {
            return context.ActionDescriptor.EndpointMetadata.Any(x => x.GetType() == typeof(AllowAnonymousAttribute));
        }
    }
}
