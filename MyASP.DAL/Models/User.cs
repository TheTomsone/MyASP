using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASP.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }

        [ScaffoldColumn(false)]
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
    }
}
