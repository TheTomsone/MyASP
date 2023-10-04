using Microsoft.AspNetCore.Mvc;

namespace MyASP.Controllers
{
    public abstract class BaseController : Controller
    {
        public bool IsHome { get; set; } = false;
        public bool IsGame { get; set; } = false;
    }
}
