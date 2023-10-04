using MyASP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASP.DAL.Interfaces
{
    public interface IUserService : IBaseRepository<User>
    {
        User Login(string email, string pwd);
        bool Register(string email, string pwd, string username);
        bool AddGameToList(int gameId, User? currentUser);
        bool RemoveGameFromList(int id);
    }
}
