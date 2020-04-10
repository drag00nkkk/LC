using System;

namespace ConsoleApplication1
{
    public class GameOfLife_289
    {
        public static void Test()
        {
            var obj = new GameOfLife_289();
            var matrix = new[]
            {
//                new[] {0, 1, 0},
//                new[] {0, 0, 1},
//                new[] {1, 1, 1},
//                new[] {0, 0, 0}
                new[] {0},
                new[] {0},
                new[] {1},
                new[] {0}
            };
            obj.GameOfLife(matrix);
            for (int i = 0; i < matrix.Length; i++)
            {
                Utils.DumpArray(matrix[i]);
            }
        }

        /*
         *  根据 百度百科 ，生命游戏，简称为生命，是英国数学家约翰·何顿·康威在 1970 年发明的细胞自动机。

            给定一个包含 m × n 个格子的面板，每一个格子都可以看成是一个细胞。每个细胞都具有一个初始状态：1 即为活细胞（live），或 0 即为死细胞（dead）。
            每个细胞与其八个相邻位置（水平，垂直，对角线）的细胞都遵循以下四条生存定律：

            如果活细胞周围八个位置的活细胞数少于两个，则该位置活细胞死亡；
            如果活细胞周围八个位置有两个或三个活细胞，则该位置活细胞仍然存活；
            如果活细胞周围八个位置有超过三个活细胞，则该位置活细胞死亡；
            如果死细胞周围正好有三个活细胞，则该位置死细胞复活；
            
            根据当前状态，写一个函数来计算面板上所有细胞的下一个（一次更新后的）状态。
            下一个状态是通过将上述规则同时应用于当前状态下的每个细胞所形成的，其中细胞的出生和死亡是同时发生的。

             

            示例：

            输入： 
            [
              [0,1,0],
              [0,0,1],
              [1,1,1],
              [0,0,0]
            ]
            输出：
            [
              [0,0,0],
              [1,0,1],
              [0,1,1],
              [0,1,0]
            ]
             

            进阶：

            你可以使用原地算法解决本题吗？请注意，面板上所有格子需要同时被更新：你不能先更新某些格子，然后使用它们的更新后的值再更新其他格子。
            本题中，我们使用二维数组来表示面板。原则上，面板是无限的，但当活细胞侵占了面板边界时会造成问题。你将如何解决这些问题？
            
         * 
         */
        public void GameOfLife(int[][] board)
        {
            if (board.Length <= 0)
            {
                return;
            }

            for (int y = 0; y < board.Length; y++)
            {
                for (int x = 0; x < board[y].Length; x++)
                {
                    GetLiveCellsAround(x, y, board, out int liveCount, out int deadCount);
                    var myState = GetCellRealState(x, y, board);
                    if (myState == 1)
                    {
                        if (liveCount < 2 || liveCount > 3)
                        {
                            board[y][x] += 2;
                        }
                    }
                    else
                    {
                        if (liveCount == 3)
                        {
                            board[y][x] += 2;
                        }
                    }
                }
            }

            for (int y = 0; y < board.Length; y++)
            {
                for (int x = 0; x < board[y].Length; x++)
                {
                    if (board[y][x] == 3)
                    {
                        board[y][x] = 0;
                    }
                    else if (board[y][x] == 2)
                    {
                        board[y][x] = 1;
                    }
                }
            }
        }

        private void GetLiveCellsAround(int x, int y, int[][] board, out int outLiveCount, out int outDeadCount)
        {
            outLiveCount = 0;
            outDeadCount = 0;

            var maxY = board.Length - 1;
            var maxX = board[y].Length - 1;

            for (int i = 0; i < 9; i++)
            {
                if (i == 4) continue;

                var _x = i / 3;
                var _y = i % 3;
                var matrixX = x + _x - 1;
                var matrixY = y + _y - 1;
                if ((matrixX >= 0 && matrixX <= maxX) && (matrixY >= 0 && matrixY <= maxY))
                {
                    var cellState = GetCellRealState(matrixX, matrixY, board);
                    if (cellState == 1)
                    {
                        outLiveCount++;
                    }
                    else
                    {
                        outDeadCount++;
                    }
                }
            }
        }

        private int GetCellRealState(int x, int y, int[][] board)
        {
            var cellState = board[y][x];
            if (cellState > 1)
            {
                cellState -= 2;
            }

            return cellState;
        }
    }
}