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

namespace Battleship
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeFiringBoard();
            InitializeShipBoard();
        }
        #region Consts
        private const int MAX_SHIP = 121;
        private const int MAX_SHIP_SIZE = 5;
        #endregion

        #region Arrays
        private Label[] shipArray = new Label[MAX_SHIP];
        private Label[] sepShipArray = new Label[MAX_SHIP_SIZE];
        private List<Label[]> ships = new List<Label[]>();
        #endregion

        #region Non-consts
        private int position = 0;
        #endregion

        public void InitializeFiringBoard()
        {
            int rows = firingGrid.RowDefinitions.Count;
            int cols = firingGrid.ColumnDefinitions.Count;
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    char colChar = (char)i; colChar += (char)64;

                    Label label = new Label();
                    if (i == 0 && j == 0)
                    {
                        label.Content = "Pt.2";
                    }
                    else if (i == 0 && j != 0)
                    {
                        label.Content = j;
                    }
                    else if (j == 0 && i != 0)
                    {
                        label.Content = colChar;
                    }
                    else
                    {
                        string location = "";
                        location += colChar;
                        location += j;
                        label.Content = location;
                        label.Background = Brushes.Blue;
                    }
                    AddLabel(label, i, j, true);
                }
            }
        }
        public void InitializeShipBoard()
        {
            int rows = shipGrid.RowDefinitions.Count;
            int cols = shipGrid.ColumnDefinitions.Count;

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    char colChar = (char)i; colChar += (char)64;

                    Label label = new Label();
                    if (i == 0 && j == 0)
                    {
                        label.Content = "Pt.2";
                    }
                    else if (i == 0 && j != 0)
                    {
                        label.Content = j;
                    }
                    else if (j == 0 && i != 0)
                    {
                        label.Content = colChar;
                    }
                    else
                    {
                        string location = "";
                        location += colChar;
                        location += j;
                        label.Content = location;
                        label.Name = location;
                        label.Background = Brushes.Blue;
                        shipArray[position] = label;
                        position++;

                    }
                    AddLabel(label, i, j, false);
                }
            }
        }

        private void AddLabel(Label label, int row, int column, bool isFiringGrid)
        {
            label.BorderBrush = Brushes.Black;
            label.BorderThickness = new Thickness(1);
            if (row != 0 && column != 0) { label.MouseLeftButtonDown += Label_MouseLeftButtonDown; label.MouseRightButtonDown += Label_MouseRightButtonDown; }
            Grid.SetColumn(label, column);
            Grid.SetRow(label, row);
            if (isFiringGrid) { firingGrid.Children.Add(label); }
            else { shipGrid.Children.Add(label); }
        }

        private bool CheckShip()
        {
            if (addShip.IsChecked.Value)
            {
                return true;
            }
            return false;
        }

        private int ShipLength()
        {
            int lengthOfShip = 0;

            string stringLengthOfShip = shipLength.Text;
            bool isParsed = int.TryParse(stringLengthOfShip, out lengthOfShip);

            if (isParsed && lengthOfShip >= 2 && isParsed && lengthOfShip <= 5)
            {
                return lengthOfShip;
            }
            else if (isParsed && lengthOfShip < 2)
            {
                lengthOfShip = 2;
                shipLength.Text = lengthOfShip.ToString();
                return lengthOfShip;
            }
            else if (isParsed && lengthOfShip > 5)
            {
                lengthOfShip = 5;
                shipLength.Text = lengthOfShip.ToString();
                return lengthOfShip;
            }

            return lengthOfShip;
        }

        private bool CheckVertical(int startingRow, int secondRow)
        {
            if (secondRow < startingRow)
            {
                return true; // Up
            }
            return false; // Down
        }
        private bool CheckHorizontal(int startingCol, int secondCol)
        {
            if (secondCol < startingCol)
            {
                return true; // Left
            }
            return false; // Right
        }

        private int AmountOfSpaces(int beginningSpace, int otherSpace)
        {
            int amount = 0;

            amount = otherSpace - beginningSpace;

            if (amount != ShipLength())
            {
                amount += ShipLength() - amount;
            }

            return amount;
        }

        private bool ChooseDirection(Label label)
        {
            int row = Grid.GetRow(label);
            int col = Grid.GetColumn(label);
            int choice = (int)Enums.Direction.Origin;

            int amountOfSpaces = 0;
            if (CheckVertical(Grid.GetRow(sepShipArray[0]), row) && col == Grid.GetColumn(sepShipArray[0]))
            {
                amountOfSpaces = AmountOfSpaces(Grid.GetRow(sepShipArray[0]), row);
                choice = (int)Enums.Direction.Up;
            }
            else if (!CheckVertical(Grid.GetRow(sepShipArray[0]), row) && col == Grid.GetColumn(sepShipArray[0]))
            {
                amountOfSpaces = AmountOfSpaces(Grid.GetRow(sepShipArray[0]), row);
                choice = (int)Enums.Direction.Down;
            }
            else if (CheckHorizontal(Grid.GetColumn(sepShipArray[0]), col) && row == Grid.GetRow(sepShipArray[0]))
            {
                amountOfSpaces = AmountOfSpaces(Grid.GetColumn(sepShipArray[0]), col);
                choice = (int)Enums.Direction.Left;
            }
            else if (!CheckHorizontal(Grid.GetColumn(sepShipArray[0]), col) && row == Grid.GetRow(sepShipArray[0]))
            {
                amountOfSpaces = AmountOfSpaces(Grid.GetColumn(sepShipArray[0]), col);
                choice = (int)Enums.Direction.Right;
            }
            else
            {
                return false;
            }
            PlaceShip(choice, amountOfSpaces);
            return true;
        }

        private bool DoesFit(Label label, int direction)
        {


            if (direction == 1)
            {
                if (Grid.GetRow(label) > 1 && Grid.GetColumn(label) == Grid.GetColumn(sepShipArray[0]))
                {
                    return true;
                }
            }
            else if (direction == 2)
            {
                if (Grid.GetRow(label) < 10 && Grid.GetColumn(label) == Grid.GetColumn(sepShipArray[0]))
                {
                    return true;
                }
            }
            else if (direction == 3)
            {
                if (Grid.GetColumn(label) > 1 && Grid.GetRow(label) == Grid.GetRow(sepShipArray[0]))
                {
                    return true;
                }
            }
            else if (direction == 4)
            {
                if (Grid.GetColumn(label) < 10 && Grid.GetRow(label) == Grid.GetRow(sepShipArray[0]))
                {
                    return true;
                }
            }
            return false;
        }

        private void PlaceShip(int choice, int amountOfSpaces)
        {
            bool successful = false;
            Label l;

            if (choice == (int)Enums.Direction.Up)
            {
                for (int i = 0; i < shipArray.Count(); ++i)
                {
                    l = shipGrid.Children[i] as Label;
                    if (l.Name == sepShipArray[0].Name)
                    {
                        for (int j = 1; j < amountOfSpaces; ++j)
                        {
                            if (DoesFit(l, choice))
                            {
                                l = shipGrid.Children[i - (11 * j)] as Label;
                                sepShipArray[j] = l;
                                successful = true;
                            }
                            else
                            {
                                successful = false;
                            }
                        }
                    }
                }
            }
            else if (choice == (int)Enums.Direction.Down)
            {
                for (int i = 0; i < shipArray.Count(); ++i)
                {
                    l = shipGrid.Children[i] as Label;
                    if (l.Name == sepShipArray[0].Name)
                    {
                        for (int j = 1; j < amountOfSpaces; ++j)
                        {
                            if (DoesFit(l, choice))
                            {
                                l = shipGrid.Children[i + (11 * j)] as Label;
                                sepShipArray[j] = l;
                                successful = true;
                            }
                            else
                            {
                                successful = false;
                            }
                        }
                    }
                }
            }
            else if (choice == (int)Enums.Direction.Left)
            {
                for (int i = 0; i < shipArray.Count(); ++i)
                {
                    l = shipGrid.Children[i] as Label;
                    if (l.Name == sepShipArray[0].Name)
                    {
                        for (int j = 1; j < amountOfSpaces; ++j)
                        {
                            if (DoesFit(l, choice))
                            {
                                l = shipGrid.Children[i - j] as Label;
                                sepShipArray[j] = l;
                                successful = true;
                            }
                            else
                            {
                                successful = false;
                            }
                        }
                    }
                }
            }
            else if (choice == (int)Enums.Direction.Right)
            {
                for (int i = 0; i < shipArray.Count(); ++i)
                {
                    l = shipGrid.Children[i] as Label;
                    if (l.Name == sepShipArray[0].Name)
                    {
                        for (int j = 1; j < amountOfSpaces; ++j)
                        {
                            if (DoesFit(l, choice))
                            {
                                l = shipGrid.Children[i + j] as Label;
                                sepShipArray[j] = l;
                                successful = true;
                            }
                            else
                            {
                                successful = false;
                            }
                        }
                    }
                }
            }
            if (successful)
            {
                foreach (Label shipLabels in sepShipArray)
                {
                    if (shipLabels.Background == Brushes.Gray && shipLabels != sepShipArray[0])
                    {
                        successful = false;
                    }
                }
            }
            if (successful)
            {
                for(int i = 0; i < sepShipArray.Length; ++i)
                {
                    if (sepShipArray[i] != null)
                    {
                        sepShipArray[i].Background = Brushes.Gray;
                    }
                }
                ships.Add(sepShipArray);
            }
            else
            {
                sepShipArray[0].Background = Brushes.Blue;
            }
            sepShipArray = new Label[MAX_SHIP_SIZE];
        }

        private void Label_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Label label = (Label)e.Source;
            if (CheckShip() && label.Parent == shipGrid && label.Background != Brushes.Gray)
            {
                if (sepShipArray[0] == null)
                {
                    sepShipArray[0] = label;
                    label.Background = Brushes.Gray;
                }
                else
                {
                    if (ChooseDirection(label))
                    {
                        sepShipArray[1] = label;
                    }
                }
            }
            if (label.Parent == firingGrid)
            {
                if (label.Background == Brushes.Blue)
                {
                    label.Background = Brushes.White;
                }
                else if (label.Background == Brushes.White)
                {
                    label.Background = Brushes.Red;
                }
                else if (label.Background == Brushes.Red)
                {
                    label.Background = Brushes.Blue;
                }
                location.Text = LocationAlphaNum(label);
            }
        }
        private void Label_MouseRightButtonDown(object sender, RoutedEventArgs e)
        {
            Label label = (Label)e.Source;
            if (label.Background == Brushes.Gray)
            {
                for (int i = 0; i < ships.Count; ++i)
                {
                    Label[] shipArray = ships[i];
                    if (ships[i].Contains(label))
                    {
                        foreach (Label l in shipArray)
                        {
                            if (l != null)
                            {
                                l.Background = Brushes.Blue;
                            }
                        }
                    }
                }
            }
        }


        private string LocationAlphaNum(Label label)
        {
            int col = Grid.GetColumn(label);
            char row = (char)Grid.GetRow(label); row += (char)64;
            string alphaNum = ""; alphaNum += row; alphaNum += col;
            return alphaNum;
        }
    }
}
