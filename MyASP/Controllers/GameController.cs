using Microsoft.AspNetCore.Mvc;
using MyASP.DAL.Interfaces;
using MyASP.DAL.Models;
using MyASP.Models.ViewModel;
using MyASP.Session;

namespace MyASP.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGameService _gameService;
        private readonly IGameTypeService _gameTypeService;
        private GameViewModel _gameViewModel;

        public GameController(IGameService gameService, IGameTypeService gameTypeService)
        {
            _gameService = gameService;
            _gameTypeService = gameTypeService;
            _gameViewModel = new(gameService.GetAll("G_GAMETYPES_VIEW"), gameTypeService.GetAll("T_TYPE"));

            IsGame = true;
        }

        public IActionResult Index()
        {
            if (TempData.ContainsKey("GameViewModel"))
            {
                var games = TempData["GameViewModel"] as IEnumerable<Game>;
                if (games is not null)
                    _gameViewModel.SetGames(games);
            }

            return View(_gameViewModel);
        }

        public IActionResult Filter(int id)
        {
            _gameViewModel.SetGames(_gameService.FilterByType(id));

            TempData["GameViewModel"] = _gameViewModel.Games;

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_gameService.Get("G_GAMETYPES_VIEW", id));
        }
        [AdminRequired]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
            _gameService.Create(game);
            return RedirectToAction("Index");
        }

        [AdminRequired]
        public IActionResult Delete(int id)
        {
            _gameService.Delete("G_GAME", id);
            return RedirectToAction("Index");
        }
    }
}
