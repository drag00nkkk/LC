using System;

namespace ConsoleApplication1
{
    public class QuickSort
    {
        public static void Test()
        {
            var obj = new QuickSort();
            int[] a = {9, 8, 7, 6, 5, 4, 3, 1, 1, 5, 8, 77, 9, 2};
//            int[] a = {9, 9};
            obj.Sort(a, 0, a.Length - 1);
            Utils.DumpArray(a);
        }

        public void Sort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }
            var temp = array[startIndex];
            int leftIndex = startIndex;
            int rightIndex = endIndex;
            while (leftIndex < rightIndex)
            {
                while (rightIndex > leftIndex && array[rightIndex] >= temp)
                    rightIndex--;
                while (rightIndex > leftIndex && array[leftIndex] <= temp)
                    leftIndex++;
                
                Swap(array, rightIndex, leftIndex);
            }
            
            Swap(array, startIndex, leftIndex);
            
            Sort(array, leftIndex + 1, endIndex);
            Sort(array, startIndex, leftIndex - 1);
        }

        private void Swap(int[] array, int aIndex, int bIndex)
        {
            var temp = array[aIndex];
            array[aIndex] = array[bIndex];
            array[bIndex] = temp;
        }
    }
}