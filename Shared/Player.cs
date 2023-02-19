using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fairSlots.Shared
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Username { get; set; } = string.Empty;
        public decimal Funds { get; set; }
        public decimal WinRate { get; set; }
    }
}
