using System;

namespace RemoveExceptions.Example1
{
    public static class ArrayHelper
    {
        public static int GetSumOfPositiveNumbers(int[,] array)
        {
            if (array is null)
                // throw new ArgumentNullException("Input array is null");
                return 0;

            int sum = 0;

            foreach (int num in array)
            {
                if (num > 0)
                    sum += num;
            }

            return sum;
        }
        private static int[] Sort(int[] array, bool asc)
        {
            if (array is null)
                return new int[0];
            // throw new ArgumentNullException("Input array is null.");

            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if ((asc && array[i] > array[i + 1]) || (!asc && array[i] < array[i + 1]))
                    {
                        sorted = false;
                        var cache = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = cache;
                    }
                }
            }
            return array;
        }
        public static int[] SortAsc(int[] array)
        {
            return Sort(array, true);
        }
        public static int[] SortDesc(int[] array)
        {
            return Sort(array, false);
        }
    }
}