using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemControls.Models
{
    public class Item
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public bool Equipped { get; set; }

    }
}
