﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Required]
        public decimal WinRate { get; set; }

    }
}
