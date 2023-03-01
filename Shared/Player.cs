using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fairSlots.Shared
{
    public class Player
    {
        [Display(Name = "Player ID")]
        public int PlayerID { get; set; }
        [Display(Name = "Username")]
        public string Username { get; set; } = string.Empty;
        [Display(Name = "Funds")]
        public decimal Funds { get; set; }
        [Display (Name = "Win Rate")]
        public decimal WinRate { get; set; }
    }
}
