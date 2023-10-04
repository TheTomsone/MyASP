using Microsoft.AspNetCore.Mvc;
using MyASP.DAL.Interfaces;
using MyASP.DAL.Models;
using MyASP.Models.ViewModel;
using MyASP.Session;

namespace MyASP.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userSrv;
        private readonly SessionManager _sessionMgr;

        public UserController(IUserService userSrv, SessionManager sessionMgr)
        {
            _userSrv = userSrv;
            _sessionMgr = sessionMgr;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserRegisterForm userRegisterForm)
        {
            if (!ModelState.IsValid)
                return View(userRegisterForm);

            if (_userSrv.Register(userRegisterForm.Email, userRegisterForm.Password, userRegisterForm.Username))
                return RedirectToAction("Index", "Game");

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginForm loginForm)
        {
            try
            {
                User connectedUser = _userSrv.Login(loginForm.Email, loginForm.Password);
                _sessionMgr.ConnectedUser = connectedUser;
                return RedirectToAction("Index", "Game");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult Logout()
        {
            _sessionMgr.Logout();
            return RedirectToAction("Index", "Game");
        }

        public IActionResult Details()
        {
            return View(_sessionMgr.ConnectedUser);
        }
        [CustomAuthorize]
        public IActionResult AddGame(int id)
        {
            _userSrv.AddGameToList(id, _sessionMgr.ConnectedUser);
            return RedirectToAction("Index", "Game");
        }
        public IActionResult DeleteGame()
        {
            return RedirectToAction("Details", "User");
        }
    }
}
