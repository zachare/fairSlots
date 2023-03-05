using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Model for the Player class, it has a one-to-many relationship with Game and a
// one-to-one relationship with Chance

namespace fairSlots.Shared
{
    public class Player
    {
        [Required]
        public int PlayerID { get; set; }
        [Required]
        [StringLength(16, ErrorMessage = "Username is too long (16 character limit).")]
        public string? Username { get; set; }
        [Required]
        public decimal Funds { get; set; }


    }
}
