﻿using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour
{
    public bool isWhite;
    public bool isKing;

    public bool IsForceToMove(Piece[,] board, int x, int y)
    {
        //Top left
        if(isWhite || isKing)
        {
            if (x >= 2 && y <= 5)
            {
                Piece p = board[x - 1, y + 1];
                //If there is a piece, and it is not the same color as ours

                if (p != null && p.isWhite != isWhite)
                {
                    // CHeck if its possible to land after jump
                    if (board[x - 2, y + 2] == null)
                    {
                        return true;
                    }
                }
            }

            //Top Right
            if (x <= 5 && y <= 5)
            {
                Piece p = board[x + 1, y + 1];
                //If there is a piece, and it is not the same color as ours

                if (p != null && p.isWhite != isWhite)
                {
                    // CHeck if its possible to land after jump
                    if (board[x + 2, y + 2] == null)
                    {
                        return true;
                    }
                }
            }
        }
        
        if(!isWhite || isKing)
        {
            // Bot Left
            if (x >= 2 && y >= 2)
            {
                Piece p = board[x - 1, y - 1];
                //If there is a piece, and it is not the same color as ours

                if (p != null && p.isWhite != isWhite)
                {
                    // CHeck if its possible to land after jump
                    if (board[x - 2, y - 2] == null)
                    {
                        return true;
                    }
                }
            }

            //Bot  Right
            if (x <= 5 && y >= 2)
            {
                Piece p = board[x + 1, y - 1];
                //If there is a piece, and it is not the same color as ours

                if (p != null && p.isWhite != isWhite)
                {
                    // CHeck if its possible to land after jump
                    if (board[x + 2, y - 2] == null)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
        

    }
    public bool ValidMove(Piece[,] board, int x1, int y1, int x2, int y2)
    {
        //if you are moving on top of another piece....illegal move
        if (board[x2,y2] != null)
        {
            return false;
        }

        int deltaMove = Mathf.Abs(x1 - x2);
        int deltaMoveY = (y2 - y1);  
        if (isWhite || isKing)
        {
            if (deltaMove == 1)
            {
                //normal move
                if (deltaMoveY == 1)
                {
                    return true;
                }
            }
             else if (deltaMove == 2)
            {
                //kill jump
                 if (deltaMoveY == 2)
                {
                    Piece p = board[((x1 + x2) / 2), (y1 + y2) / 2];
                    if (p != null && p.isWhite != isWhite)
                    {
                        return true;
                    }
                }
            }
        }

        if (!isWhite || isKing)
        {
            if (deltaMove == 1)
            {
                //normal move
                if (deltaMoveY == -1)
                {
                    return true;
                }
            }
            else if (deltaMove == 2)
            {
                //kill jump
                if (deltaMoveY == -2)
                {
                    Piece p = board[((x1 + x2) / 2), (y1 + y2) / 2];
                    if (p != null && p.isWhite != isWhite)
                    {
                        return true;
                    }
                }
            }
        }
        return false; //invalid move
    } 
}
