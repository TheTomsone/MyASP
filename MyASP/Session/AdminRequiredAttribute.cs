using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyASP.Session
{
    public class AdminRequiredAttribute : TypeFilterAttribute
    {
        public AdminRequiredAttribute() : base(typeof(AdminRequiredAttribute))
        {
        }
    }

    public class AdminRequiredFilter : BaseRequiredFilter, IAuthorizationFilter
    {
        public AdminRequiredFilter(SessionManager session) : base(session)
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_session.ConnectedUser is null || _session.ConnectedUser.RoleId < 3 || _session.ConnectedUser.RoleId > 3)
            {
                context.Result = new RedirectToRouteResult(new { action = "NotFound", Controller = "Home" });
            }
        }
    }
}
