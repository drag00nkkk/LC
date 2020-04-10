using System.Xml;

namespace ConsoleApplication1
{
    public class RotateMatrix_inteview_01_07
    {
        static public void Test()
        {
//            int[][] matrix = new[]
//            {
//                new[] {1, 2, 3},
//                new[] {4, 5, 6},
//                new[] {7, 8, 9},
//            };
            int[][] matrix = new[]
            {
                new[] {5, 1, 9, 11},
                new[] {2, 4, 8, 10},
                new[] {13, 3, 6, 7},
                new[] {15, 14, 12, 16},
            };
            new RotateMatrix_inteview_01_07().Rotate(matrix);
            for (int i = 0; i < matrix.Length; i++)
            {
                Utils.DumpArray(matrix[i]);
            }
        }

        /*
         *
            给你一幅由 N × N 矩阵表示的图像，其中每个像素的大小为 4 字节。请你设计一种算法，将图像旋转 90 度。

            不占用额外内存空间能否做到？

            示例 1:

            给定 matrix = 
            [
              [1,2,3],
              [4,5,6],
              [7,8,9]
            ],

            原地旋转输入矩阵，使其变为:
            [
              [7,4,1],
              [8,5,2],
              [9,6,3]
            ]
            示例 2:

            给定 matrix =
            [
              [ 5, 1, 9,11],
              [ 2, 4, 8,10],
              [13, 3, 6, 7],
              [15,14,12,16]
            ], 

            原地旋转输入矩阵，使其变为:
            [
              [15,13, 2, 5],
              [14, 3, 4, 1],
              [12, 6, 8, 9],
              [16, 7,10,11]
            ]
            
         */

        public void Rotate(int[][] matrix)
        {
            var max = matrix.Length;
            var width = max;
            while (width >= 2)
            {
                for (int col = 0; col < width - 1; col++)
                {
                    int _col = (max - width) / 2;
                    int _row = (max - width) / 2 + col;
                    int pre = matrix[_row][_col];
                    for (int i = 0; i < 4; i++)
                    {
                        GetAfterRotate(matrix, _col, _row, out int tempCol, out int tempRow);
                        int next = matrix[tempRow][tempCol];
                        matrix[tempRow][tempCol] = pre;
                        _col = tempCol;
                        _row = tempRow;
                        pre = next;
                    }
                }

                width -= 2;
            }
        }

        private void GetAfterRotate(int[][] matrix, int col, int row, out int outCol, out int outRow)
        {
            outCol = matrix.Length - 1 - row;
            outRow = col;
        }
    }
}