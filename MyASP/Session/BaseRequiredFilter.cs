namespace MyASP.Session
{
    public abstract class BaseRequiredFilter
    {
        protected readonly SessionManager _session;
        public BaseRequiredFilter(SessionManager session)
        {
            _session = session;
        }
    }
}
