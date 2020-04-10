using System;
using System.Collections.Generic;
using System.Data.Common;

namespace ConsoleApplication1
{
    /*
 [
   ["5","3",".",".","7",".",".",".","."],
   ["6",".",".","1","9","5",".",".","."],
   [".","9","8",".",".",".",".","6","."],
   ["8",".",".",".","6",".",".",".","3"],
   ["4",".",".","8",".","3",".",".","1"],
   ["7",".",".",".","2",".",".",".","6"],
   [".","6",".",".",".",".","2","8","."],
   [".",".",".","4","1","9",".",".","5"],
   [".",".",".",".","8",".",".","7","9"]
 ]
 [
   ["5","3","4","6","7","8","9","1","2"],
   ["6","7","2","1","9","5","3","4","8"],
   ["1","9","8","3","4","2","5","6","7"],
   ["8","5","9","7","6","1","4","2","3"],
   ["4","2","6","8","5","3","7","9","1"],
   ["7","1","3","9","2","4","8","5","6"],
   ["9","6","1","5","3","7","2","8","4"],
   ["2","8","7","4","1","9","6","3","5"],
   ["3","4","5","2","8","6","1","7","9"]
 ]
 * 
 */

    public class suduko
    {
        private int[] numPool = new int[10];
        private bool[,] rowRecord = new bool[9, 10];
        private bool[,] reelRecord = new bool[9, 10];
        private bool[,] matrixRecord = new bool[9, 10];
        private char[][] boardRef;
        private bool bSolved = false;

        private static int CastReelRow2MatrixIndex(int row, int reel)
        {
            return row / 3 * 3 + reel / 3;
        }

        private void Input(int row, int reel, int num)
        {
            numPool[num]--;
            rowRecord[row, num] = true;
            reelRecord[reel, num] = true;
            matrixRecord[CastReelRow2MatrixIndex(row, reel), num] = true;
            boardRef[row][reel] = (char) (num + '0');
        }

        private void Erase(int row, int reel)
        {
            if (boardRef[row][reel] == '.')
            {
                return;
            }

            int num = (int) Char.GetNumericValue(boardRef[row][reel]);
            numPool[num]++;
            rowRecord[row, num] = false;
            reelRecord[reel, num] = false;
            matrixRecord[CastReelRow2MatrixIndex(row, reel), num] = false;
            boardRef[row][reel] = '.';
        }

        private bool CouldInput(int row, int reel, int num)
        {
            return numPool[num] > 0 && !rowRecord[row, num] && !reelRecord[reel, num] &&
                   !matrixRecord[CastReelRow2MatrixIndex(row, reel), num];
        }

        private void PlaceNext(int row, int reel)
        {
            if (row == 8 && reel == 8)
            {
                bSolved = true;
                return;
            }

            int nextRow;
            int nextReel;
            if (reel == 8)
            {
                nextRow = row + 1;
                nextReel = 0;
            }
            else
            {
                nextRow = row;
                nextReel = reel + 1;
            }

            BackTrack(nextRow, nextReel);
        }

        private void BackTrack(int row, int reel)
        {
            if (boardRef[row][reel] != '.')
            {
                PlaceNext(row, reel);
                return;
            }

            for (int num = 1; num < 10; num++)
            {
                if (CouldInput(row, reel, num))
                {
                    Input(row, reel, num);
                    PlaceNext(row, reel);
                    if (!bSolved)
                    {
                        Erase(row, reel);
                    }
                }
            }
        }

        public void SolveSudoku(char[][] board)
        {
            boardRef = board;
            for (int i = 0; i < 9; i++)
            {
                numPool[i + 1] = 9;
            }


            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                    {
                        var num = (int) Char.GetNumericValue(board[i][j]);
                        Input(i, j, num);
                    }
                }
            }

            BackTrack(0, 0);
        }

        public static void Test()
        {
            var suduko = new suduko();

            char[][] src =
            {
                new[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                new[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'},
            };
//            {
//                new[] {'.', '.', '9', '7', '4', '8', '.', '.', '.'},
//                new[] {'7', '.', '.', '.', '.', '.', '.', '.', '.'},
//                new[] {'.', '2', '.', '1', '.', '9', '.', '.', '.'},
//                new[] {'.', '.', '7', '.', '.', '.', '2', '4', '.'},
//                new[] {'.', '6', '4', '.', '1', '.', '5', '9', '.'},
//                new[] {'.', '9', '8', '.', '.', '.', '3', '.', '.'},
//                new[] {'.', '.', '.', '8', '.', '3', '.', '2', '.'},
//                new[] {'.', '.', '.', '.', '.', '.', '.', '.', '6'},
//                new[] {'.', '.', '.', '2', '7', '5', '9', '.', '.'},
//            };

            suduko.SolveSudoku(src);
            
            Console.WriteLine("Finish");
            for (int i = 0; i < 9; i++)
            {
                var row = "";
                for (int j = 0; j < 9; j++)
                {
                    row += $"{src[i][j]}, ";
                }

                Console.WriteLine(row);
            }
        }
    }
}