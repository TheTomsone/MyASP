using Microsoft.AspNetCore.Mvc;
using MyASP.DAL.Interfaces;
using MyASP.Session;

namespace MyASP.Controllers
{
    public class GameTypeController : Controller
    {
        private readonly IGameTypeService _gameTypeService;
        public GameTypeController(IGameTypeService gameTypeService)
        {
            _gameTypeService = gameTypeService;
        }
        public IActionResult Index()
        {
            return View(_gameTypeService.GetAll("T_TYPE"));
        }
        [AdminRequired]
        public IActionResult Create()
        {
            return View();
        }
        [AdminRequired]
        public IActionResult Delete(int id)
        {
            _gameTypeService.Delete("T_TYPE", id);
            return RedirectToAction("Index");
        }
    }
}
