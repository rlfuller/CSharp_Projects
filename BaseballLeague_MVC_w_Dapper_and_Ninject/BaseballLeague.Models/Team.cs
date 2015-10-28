using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
    public class Team
    {
        public int TeamID { get; set; }

        [Required(ErrorMessage = "A Team Name is required...")]
        public string TeamName { get; set; }

        [Required(ErrorMessage = "A Manager Name is required...")]
        public string ManagerName { get; set; }
    }
}
