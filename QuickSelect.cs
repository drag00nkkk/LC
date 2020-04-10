namespace ConsoleApplication1
{
    public class QuickSelect
    {
        public static void Test()
        {
            var obj = new QuickSelect();
//            int[] array = new[] {5, 9, 1, 7, 2, 4, 5};
            int[] array = new[] {1, 9, 1, 20, 2, 3, 2};
            obj.DoSelect(array, 0, array.Length - 1, array.Length / 2);
            Utils.DumpArray(array);
        }

        public void DoSelect(int[] array, int firstIndex, int endIndex, int selectIndex)
        {
            int tempVal = array[endIndex];
            int walkIndex = firstIndex;
            int swapIndex = firstIndex;
            while (walkIndex < endIndex)
            {
                if (array[walkIndex] <= tempVal)
                {
                    Swap(array, walkIndex, swapIndex);
                    walkIndex++;
                    swapIndex++;
                }
                else
                {
                    walkIndex++;
                }
            }
            Swap(array, endIndex, swapIndex);
            if (swapIndex < selectIndex)
            {
                DoSelect(array, swapIndex + 1, endIndex, selectIndex);
            }
            else if (swapIndex > selectIndex)
            {
                DoSelect(array, firstIndex, swapIndex - 1, selectIndex);
            }
        }
        
        private void Swap(int[] array, int aIndex, int bIndex)
        {
            var temp = array[aIndex];
            array[aIndex] = array[bIndex];
            array[bIndex] = temp;
        }
    }
}