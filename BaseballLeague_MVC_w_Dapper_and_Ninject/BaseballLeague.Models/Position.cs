using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseballLeague.Models
{
    public class Position
    {
        public int PositionID { get; set; }

        [Display(Name="Position")]
        public string PositionName { get; set; }
    }
}
