using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_02_Chess_Depiction.Enum;

namespace Lab_02_Chess_Depiction.Utilities
{
    public class StringTo
    {
        public static ChessTypes ToEnum(string input)
        {
            ChessTypes piece = ChessTypes.Empty;
            if (input == " " || input == "--")
            {
                piece = ChessTypes.Empty;
            }
            else if (input == "K" || input == "King")
            {
                piece = ChessTypes.King;
            }
            else if (input == "Q" || input == "Queen")
            {
                piece = ChessTypes.Queen;
            }
            else if (input == "B" || input == "Bishop")
            {
                piece = ChessTypes.Bishop;
            }
            else if (input == "R" || input == "Rook")
            {
                piece = ChessTypes.Rook;
            }
            else if (input == "P" || input == "Pawn" || input == "")
            {
                piece = ChessTypes.Pawn;
            }
            else if (input == "N" || input == "Knight")
            {
                piece = ChessTypes.Knight;
            }
            return piece;
        }
    }
}
