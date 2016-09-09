using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab_01_Chess_Translation
{
    public class Program
    {

        #region Patterns
        private string placementPattern = @"^\s*([RQKPNB])([ld])([a-h])([1-8])$";
        private string movementPattern = @"^\s*([RQKNB])?([a-h])([1-8])([-x])([a-h])([1-8])([+#])?\s*([RQKNB])?([a-h])([1-8])([-x])([a-h])([1-8])([+#])?$";
        private string castlingPattern = @"^\s*(O\-O)\s*(O\-O\-O)|\s*(O\-O\-O)\s*(O\-O)$";
        private string halfMovementPattern = "([RQKNB])?([a-h])([1-8])([-x])([a-h])([1-8])([+#])?$";
        private string halfCastlingPattern = @"([O][-][O](-O)?$)";
        private string halfCastlingPattern2 = @"([O][-][O](-O)?)";
        #endregion

        public static void Main(string[] args)
        {
            if(args.Length < 0)
            {
                args[0] = "..\\..\\Data\\Lab01.b.chess";
            }
            StreamReader file = new StreamReader(args[0]);

            Program p = new Program();
            Console.WriteLine("Hello from Chess Translator!\n\n");
            Console.WriteLine("File: " + args[0] + " \n\n ---------------------- \n");
            p.ChessTranslation(file);
        }
        public void ChessTranslation(StreamReader fileName)
        {
            string line = "";

            while ((line = fileName.ReadLine()) != null)
            {
                
                Match comment = Regex.Match(line, @"(\s+)?(\/+).*");

                if (comment.Success)
                {
                    line = line.Remove(comment.Groups[1].Index);
                }

                #region ChessTranslation Regex
                Match placement = Regex.Match(line, placementPattern);
                Match movement = Regex.Match(line, movementPattern);
                Match castling = Regex.Match(line, castlingPattern);
                Match halfMovement = Regex.Match(line, halfMovementPattern);
                Match halfCastling = Regex.Match(line, halfCastlingPattern);
                Match halfCastling2 = Regex.Match(line, halfCastlingPattern2);
                #endregion

                if (placement.Success)
                {
                    string placementFinsihed = String.Format("[{0,-7}]  {1} {2} was place at {3}{4}", WhitespaceRemover(placement.Groups[0].Value), CheckPiece(placement.Groups[1].Value), CheckColor(placement.Groups[2].Value), placement.Groups[3].Value, placement.Groups[4].Value);
                    Console.WriteLine(placementFinsihed);
                }
                else if (movement.Success || castling.Success || (halfCastling.Success && !castling.Success) || (halfMovement.Success && !movement.Success))
                {
                    CheckFirstAction(line);
                }
                else
                {
                    if (!castling.Success && halfCastling2.Success)
                    {
                        CheckFirstAction(line);
                    }
                    else if (!placement.Success && line != "")
                    {
                        string actionFinished = String.Format("[{0,-7}]  Skipping [{1}]", "Warning", line);

                        Console.WriteLine(actionFinished);
                    }
                }
            }
            fileName.Close();
        }   

        public string CheckColor(string character)
        {
            if(character == "l")
            {
                character = "White";
            }
            else if(character == "d")
            {
                character = "Black";
            }
            else
            {
                character = "null";
            }
            return character;
        }       
        public string WhitespaceRemover(string input)
        {
            Match newInput = Regex.Match(input, @"[\S]+");
            return newInput.Value;
        }

        public void CheckFirstAction(string line)
        {
            int counter = 0;
            int breakPoint = 0;

            foreach (char c in line)
            {
                if(c == '\t' || c == '\n' || c == ' ')
                {
                    breakPoint = counter;
                }
                counter++;
            }

            string firstString = line.Substring(1, breakPoint);
            firstString = WhitespaceRemover(firstString);

            Match subFirstMovement = Regex.Match(firstString, halfMovementPattern);
            Match subFirstCastling = Regex.Match(firstString, halfCastlingPattern);

            if (subFirstMovement.Success)
            {
                CheckMove(subFirstMovement, true);
                CheckSecondAction(line, breakPoint);
            }
            else if (subFirstCastling.Success)
            {
                string colorType = "";

                if (firstString == subFirstCastling.Groups[1].Value)
                {
                    colorType = "K";
                }
                else if (firstString == subFirstCastling.Groups[2].Value)
                {
                    colorType = "Q";
                }
                string actionFinished = String.Format("[{0,-7}]  White castles {1} side", firstString, CheckPiece(colorType));
                Console.WriteLine(actionFinished);
                CheckSecondAction(line, breakPoint);
            }   
            else
            {
                if (line != "")
                {
                    string actionFinished = String.Format("[{0,-7}]  Skipping [{1}]", "Warning", line);

                    Console.WriteLine(actionFinished);
                }
            }
        }
        public void CheckSecondAction(string line, int breakPoint)
        {
            string secondString = line.Substring(breakPoint);
            secondString = WhitespaceRemover(secondString);

            Match subSecondMovement = Regex.Match(secondString, halfMovementPattern);
            Match subSecondCastling = Regex.Match(secondString, halfCastlingPattern);

            if (subSecondMovement.Success)
            {
                CheckMove(subSecondMovement, false);
            }
            else if (subSecondCastling.Success)
            {
                string colorType = "";

                if (secondString == subSecondCastling.Groups[1].Value)
                {
                    colorType = "Q";
                }
                else if (secondString == subSecondCastling.Groups[2].Value)
                {
                    colorType = "K";
                }
                string actionFinished = String.Format("[{0,-7}]  Black castles {1} side", secondString, CheckPiece(colorType));
                Console.WriteLine(actionFinished);
            }
            else
            {
                if (line != "")
                {
                    string actionFinished = String.Format("[{0,-7}]  Expected Black's response, got ({1})", "Error", secondString);
                    Console.WriteLine(actionFinished);
                }
            }
        }

        public string CheckPiece(string name)
        {
            string pieceName = "";
            if (name == "K") 
            {
                pieceName = "King";
            }
            else if (name == "Q")
            {
                pieceName = "Queen";
            }
            else if (name == "B")
            {
                pieceName = "Bishop";
            }
            else if (name == "R")
            {
                pieceName = "Rook";
            }
            else if (name == "N")
            {
                pieceName = "Knight";
            }
            else if (name == "" || name == "P")
            {
                pieceName = "Pawn";
            }
            return pieceName;
        }

        public string CheckAction(string action)
        {
            string actionString = "";

            if (action == "-")
            {
                actionString = ". ";
            }
            else if (action == "x")
            {
                actionString = ", Capturing opponent's piece. ";
            }
            else if (action == "+")
            {
                actionString = " Check!";
            }
            else if (action == "#")
            {
                actionString = " Checkmate!";
            }

            return actionString;
        }

        public string CheckMove(Match movement, bool turn)
        {
            string move = "";
            string piece = movement.Groups[1].Value;
            string firstRank = movement.Groups[2].Value;
            string firstFile = movement.Groups[3].Value;
            string action = movement.Groups[4].Value;
            string secondRank = movement.Groups[5].Value;
            string secondFile = movement.Groups[6].Value;
            string check = movement.Groups[7].Value;
            string color = "";

            if (turn)
            {
                color = "White";
            }
            else
            {
                color = "Black";
            }

            if (movement.Success)
            {
                string actionFinished = String.Format("[{0,-7}]  {1} moves {2} at {3}{4} to {5}{6}{7}{8}", movement.Value, color, CheckPiece(piece), firstRank, firstFile, secondRank, secondFile, CheckAction(action), CheckAction(check));
                Console.WriteLine(actionFinished);
            }
            return move;
        }
        
    }
}
