using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
    public class Player
    {
        public int PlayerID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please provide the player name...")]
        public string PlayerName { get; set; }

        [Display(Name = "Jersey Number")]
        [RegularExpression(@"^[1-99]\d*$", ErrorMessage = "Please select a number other than zero for the player...")]
        public int JerseyNumber { get; set; }

        [Display(Name = "Position")]
        [Required(ErrorMessage = "Please select the player's position...")]
        public int PositionID { get; set; }

        [Display(Name = "Previous Years Batting Average")]
        public decimal PreviousYrsBattingAvg { get; set; }

        [Display(Name = "Number of Years Played")]
        public int NumYrsPlayed { get; set; }

        [Display(Name="Team")]
        public int TeamID { get; set; }
    }
}
