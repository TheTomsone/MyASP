using MyASP.DAL.Models;
using Newtonsoft.Json;

namespace MyASP.Session
{
    public class SessionManager
    {
        private readonly ISession _session;
        public SessionManager(IHttpContextAccessor httpContext)
        {
            _session = httpContext.HttpContext.Session;
        }

        public User? ConnectedUser
        {
            get { return (string.IsNullOrEmpty(_session.GetString("connectedUser")) ? null : JsonConvert.DeserializeObject<User>(_session.GetString("connectedUser"))); }
            set { _session.SetString("connectedUser", JsonConvert.SerializeObject(value)); }
        }

        public void Logout()
        {
            _session.Clear();
        }
    }
}
