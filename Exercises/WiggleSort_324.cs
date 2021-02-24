using System;
using System.Xml;

namespace LeetCode
{
    public class WiggleSort_324
    {
        public static void Test()
        {
            var obj = new WiggleSort_324();
//            int[] a = {1, 1, 2, 1, 2, 2, 1};
//            int[] a = {1, 1, 2, 1, 2, 2};
//            int[] a = {4, 5, 5, 5, 5, 6, 6, 6};
//            int[] a = {4, 5, 5, 6};
            int[] a = {1, 3, 2, 2, 3, 1};
//            obj.WiggleSort(a);
//            int[] a = {1, 2, 3, 3, 4, 8, 10, 100, 2, 6, 6, 7, 9, 9, 99};
            obj.WiggleSort(a);
            Utils.DumpArray(a);
        }

        /*
            给定一个无序的数组 nums，将它重新排列成 nums[0] < nums[1] > nums[2] < nums[3]... 的顺序。

            示例 1:

            输入: nums = [1, 5, 1, 1, 6, 4]
            输出: 一个可能的答案是 [1, 4, 1, 5, 1, 6]
            示例 2:

            输入: nums = [1, 3, 2, 2, 3, 1]
            输出: 一个可能的答案是 [2, 3, 1, 3, 1, 2]
            说明:
            你可以假设所有输入都会得到有效的结果。

            进阶:
            你能用 O(n) 时间复杂度和 / 或原地 O(1) 额外空间来实现吗？

         * 
         */
//        public void WiggleSort(int[] nums)
//        {
//            Array.Sort(nums);
//            var len = nums.Length;
//            var bigLen = len / 2;
//            var smallLen = len - bigLen;
//            int[] smallArray = new int [smallLen];
//            int[] bigArray = new int [bigLen];
//            for (int i = 0; i < smallLen; i++)
//            {
//                smallArray[i] = nums[smallLen - i - 1];
//            }
//
//            for (int i = 0; i < bigLen; i++)
//            {
//                bigArray[i] = nums[len - i - 1];
//            }
//
//            for (int i = 0; i < len; i++)
//            {
//                int[] array = (i % 2 == 0) ? smallArray : bigArray;
//                nums[i] = array[i / 2];
//            }
//        }

        // t = O(N)
        public void WiggleSort(int[] nums)
        {
            int pivotIndex = nums.Length / 2;
            QuickSelect(nums, 0, nums.Length - 1, pivotIndex);
            Utils.DumpArray(nums);
            ThreeWay(nums, pivotIndex);
            Utils.DumpArray(nums);

//            var bigLen = nums.Length / 2;
//            var smallLen = nums.Length - bigLen;
//            int[] smallArray = new int [smallLen];
//            Array.Copy(nums, 0, smallArray, 0, smallLen);
//            int[] bigArray = new int [bigLen];
//            Array.Copy(nums, smallLen, bigArray, 0, bigLen);
//
//            for (int i = 0; i < nums.Length; i++)
//            {
//                int val;
//                if (i % 2 == 0)
//                {
//                    val = smallArray[smallArray.Length - i / 2 - 1];
//                }
//                else
//                {
//                    val = bigArray[bigArray.Length - (i - 1) / 2 - 1];
//                }
//
//                nums[i] = val;
//            }
        }

        void QuickSelect(int[] nums, int firstIndex, int lastIndex, int selectIndex)
        {
            int temp = nums[lastIndex];
            int walkIndex = firstIndex;
            int swapIndex = firstIndex;
            while (walkIndex < lastIndex)
            {
                if (nums[walkIndex] > temp)
                {
                    walkIndex++;
                }
                else
                {
                    Swap(nums, walkIndex, swapIndex);
                    walkIndex++;
                    swapIndex++;
                }
            }

            Swap(nums, lastIndex, swapIndex);
            if (swapIndex > selectIndex)
            {
                QuickSelect(nums, firstIndex, swapIndex - 1, selectIndex);
            }
            else if (swapIndex < selectIndex)
            {
                QuickSelect(nums, swapIndex + 1, lastIndex, selectIndex);
            }
        }

        void ThreeWay(int[] nums, int pivotIndex)
        {
            int pivotNumber = nums[pivotIndex];
            int walkIndex = 0;
            int leftIndex = 0;
            int rightIndex = nums.Length - 1;
            
            int MapIndex(int index)
            {
                var smallLen = (nums.Length + 1) / 2;
                if (index < smallLen)
                {
                    return nums.Length - 1 - 2 * index - (nums.Length % 2 == 0 ? 1 : 0);
                }
                else
                {
                    return nums.Length - 1 - 2 * (index - smallLen) - nums.Length % 2;
                }
            }
            
            while (leftIndex < rightIndex && walkIndex <= rightIndex)
            {
                if (nums[MapIndex(walkIndex)] < pivotNumber)
                {
                    Swap(nums, MapIndex(walkIndex), MapIndex(leftIndex));
                    leftIndex++;
                }
                else if (nums[MapIndex(walkIndex)] > pivotNumber)
                {
                    Swap(nums, MapIndex(walkIndex), MapIndex(rightIndex));
                    rightIndex--;
                }

                walkIndex++;
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