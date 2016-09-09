using ItemControls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ItemControls.Enums;
using System.Collections.ObjectModel;

namespace ItemControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Run();
        }

        private void CharacterInitializer()
        {
            ObservableCollection<Character> characters = new ObservableCollection<Character>()
            {
                new Character() { Name = "Alfonzo", Level = 2, CharacterClass = CharacterClass.Fighter, Gender = Gender.Male, Strength = 22, Dexterity = 15, Intelligence= 8, Gold = 250, Avatar = "Images\\maleFighter.jpg"},
                new Character() { Name = "Erza", Level = 5, CharacterClass = CharacterClass.Fighter, Gender = Gender.Female, Strength = 21, Dexterity = 19, Intelligence= 16, Gold = 300, Avatar = "Images\\femaleFighter.jpg"},
                new Character() { Name = "Dildon", Level = 10, CharacterClass = CharacterClass.Mage, Gender = Gender.Male, Strength = 16, Dexterity = 15, Intelligence= 25, Gold = 350, Avatar = "Images\\maleMage.jpg"},
                new Character() { Name = "Nyci", Level = 4, CharacterClass = CharacterClass.Mage, Gender = Gender.Female, Strength = 18, Dexterity = 18, Intelligence= 21, Gold = 300, Avatar = "Images\\femaleMage.jpg"},
                new Character() { Name = "Leon", Level = 4, CharacterClass = CharacterClass.Ranger, Gender = Gender.Male, Strength = 18, Dexterity = 22, Intelligence= 18, Gold = 150, Avatar = "Images\\maleRanger.jpg"},
                new Character() { Name = "Lydia", Level = 6, CharacterClass = CharacterClass.Ranger, Gender = Gender.Female, Strength = 16, Dexterity = 24, Intelligence= 18, Gold = 200, Avatar = "Images\\femaleRanger.jpg"}
            };


            characters[0].Inventory = new ObservableCollection<Item>()
            {
                new Item() {Name="Iron Sword", Cost = 30, Description = "A iron sword.", Effect = "1d8", Equipped = true},
                new Item() {Name="Hide Armor", Cost = 15, Description = "Armor made of tanned and preserved skin.", Effect = "+4Armor/Shield", Equipped = true}
            };
            characters[1].Inventory = new ObservableCollection<Item>()
            {
                new Item() {Name="Steel Sword", Cost = 100, Description = "A steel sword", Effect = "2d10", Equipped = true},
                new Item() {Name="Chainmail", Cost = 150, Description = "Suit of chainmail.", Effect = "+6Armor/Shield", Equipped = true},
                new Item() {Name="Med HP Potion", Cost = 20, Description = "Heals HP", Effect = "+2d4HP", Equipped = false}
            };
            characters[2].Inventory = new ObservableCollection<Item>()
            {
                new Item() {Name="Chain Shirt", Cost = 100, Description = "An shirt made of chains.", Effect = "+4Armor/Shield", Equipped = true},
                new Item() {Name="Med Mana Potion", Cost = 20, Description = "Heals mana.", Effect = "+2d4Mana", Equipped = false},
                new Item() {Name="Staff", Cost = 50, Description = "An low level staff.", Effect = "1d10", Equipped = true}
            };
            characters[3].Inventory = new ObservableCollection<Item>()
            {
                new Item() {Name="Rosewood Armor", Cost = 50, Description = "Leather armor wrapped in rose vines.", Effect = "+2Armor/Shield", Equipped = true},
                new Item() {Name="Sickle", Cost = 50, Description = "A curved blade.", Effect = "1d8", Equipped = false},
                new Item() {Name="Wand", Cost = 75, Description = "An low level staff.", Effect = "1d10", Equipped = false}
            };
            characters[4].Inventory = new ObservableCollection<Item>()
            {
                new Item() {Name="Leather", Cost = 10, Description = "Armor made of leather.", Effect = "+2Armor/Shield", Equipped = true},
                new Item() {Name="Cloth Cloak & Hood", Cost = 5, Description = "Cloth-made cloak and hood", Effect = "+0Armor/Shield", Equipped = true},
            };                                                                                           
            characters[5].Inventory = new ObservableCollection<Item>()
            {
                new Item() {Name="Leather", Cost = 10, Description = "Armor made of leather.", Effect = "+2Armor/Shield", Equipped = true},
                new Item() {Name="Longbow", Cost = 50, Description = "Wooden longbow", Effect = "1d8 100ft", Equipped = true},
                new Item() {Name="Iron Arrow", Cost = 100, Description = "Iron Arrows", Effect = "0 effect", Equipped = true},
            };            

            characterList.ItemsSource = characters;
            characterList.SelectionChanged += new SelectionChangedEventHandler(characterList_SelectionChanged);
        }

        public void Run()
        {
            CharacterInitializer();
        }

        private void characterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character tempChar = (sender as ComboBox).SelectedItem as Character;
            ObservableCollection<Item> inv = tempChar.Inventory;
            inventoryGrid.ItemsSource = inv;
        }
    }
}   
