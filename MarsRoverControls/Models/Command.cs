using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverControls.Models
{
    public class Command
    {
        public string Type { get; set; }
        public string? Rotate { get; set; }
        public int Distance { get; set; }
    }
}
