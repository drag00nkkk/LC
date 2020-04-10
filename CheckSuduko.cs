using System;
using System.Diagnostics;

namespace ConsoleApplication1
{
    public class CheckSuduko
    {
        public bool IsValidSudoku(char[][] board)
        {
            bool[,] rowMap = new bool[9, 10];
            bool[,] reelMap = new bool[9, 10];
            bool[,] blockMap = new bool[9, 10];

            for (int row = 0; row < 9; row++)
            {
                for (int reel = 0; reel < 9; reel++)
                {
                    if (board[row][reel] == '.')
                    {
                        continue;
                    }

                    var num = (int) Char.GetNumericValue(board[row][reel]);
                    if (rowMap[row, num])
                    {
                        return false;
                    }

                    rowMap[row, num] = true;

                    if (reelMap[reel, num])
                    {
                        return false;
                    }

                    reelMap[reel, num] = true;

                    var blockIndex = row / 3 * 3 + reel / 3;
                    if (blockMap[blockIndex, num])
                    {
                        return false;
                    }

                    blockMap[blockIndex, num] = true;
                }
            }

            return true;
        }

        public static void Test()
        {
            var obj = new CheckSuduko();
            char[][] falseSrc =
            {
                new[] {'8', '3', '.', '.', '7', '.', '.', '.', '.'},
                new[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'},
            };
            Console.WriteLine(obj.IsValidSudoku(falseSrc));

            char[][] rightSrc =
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
            Console.WriteLine(obj.IsValidSudoku(rightSrc));
        }
    }
}