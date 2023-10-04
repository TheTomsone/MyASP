using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyASP.Session
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute() : base(typeof(AuthRequiredFilter))
        {
        }
    }

    public class AuthRequiredFilter : BaseRequiredFilter, IAuthorizationFilter
    {
        public AuthRequiredFilter(SessionManager session) : base(session)
        {
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_session.ConnectedUser is null)
            {
                context.Result = new RedirectToRouteResult(new { action = "NotFound", Controller = "Home" });
            }
        }
    }
}
