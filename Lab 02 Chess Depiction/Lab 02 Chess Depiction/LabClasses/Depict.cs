using System;
using System.IO;
using Lab_02_Chess_Depiction.Enum;
using Lab_02_Chess_Depiction.Models;
using Lab_02_Chess_Depiction.Utilities;

namespace Lab_02_Chess_Depiction.Depiction
{
    public class Depict
    {
        protected string[,] chessBoard = new string[8, 8];

        #region Castling Variables
        private int whiteKingRowLoc = 0;
        private int whiteKingColLoc = 0;
        private int blackKingRowLoc = 0;
        private int blackKingColLoc = 0;

        private int[] whiteRookQSide = new int[2];
        private int[] whiteRookKSide = new int[2];
        private int[] blackRookQSide = new int[2];
        private int[] blackRookKSide = new int[2];
        #endregion

        public void AddPlacement(string piece, string color, string rank, string file)
        {
            ChessTypes pieceType = StringTo.ToEnum(piece);
            char charRank = char.Parse(rank);
            charRank -= (char)48;
            string output = BoardPiece(pieceType, color);
            int newFile = Int32.Parse(file);
            int newRank = Int32.Parse(charRank.ToString());
            chessBoard[newFile - 1, newRank - 1] = output;
            Board();
        }

        public void AddMovement(string piece, string color, string oldRank, string oldFile, string newRank, string newFile, string action)
        {
            char charRawOld = char.Parse(oldRank); charRawOld -= (char)48;
            char charRawNew = char.Parse(newRank); charRawNew -= (char)48;
            ChessTypes pieceType = StringTo.ToEnum(piece);
            string output = BoardPiece(pieceType, DefineColor.ColorDefined(color));
            int parsedOldFile = Int32.Parse(oldFile);
            int parsedOldRank = Int32.Parse(charRawOld.ToString());
            int parsedNewFile = Int32.Parse(newFile);
            int parsedNewRank = Int32.Parse(charRawNew.ToString());

            if (chessBoard[parsedOldFile - 1, parsedOldRank - 1] != BoardPiece(ChessTypes.Empty))
            {
                if (action == "x")
                {
                    if (chessBoard[parsedNewFile - 1, parsedNewRank - 1] != BoardPiece(ChessTypes.Empty))
                    {
                        chessBoard[parsedNewFile - 1, parsedNewRank - 1] = output;
                        chessBoard[parsedOldFile - 1, parsedOldRank - 1] = BoardPiece(pieceType);
                    }
                    else
                    {
                        string incMove = String.Format("[{0,-7}]    Cannot move to this piece if capturing.", "Error");
                        Console.WriteLine(incMove);
                    }
                }
                else if (action == "-")
                {
                    if (chessBoard[parsedNewFile - 1, parsedNewRank - 1] == BoardPiece(ChessTypes.Empty))
                    {
                        chessBoard[parsedNewFile - 1, parsedNewRank - 1] = output;
                        chessBoard[parsedOldFile - 1, parsedOldRank - 1] = BoardPiece(pieceType);
                    }
                    else
                    {
                        string incMove = String.Format("[{0,-7}]    Cannot move to this piece if not capturing.", "Error");
                        Console.WriteLine(incMove);
                    }
                }
            }
            else
            {
                string incMove = String.Format("[{0,-7}]    Cannot move empty piece, Skipping.", "Error");
                Console.WriteLine(incMove);
            }
            Board();
        }

        public void AddCastling(string line, string color, string piece) 
        {
            if (CheckCastling(piece, color))
            {
                if (color == "White")
                {
                    if(line == "O-O-O") //Queen
                    {
                        chessBoard[0, 4] = "__";
                        chessBoard[0, 0] = "__";
                        chessBoard[0, 2] = "KL";
                        chessBoard[0, 3] = "RL";
                    }
                    else if (line == "O-O") //King
                    {
                        chessBoard[0, 4] = "__";
                        chessBoard[0, 7] = "__";
                        chessBoard[0, 6] = "KL";
                        chessBoard[0, 5] = "RL";
                    }
                }
                else if (color == "Black")
                {
                    if (line == "O-O-O") //Queen
                    {
                        chessBoard[7, 4] = "__";
                        chessBoard[7, 0] = "__";
                        chessBoard[7, 2] = "KL";
                        chessBoard[7, 3] = "RL";
                    }
                    else if (line == "O-O") //King
                    {
                        chessBoard[7, 4] = "__";
                        chessBoard[7, 7] = "__";
                        chessBoard[7, 6] = "KL";
                        chessBoard[7, 5] = "RL";
                    }
                }
                Board();
            }
        }

