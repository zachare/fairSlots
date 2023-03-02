using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fairSlots.Shared
{
    public class Chance
    {
        [Required]
        public int ChanceID { get; set; }
        [Required]
        public int PlayerID { get; set; }
        public Player? Player { get; set; }
        [Required]
        public DateTime UpdateTime { get; set; }
        [Required]
        public decimal WinRate { get; set; }
    }
}
