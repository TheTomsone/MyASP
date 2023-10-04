using MyASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASP.DAL.Interfaces
{
    public interface IGameService : IBaseRepository<Game>
    {
        void Create(Game game);

        IEnumerable<Game> FilterByType(int typeId);
    }
}
