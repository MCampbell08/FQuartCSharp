using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.LabClasses
{
    public class PieceMovement : Depict
    {
        private bool PawnMovement(string piece, string color, int oldFile, int oldRank, int newFile, int newRank, string action, bool hasMoved = false)
        {

            //
            //NUMBERS NOT MATCHING
            //

            int changedFirOldFile = oldFile + 1;
            int changedSecOldFile = oldFile + 2;

            if (piece == "Pawn" || piece == "")
            {
                if (color == "White")
                {
                    if (action == "-")
                    {
                        if (!hasMoved)
                        {
                            if ((newFile == changedSecOldFile && (chessBoard[newFile, oldRank] == "__")))
                            {
                                return true;
                            }
                            else if ((newFile == changedFirOldFile && (chessBoard[newFile, oldRank] == "__")))
                            {
                                return true;
                            }
                        }
                        else if (hasMoved)
                        {
                            if ((newFile == (oldFile += 1) && (chessBoard[newFile += 1, oldRank] == "__")))
                            {
                                return true;
                            }
                        }
                    }
                    else if (action == "x")
                    {
                        if (((newRank == (oldRank -= 1) && newFile == (oldFile -= 1)) || (newRank == (oldRank -= 1) && newFile == (oldFile += 1)) && chessBoard[newRank, newFile] != "__"))
                        {
                            return true;
                        }
                    }
                }
                else if (color == "Black")
                {
                    if (action == "-")
                    {
                        if (!hasMoved)
                        {
                            if((newRank == (oldRank -= 2) && (chessBoard[oldRank -= 2, oldFile] == "__")))
                            {
                                return true;
                            }
                        }
                        else if (hasMoved)
                        {

                            if ((newRank == (oldRank -= 1) && (chessBoard[oldRank -= 1, oldFile] == "__")))
                            {
                                return true;
                            }
                        }
                    }
                    else if (action == "x")
                    {
                        if (((newRank == (oldRank -= 1) && newFile == (oldFile -= 1)) || (newRank == (oldRank -= 1) && newFile == (oldFile += 1)) && chessBoard[newRank, newFile] != "__"))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool CheckMovement(string piece, string color, int oldFile, int oldRank, int newFile, int newRank, string action, bool hasMoved = false)
        {            
            if (PawnMovement(piece, color, oldFile, oldRank, newFile, newRank, action, hasMoved))
            {
                return true;
            }
            else if (piece == "King")
            {
                if (color == "White")
                {

                }
                else if (color == "Black")
                {
                    
                }
            }
            else if (piece == "Queen")
            {
                if (color == "White")
                {

                }
                else if (color == "Black")
                {

                }
            }
            else if (piece == "Rook")
            {
                if (color == "White")
                {
                    
                }
                else if (color == "Black")
                {
                    
                }
            }
            else if (piece == "Bishop")
            {
                if (color == "White")
                {

                }
                else if (color == "Black")
                {

                }
            }
            else if (piece == "Knight")
            {
                if (color == "White")
                {
                    
                }
                else if (color == "Black")
                {
                    
                }
            }
            return false;
        }
    }
}
