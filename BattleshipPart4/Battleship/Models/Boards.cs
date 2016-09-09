using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Battleship.Models
{
    [Serializable]
    public class Boards
    {
        public string[] PlayerShipBoard { get; set; }
        public string[] CompShipBoard { get; set; }
        public string[] SepShipArray { get; set; }
        public List<int> PlayShipLengths { get; set; }
        public List<string[]> PlayerShips { get; set; }
        public List<string[]> CompShips { get; set; }
        public List<string> PlayerBoard { get; set; }
        public int Position { get; set; }
        public int AmountOfShips { get; set; }
        public int Length { get; set; }
        public bool StartGame { get; set; }
        public bool MediumShip { get; set; }
    }
}