        public void BoardInit()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    chessBoard[i, j] = BoardPiece(ChessTypes.Empty);
                }
            }
        }

        public bool CheckCastling(string piece, string color)
        {
            string strCheck = "";
            bool rookFound = false;
            bool canCount = false;
            int counter = 0;
            if (color == "White")
            {
                if (piece == "King")
                {
                    if ((whiteKingRowLoc == 0 && whiteKingColLoc == 4) && (whiteRookKSide[0] == 7 && whiteRookKSide[1] == 0))
                    {
                        for (int i = 0; i < 7; ++i)
                        {
                            for (int j = 0; j < 7; ++j)
                            {
                                strCheck = chessBoard[i, j];
                                if (strCheck == chessBoard[0, 4])
                                {
                                    canCount = true;
                                }
                                if (strCheck == "__")
                                {
                                    if (canCount)
                                    {
                                        counter++;
                                    }
                                }
                                else { return false; }

                                if (rookFound)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                else if (piece == "Queen")
                {
                    if ((whiteKingRowLoc == 0 && whiteKingColLoc == 4) && (whiteRookQSide[0] == 0 && whiteRookQSide[1] == 0))
                    {
                        for (int i = 0; i < 7; ++i)
                        {
                            for (int j = 0; j < 7; ++j)
                            {
                                strCheck = chessBoard[i, j];
                                if(strCheck == chessBoard[0, 0])
                                {
                                    rookFound = true;
                                }
                                else if(strCheck == chessBoard[0,4])
                                {
                                    return true;                   
                                }
                                if (rookFound && strCheck != "__")
                                {
                                    return false;
                                }
                                if (rookFound)
                                {
                                    counter++;
                                }
                            }
                        }
                    }
                }
            }
            else if (color == "Black")
            {
                if (piece == "King")
                {
                    if ((blackKingRowLoc == 7 && blackKingColLoc == 4) && (blackRookKSide[0] == 7 && whiteRookKSide[1] == 7))
                    {
                        for (int i = 0; i < 7; ++i)
                        {
                            for (int j = 0; j < 7; ++j)
                            {
                                strCheck = chessBoard[i, j];
                                if (strCheck == chessBoard[7, 4])
                                {
                                    canCount = true;
                                }

                                if (strCheck == "__")
                                {
                                    if (canCount)
                                    {
                                        counter++;
                                    }
                                }
                                else { return false; }

                                if (rookFound)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                else if (piece == "Queen")
                {
                    if ((blackKingRowLoc == 7 && blackKingColLoc == 4) && (blackRookQSide[0] == 0 && blackRookQSide[1] == 7))
                    {
                        for (int i = 0; i < 7; ++i)
                        {
                            for (int j = 0; j < 7; ++j)
                            {
                                strCheck = chessBoard[i, j];
                                if (strCheck == chessBoard[7, 0])
                                {
                                    rookFound = true;
                                }
                                else if (strCheck == chessBoard[7, 4])
                                {
                                    return true;
                                }
                                if (rookFound && strCheck != "__")
                                {
                                    return false;
                                }
                                else if (rookFound && strCheck == "__")
                                {
                                    counter++;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void SetCastlingPosition(string output, int file, int rank)
        {
            if (output == "KL")
            {
                whiteKingRowLoc = rank;
                whiteKingColLoc = file;
            }
            else if (output == "kd")
            {
                blackKingRowLoc = rank;
                blackKingColLoc = file;
            }
            else if (output == "rd" && file == 7 && rank == 7)
            {
                blackRookKSide[0] = file;
                blackRookKSide[1] = rank;
            }
            else if (output == "rd" && file == 0 && rank == 7)
            {
                blackRookQSide[0] = file;
                blackRookQSide[1] = rank;
            }
            else if (output == "RL" && file == 0 && rank == 0)
            {
                whiteRookQSide[0] = file;
                whiteRookQSide[1] = rank;
            }
            else if (output == "RL" && file == 7 && rank == 0)
            {
                whiteRookKSide[0] = file;
                whiteRookKSide[1] = rank;
            }
        }

        public void Board()
        {
            int rank = chessBoard.Length / 8;
            int file = 0;
            char temp = char.Parse(file.ToString());
            temp += (char)17;

            Console.WriteLine(" -----------------------------------------");
            for (int i = 8; i > 0; i--)
            {
                Console.Write(rank-- + "| ");
                for (int j = 0; j < 8; j++)
                {
                    string output = chessBoard[rank, j];
                    SetCastlingPosition(output, j, rank);

                    Console.Write(output);

                    if (j != 7) { Console.Write(" | "); }
                    else { Console.Write(" |"); }
                }
                Console.WriteLine("\n -----------------------------------------");
            }
            Console.Write(" ");
            for (int k = 0; k < 8; k++)
            {
                Console.Write("  " + (temp++) + "  ");
            }
            Console.Write("\n\n");
        }
        public static string BoardPiece(ChessTypes piece, string color = "")
        {
            string output = "";
            if (color != "d" && color != "l")
            {
                piece = ChessTypes.Empty;
            }
            if (piece != ChessTypes.Empty)
            {
                switch (piece)
                {
                    case ChessTypes.King:
                        {
                            output = "K";
                            break;
                        }
                    case ChessTypes.Queen:
                        {
                            output = "Q";
                            break;
                        }
                    case ChessTypes.Bishop:
                        {
                            output = "B";
                            break;
                        }
                    case ChessTypes.Rook:
                        {
                            output = "R";
                            break;
                        }
                    case ChessTypes.Knight:
                        {
                            output = "N";
                            break;
                        }
                    case ChessTypes.Pawn:
                        {
                            output = "P";
                            break;
                        }
                }
                output += color;
                if (output.Contains("d"))
                {
                    output = output.ToLower();
                }
                else if (output.Contains("l"))
                {
                    output = output.ToUpper();
                }

            }
            else
            {
                output = "__";
            }

            return output;
        }
    }
}
