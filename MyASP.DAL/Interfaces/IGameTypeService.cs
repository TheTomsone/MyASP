using MyASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASP.DAL.Interfaces
{
    public interface IGameTypeService : IBaseRepository<GameType>
    {
        void Create(GameType gameType);
    }
}
