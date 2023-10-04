using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASP.DAL.Models
{
    public class Game
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("Title")]
        [MinLength(5, ErrorMessage = "Game title must contain at least 5 characters")]
        public required string Title { get; set; }
        [DisplayName("Description")]
        [MinLength(10, ErrorMessage = "Description must contain at least 10 characters")]
        public required string Resume { get; set; }
        [DisplayName("Type")]
        public required string GameType { get; set; }
    }
}
