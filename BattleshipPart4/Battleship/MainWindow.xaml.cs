using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Battleship.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Battleship
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            InitializeFiringBoard();
            InitPlayerShipBoard();
        }
        #region Consts
        private const int MAX_SHIP_ARRAY = 121;
        private const int MAX_SHIP_SIZE = 5;
        private const int MAX_SPACES = 17;
        #endregion

        #region Arrays
        private Label[] playerShipBoard = new Label[121];
        private Label[] compShipBoard = new Label[121];
        private Label[] sepShipArray = new Label[MAX_SHIP_SIZE];
        private List<int> playShipLengths = new List<int>();
        private List<Label[]> playerShips = new List<Label[]>();
        private List<Label[]> compShips = new List<Label[]>();
        private List<Label> playerBoard = new List<Label>();
        #endregion

        #region Non-consts
        private Boards board = new Boards { AmountOfShips = 0, CompShipBoard = new string[121], CompShips = new List<string[]>(), Length = 2, MediumShip = false, PlayerBoard = new List<string>(), PlayerShipBoard = new string[121], PlayerShips = new List<string[]>(), PlayShipLengths = new List<int>(), Position = 0, SepShipArray = new string[MAX_SHIP_SIZE], StartGame = false };
        private int position = 0;
        private int  amountOfShips = 0;
        private bool startGame = false;
        private bool _playerTurn = true;
        #endregion

        #region Length Variables
        private int length = 2;
        private bool medium = false;
        #endregion

        private void Initializer()
        {
            RestartBoards();
            InitializeArrays();
        }
        private void InitializeArrays()
        {
            playerShipBoard = new Label[121];
            compShipBoard = new Label[121];
            sepShipArray = new Label[MAX_SHIP_SIZE];
            playShipLengths = new List<int>();

            position = 0;
            amountOfShips = 0;
            length = 2;
            startGame = false;
            medium = false;
        }
        private void InitializeFiringBoard()
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
                        label.Content = "Pt.3";
                        label.Name = "";
                    }
                    else if (i == 0 && j != 0)
                    {
                        label.Content = j;
                        label.Name = "";
                    }
                    else if (j == 0 && i != 0)
                    {
                        label.Content = colChar;
                        label.Name = "";
                    }
                    else
                    {
                        string location = "";
                        location += colChar;
                        location += j;
                        label.Content = location;
                        label.Background = Brushes.Blue;
                    }
                    AddLabel(label, i, j, true, true);
                }
            }
        }
        private void InitPlayerShipBoard()
        {
            int rows = playerShipGrid.RowDefinitions.Count;
            int cols = playerShipGrid.ColumnDefinitions.Count;

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    char colChar = (char)i; colChar += (char)64;

                    Label label = new Label();
                    if (i == 0 && j == 0)
                    {
                        label.Content = "Pt.3";
                        label.Name = "";
                    }
                    else if (i == 0 && j != 0)
                    {
                        label.Content = j;
                        label.Name = "";
                    }
                    else if (j == 0 && i != 0)
                    {
                        label.Content = colChar;
                        label.Name = "";
                    }
                    else
                    {
                        string location = "";
                        location += colChar;
                        location += j;
                        label.Content = location;
                        label.Name = location;
                        label.Background = Brushes.Blue;
                        playerShipBoard[position] = label;
                        board.PlayerShipBoard[board.Position] = label.Name;
                        position++;
                        board.Position++;
                    }
                    AddLabel(label, i, j, false, true);
                }
            }
        }
        private void InitCompShipBoard()
        {
            position = 0;
            board.Position = 0;
            int rows = compShipGrid.RowDefinitions.Count;
            int cols = compShipGrid.ColumnDefinitions.Count;

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    char colChar = (char)i; colChar += (char)64;

                    Label label = new Label();
                    if ((i == 0 && j == 0) || (i == 0 && j != 0) || (j == 0 && i != 0)) { label.Name = ""; }
                    else
                    {
                        string location = "";
                        location += colChar;
                        location += j;
                        label.Content = location;
                        label.Name = location;
                        label.Background = Brushes.Blue;
                        compShipBoard[position] = label;
                        board.CompShipBoard[board.Position] = label.Name;
                        position++;
                        board.Position++;
                    }
                    AddLabel(label, i, j, false, false);
                }
            }
        }
        private void RestartBoards()
        {
            for (int i = 0; i < MAX_SHIP_ARRAY; ++i)
            {
                if ((Grid.GetColumn(playerShipGrid.Children[i] as Label) != 0 && Grid.GetRow(playerShipGrid.Children[i] as Label) != 0) && 
                    (Grid.GetColumn(compShipGrid.Children[i] as Label) != 0 && Grid.GetRow(compShipGrid.Children[i] as Label) != 0) && 
                    (Grid.GetColumn(firingGrid.Children[i] as Label) != 0 && Grid.GetRow(firingGrid.Children[i] as Label) != 0))
                {
                    (playerShipGrid.Children[i] as Label).Background = Brushes.Blue;
                    (compShipGrid.Children[i] as Label).Background = Brushes.Blue;
                    (firingGrid.Children[i] as Label).Background = Brushes.Blue;
                }
            }
        }
        private void AddLabel(Label label, int row, int column, bool isFiringGrid, bool player)
        {
            label.BorderBrush = Brushes.Black;
            label.BorderThickness = new Thickness(1);
            if (row != 0 && column != 0) { label.MouseLeftButtonDown += Label_MouseLeftButtonDown; label.MouseRightButtonDown += Label_MouseRightButtonDown; label.MouseLeave += MainWindow_MouseLeave; }
            Grid.SetColumn(label, column);
            Grid.SetRow(label, row);
            if (isFiringGrid && player)
            {
                firingGrid.Children.Add(label);

            }
            else if (!isFiringGrid && player)
            {
                playerShipGrid.Children.Add(label);
                playerBoard.Add(label);
            }
            else if (!isFiringGrid && !player)
            {
                compShipGrid.Children.Add(label);
            }
        }
        private bool PlayerChanging
        {
            get { return _playerTurn; }
            set { _playerTurn = value; }
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
        private bool CheckPlayerLength(int length)
        {
            for (int i = 0; i < playShipLengths.Count; ++i)
            {
                if (length == playShipLengths[i])
                {
                    if (length == 3 && !medium)
                    {
                        medium = true;
                        board.MediumShip = true;
                        break;
                    }
                    return false;
                }
            }
            return true;
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
            if (!CheckPlayerLength(amountOfSpaces))
            {
                messageBlock.Text = "Ship length taken.";
                sepShipArray[0].Background = Brushes.Blue;
                sepShipArray = new Label[5];
                return false;
            }
            else
            {
                PlaceShip(choice, amountOfSpaces);
            }
            return true;
        }
        private bool DoesFit(Label label, int direction)
        {
            if (Grid.GetRow(label) != 0 && Grid.GetColumn(label) != 0)
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
            }
            return false;
        }
        private void PlaceShip(int choice, int amountOfSpaces)
        {
            bool successful = false;
            Label l;

            if (choice == (int)Enums.Direction.Up)
            {
                for (int i = 0; i < playerShipBoard.Count(); ++i)
                {
                    l = playerShipGrid.Children[i] as Label;
                    if (l.Name == sepShipArray[0].Name)
                    {
                        for (int j = 0; j < amountOfSpaces; ++j)
                        {
                            if (DoesFit(l, choice))
                            {
                                l = playerShipGrid.Children[i - (11 * j)] as Label;
                                sepShipArray[j] = l;
                                board.SepShipArray[j] = l.Name;
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
                for (int i = 0; i < playerShipBoard.Count(); ++i)
                {
                    l = playerShipGrid.Children[i] as Label;
                    if (l.Name == sepShipArray[0].Name)
                    {
                        for (int j = 0; j < amountOfSpaces; ++j)
                        {
                            if (DoesFit(l, choice))
                            {

                                l = playerShipGrid.Children[i + (11 * j)] as Label;
                                sepShipArray[j] = l;
                                board.SepShipArray[j] = l.Name;
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
                for (int i = 0; i < playerShipBoard.Count(); ++i)
                {
                    l = playerShipGrid.Children[i] as Label;
                    if (l.Name == sepShipArray[0].Name)
                    {
                        for (int j = 0; j < amountOfSpaces; ++j)
                        {
                            if (DoesFit(l, choice))
                            {
                                l = playerShipGrid.Children[i - j] as Label;
                                sepShipArray[j] = l;
                                board.SepShipArray[j] = l.Name;
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
                for (int i = 0; i < playerShipBoard.Count(); ++i)
                {
                    l = playerShipGrid.Children[i] as Label;
                    if (l.Name == sepShipArray[0].Name)
                    {
                        for (int j = 0; j < amountOfSpaces; ++j)
                        {
                            if (DoesFit(l, choice))
                            {
                                l = playerShipGrid.Children[i + j] as Label;
                                sepShipArray[j] = l;
                                board.SepShipArray[j] = l.Name;
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
            AddingShips(successful, true, amountOfSpaces);
        }
        private void AddingShips(bool successful, bool playerGrid, int amountOfSpaces)
        {
            int numNotNull = 0;
            foreach (Label shipLabels in sepShipArray)
            {
                if (shipLabels != null) { numNotNull += 1; }
                if (numNotNull == amountOfSpaces) { successful = true; }
                else { successful = false; }
            }
            if (successful)
            {
                foreach (Label shipLabels in sepShipArray)
                {
                    if (shipLabels == null)
                    {
                        break;
                    }
                    if (shipLabels.Background == Brushes.Gray && shipLabels != sepShipArray[0])
                    {
                        successful = false;
                    }
                }
            }

            if (successful)
            {
                for (int i = 0; i < sepShipArray.Length; ++i)
                {
                    if (sepShipArray[i] != null)
                    {
                        sepShipArray[i].Background = Brushes.Gray;
                    }
                }
                if (playerGrid) { playerShips.Add(sepShipArray); board.PlayerShips.Add(board.SepShipArray); }
                else { compShips.Add(sepShipArray); board.CompShips.Add(board.SepShipArray); }
                amountOfShips += 1;
                board.AmountOfShips += 1;
                if (length == 5)
                {
                    length = 3;
                    board.Length = 3;
                }
                else
                {
                    length += 1;
                    board.Length += 1;
                }
                playShipLengths.Add(amountOfSpaces);
                board.PlayShipLengths.Add(amountOfSpaces);
            }
            else
            {
                if (length == 3 && medium)
                {
                    medium = false;
                    board.MediumShip = false;
                }
                sepShipArray[0].Background = Brushes.Blue;
            }
            sepShipArray = new Label[MAX_SHIP_SIZE];
            board.SepShipArray = new string[MAX_SHIP_SIZE];
        }
        private void CompShip(int amountOfSpaces, int direction)
        {
            Label tempLabel = new Label();
            bool successful = false;

            if (direction == 1 || direction == 2)
            {
                for (int i = 0; i < compShipBoard.Count(); ++i)
                {
                    tempLabel = compShipGrid.Children[i] as Label;
                    if (tempLabel.Content == sepShipArray[0].Content)
                    {
                        if (direction == 1)
                        {
                            for (int j = 0; j < amountOfSpaces; ++j)
                            {
                                if (DoesFit(tempLabel, direction))
                                {
                                    if (i - (11 * j) > 0 && Grid.GetRow(tempLabel) != 0 && Grid.GetColumn(tempLabel) != 0)
                                    {
                                        tempLabel = compShipGrid.Children[i - (11 * j)] as Label;
                                        sepShipArray[j] = compShipGrid.Children[i - (11 * j)] as Label;
                                        board.SepShipArray[j] = (compShipGrid.Children[i - (11* j)] as Label).Name;
                                        successful = true;
                                    }
                                    else { successful = false; }
                                }
                                else { successful = false; }
                            }
                        }
                        else if (direction == 2)
                        {
                            for (int j = 0; j < amountOfSpaces; ++j)
                            {
                                if (DoesFit(tempLabel, direction))
                                {
                                    if (i + (11 * j) < MAX_SHIP_ARRAY && Grid.GetRow(tempLabel) != 0 && Grid.GetColumn(tempLabel) != 0)
                                    {
                                        tempLabel = compShipGrid.Children[i + (11 * j)] as Label;
                                        sepShipArray[j] = compShipGrid.Children[i + (11 * j)] as Label;
                                        board.SepShipArray[j] = (compShipGrid.Children[i + (11 * j)] as Label).Name;
                                        successful = true;
                                    }
                                    else { successful = false; }
                                }
                                else { successful = false; }
                            }
                        }
                    }
                }
            }
            else if (direction == 3 || direction == 4)
            {
                for (int i = 0; i < compShipBoard.Count(); ++i)
                {
                    tempLabel = compShipGrid.Children[i] as Label;
                    if (tempLabel.Content == sepShipArray[0].Content)
                    {
                        if (direction == 3)
                        {
                            for (int j = 0; j < amountOfSpaces; ++j)
                            {
                                if (DoesFit(tempLabel, direction))
                                {
                                    if (i - j > 0 && Grid.GetRow(tempLabel) != 0 && Grid.GetColumn(tempLabel) != 0)
                                    {
                                        tempLabel = compShipGrid.Children[i - j] as Label;
                                        sepShipArray[j] = compShipGrid.Children[i - j] as Label;
                                        board.SepShipArray[j] = (compShipGrid.Children[i - j] as Label).Name;
                                        successful = true;
                                    }
                                    else { successful = false; }
                                }
                                else { successful = false; }
                            }
                        }
                        else if (direction == 4)
                        {
                            for (int j = 0; j < amountOfSpaces; ++j)
                            {
                                if (DoesFit(tempLabel, direction))
                                {
                                    if (i + j < MAX_SHIP_ARRAY && Grid.GetRow(tempLabel) != 0 && Grid.GetColumn(tempLabel) != 0)
                                    {
                                        tempLabel = compShipGrid.Children[i + j] as Label;
                                        sepShipArray[j] = compShipGrid.Children[i + j] as Label;
                                        board.SepShipArray[j] = (compShipGrid.Children[i + j] as Label).Name;
                                        successful = true;
                                    }
                                    else { successful = false; }
                                }
                                else { successful = false; }
                            }
                        }
                    }
                }
            }
            AddingShips(successful, false, amountOfSpaces);
        }
        private void CompsShipsPlacement()
        {
            Random rand = new Random();
            int compStartingPoint = rand.Next(11, 121);
            Label firstlabel = compShipGrid.Children[compStartingPoint] as Label;

            if (Grid.GetRow(firstlabel) != 0 && Grid.GetColumn(firstlabel) != 0 && firstlabel.Background != Brushes.Gray)
            {
                sepShipArray[0] = firstlabel;
                board.SepShipArray[0] = firstlabel.Name;
                CompDirection(firstlabel);
            }
        }
        private void CompDirection(Label label)
        {
            Random rand = new Random();
            int amountOfSpaces = length;
            int direction = rand.Next(1, 5);
            CompShip(amountOfSpaces, direction);
        }
        private void Label_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Label label = (Label)e.Source;
            if (CheckShip() && label.Parent == playerShipGrid && label.Background != Brushes.Gray && amountOfShips != 5 && !startGame)
            {
                if (sepShipArray[0] == null)
                {
                    sepShipArray[0] = label;
                    board.SepShipArray[0] = label.Name;
                    label.Background = Brushes.Gray;
                }
                else
                {
                    if (ChooseDirection(label))
                    {
                        if (amountOfShips == 5)
                        {
                            amountOfShips = 0;
                            board.AmountOfShips = 0;

                            InitCompShipBoard();
                            length = 2;
                            board.Length = 2;
                            MessageBoxResult message = MessageBox.Show("Computer player will now place its ships!");
                            bool done = false;
                            while (!done)
                            {
                                CompsShipsPlacement();
                                if (amountOfShips == 5)
                                {
                                    done = true;
                                }
                            }
                            StartPlayer();
                        }
                    }
                }
            }
            if (label.Parent == firingGrid)
            {
                if (_playerTurn)
                {
                    for (int j = 0; j < compShips.Count; ++j)
                    {
                        foreach (Label compShipLabel in compShips[j])
                        {
                            if (compShipLabel != null)
                            {
                                int labelFireRow = Grid.GetRow(label);
                                int labelFireCol = Grid.GetColumn(label);
                                int labelCompShipRow = Grid.GetRow(compShipLabel);
                                int labelCompShipCol = Grid.GetColumn(compShipLabel);

                                if (label.Background == Brushes.Blue || label.Background == Brushes.White)
                                {
                                    if (label.Background == Brushes.White)
                                    {

                                    }
                                    label.Background = Brushes.White;
                                    if (labelFireRow == labelCompShipRow && labelFireCol == labelCompShipCol)
                                    {
                                        label.Background = Brushes.Red;
                                        compShipLabel.Background = Brushes.Red;
                                    }
                                }
                            }
                        }
                    }
                    if (label.Background == Brushes.Red)
                    {
                        PlayerChanging = true;
                        messageBlock.Text = "Player Hit!";
                    }
                    else if (label.Background == Brushes.White)
                    {
                        PlayerChanging = false;
                    }
                }
                WinMessage();

                messageBlock.Text = "Computer is thinking...";
                location.Text = LocationAlphaNum(label);
            }
        }
        private void Label_MouseRightButtonDown(object sender, RoutedEventArgs e)
        {
            int amountOfSpaces = 0;
            if (!startGame)
            {
                Label label = (Label)e.Source;
                if (label.Background == Brushes.Gray)
                {
                    for (int i = 0; i < playerShips.Count; ++i)
                    {
                        Label[] shipArray = playerShips[i];
                        if (playerShips[i].Contains(label))
                        {
                            foreach (Label l in shipArray)
                            {
                                if (l != null)
                                {
                                    amountOfSpaces++;
                                    l.Background = Brushes.Blue;
                                    sepShipArray = new Label[MAX_SHIP_SIZE];
                                    board.SepShipArray = new string[MAX_SHIP_SIZE];
                                }
                            }
                        }
                    }
                    amountOfShips -= 1;
                    board.AmountOfShips -= 1;
                }
            }
            for (int i = 0; i < playShipLengths.Count; ++i)
            {
                if (playShipLengths[i] == amountOfSpaces)
                {
                    playShipLengths.Remove(amountOfSpaces);
                    board.PlayShipLengths.Remove(amountOfSpaces);
                }
            }
        }
        private void NameButton_Click(object sender, RoutedEventArgs e)
        {
            if (userName.Visibility == Visibility.Hidden && mainGrid.Visibility == Visibility.Hidden)
            {
                if (namePrompt.Text == "")
                {
                    namePrompt.Text = "User";
                }
                userName.Content = namePrompt.Text + "'s Board";1
                userName.Visibility = Visibility.Visible;
                mainGrid.Visibility = Visibility.Visible;
                tempPanel.Visibility = Visibility.Collapsed;
                MessageBoxResult message = MessageBox.Show(namePrompt.Text + ", please place your ships!");
            }
        }
        private void MainWindow_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!_playerTurn)
            {
                CompTurn();
            }
        }
        private void WinMessage()
        {
            bool winner = false;
            string message = "";

            if (CheckCompShips() && !CheckPlayerShips())
            {
                message = "Computer";
                winner = true;
            }
            else if (!CheckCompShips() && CheckPlayerShips())
            {
                message = namePrompt.Text;
                winner = true;
            }
            if (winner)
            {
                MessageBoxResult winMessage = MessageBox.Show(message + " WINS!");
                Restart();
            }
        }
        private void Restart()
        {
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult message = MessageBox.Show("Would you like to play again?", "Restart Option", button);

            if (message == MessageBoxResult.Yes)
            {
                Initializer();
            }
            else if (message == MessageBoxResult.No)
            {
                Application.Current.Shutdown();
            }
        }
        private void CompTurn()
        {
            messageBlock.Text = "Please click coordinate.";
            Thread.Sleep(1000);

            Random rand = new Random();
            int compChoice = rand.Next(1, 121);
            Label compLabel = playerBoard[compChoice] as Label;

            if (compLabel.Background == Brushes.Gray)
            {
                compLabel.Background = Brushes.Red;

                messageBlock.Text = "Computer Hit!";
                PlayerChanging = false;
                CompTurn();
            }
            else if (compLabel.Background == Brushes.Red || compLabel.Background == Brushes.White)
            {

                PlayerChanging = false;
                CompTurn();
            }
            else if (compLabel.Background == Brushes.Blue)
            {
                compLabel.Background = Brushes.White;
                PlayerChanging = true;
            }
        }
        private bool CheckCompShips()
        {
            bool compWin = false;
            int counter = 0;
            for (int i = 0; i < playerShips.Count; ++i)
            {
                foreach (Label l in playerShips[i])
                {
                    if (l != null)
                    {
                        if (l.Background == Brushes.Red)
                        {
                            compWin = true;
                            counter++;
                        }
                        else
                        {
                            compWin = false;
                        }
                    }
                }
            }
            if (compWin && counter == MAX_SPACES)
            {
                return true;
            }
            return false;
        }
        private bool CheckPlayerShips()
        {
            bool playerWin = false;
            int counter = 0;
            for (int i = 0; i < compShips.Count; ++i)
            {
                foreach (Label l in compShips[i])
                {
                    if (l != null)
                    {
                        if (l.Background == Brushes.Red)
                        {
                            playerWin = true;
                            counter++;
                        }
                        else
                        {
                            playerWin = false;
                        }
                    }
                }
            }
            if (playerWin && counter == MAX_SPACES)
            {
                return true;
            }
            return false;
        }
        private void StartPlayer()
        {
            Random rand = new Random();
            int starter = rand.Next(1, 3);
            MessageBoxResult message;

            startGame = true;
            board.StartGame = true;
            if (starter == 1)
            {
                message = MessageBox.Show(namePrompt.Text + ", it is your turn first!");
                _playerTurn = true;
            }
            else if (starter == 2)
            {
                message = MessageBox.Show("It is the Computer's turn first!");
                _playerTurn = false;
            }
        }
        private string LocationAlphaNum(Label label)
        {
            int col = Grid.GetColumn(label);
            char row = (char)Grid.GetRow(label); row += (char)64;
            string alphaNum = ""; alphaNum += row; alphaNum += col;
            return alphaNum;
        }

        private void subNew_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == subNew)
            {
                if (startGame)
                {
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxResult message = MessageBox.Show("Would you like to save?", "Save?", button);

                    if (message == MessageBoxResult.Yes)
                    {
                        e.Source = subSave;
                    }
                    else if (message == MessageBoxResult.No)
                    {
                        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                        Application.Current.Shutdown();
                    }
                }
                else
                {
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
                
            }
            else if (e.Source == subOpen)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                IFormatter form = new BinaryFormatter();
                fileDialog.Multiselect = false;

                fileDialog.Filter = "Waffle Files (*.waffle) | *.waffle;";

                if(fileDialog.ShowDialog() == true)
                {
                    Stream fileStream = new FileStream(fileDialog.FileName, FileMode.Open);
                    board = (Boards)form.Deserialize(fileStream);
                    
                    fileStream.Close();
                }
            }
            else if (e.Source == subSave || e.Source == subSaveAs)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                IFormatter form = new BinaryFormatter();
                fileDialog.Filter = "Waffle Files (*.waffle) | *.waffle;";
                if (e.Source == subSave)
                {
                    if (fileDialog.FileName == "")
                    {
                        e.Source = subSaveAs;
                    }
                    else
                    {
                        Stream fileStream = new FileStream(fileDialog.FileName, FileMode.Open);
                        form.Serialize(fileStream, board);
                        fileStream.Close();
                    }
                }
                else if (e.Source == subSaveAs)
                {
                    if (fileDialog.ShowDialog() == true) 
                    { 
                        Stream fileStream = new FileStream(fileDialog.FileName, FileMode.Create);
                        form.Serialize(fileStream, board);
                        fileStream.Close();
                    }
                }
            }
            else if(e.Source == subExit)
            {
                if (startGame)
                {
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxResult message = MessageBox.Show("Would you like to save?", "Save?", button);

                    if (message == MessageBoxResult.Yes)
                    {
                        e.Source = subSave;
                    }
                    else if (message == MessageBoxResult.No)
                    {
                        Application.Current.Shutdown();
                    }
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
        }
        private void ReOpen(Boards board)
        {
            position = board.Position;
            amountOfShips = board.AmountOfShips;
            length = board.Length;
            startGame = board.StartGame;
            medium = board.MediumShip;
            for (int i = 0; i < playerShipBoard.Count(); ++i)
            {
                if (Grid.GetRow(playerShipBoard[i]) != 0 && Grid.GetColumn(playerShipBoard[i]) != 0 &&
                    Grid.GetRow(compShipBoard[i]) != 0 && Grid.GetColumn(compShipBoard[i]) != 0)
                {
                    playerShipBoard[i].Name = board.PlayerShipBoard[i];
                    compShipBoard[i].Name = board.CompShipBoard[i];
                    
                }
            }
            if (board.SepShipArray != null)
            {
                for (int i = 0; i < board.SepShipArray.Count(); ++i) 
                {
                    sepShipArray[i].Name = board.SepShipArray[i];
                }
            }
            if (board.PlayShipLengths != null)
            {
                for (int i = 0; i < board.PlayShipLengths.Count(); ++i)
                {
                    playShipLengths[i] = board.PlayShipLengths[i];
                }
            }
            if (board.PlayerShips != null)
            {
                string[] names = new string[MAX_SPACES];
                playerShips = new List<Label[]>();
                for (int i = 0; i < board.PlayerShips.Count(); ++i)
                {
                    foreach(string s in board.PlayerShips[i])
                    {

                    }
                }
            }
        }
    }
}
