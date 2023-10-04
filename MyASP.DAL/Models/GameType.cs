using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASP.DAL.Models
{
    public class GameType
    {
        [ScaffoldColumn(false)]
        public required int Id { get; set; }
        [DisplayName("Type name")]
        public required string Name { get; set; }
    }
}
