using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Model for Chance class, it has a one-to-one relationship with the Player class

namespace fairSlots.Shared
{
    public class Chance
    {
        // Utilizes the Key attribute to set the foreign key as its primary key
        [Required]
        [Key]
        public int PlayerID { get; set; }
        public Player? Player { get; set; }
        [Required]
        public DateTime UpdateTime { get; set; }
        [Required]
        public decimal WinRate { get; set; }
    }
}
