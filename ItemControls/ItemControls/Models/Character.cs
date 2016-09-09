using ItemControls.Enums;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ItemControls.Models
{
    public class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public CharacterClass CharacterClass { get; set; }
        public Gender Gender { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Gold { get; set; }
        public ObservableCollection <Item> Inventory { get; set; }
        public string Avatar { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
