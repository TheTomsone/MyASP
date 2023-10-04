using MyASP.DAL.Interfaces;
using MyASP.DAL.Models;
using MyASP.DAL.Services;

namespace MyASP.Models.ViewModel
{
    public class GameViewModel
    {
        private  IEnumerable<Game> _games;

        private readonly IEnumerable<GameType> _gameTypes;
        public IEnumerable<Game> Games { get { return _games; } }
        public IEnumerable<GameType> GameTypes { get { return _gameTypes; } }
        public GameViewModel(IEnumerable<Game> games, IEnumerable<GameType> gameTypes)
        {
            _games = games;
            _gameTypes = gameTypes;
        }
        public void SetGames(IEnumerable<Game> games)
        {
            _games = games;
        }
    }
}
