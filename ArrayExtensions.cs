using System;
using System.Collections.Generic;

namespace PadawansTask11
{
    public static class ArrayExtensions
    {
        private static double GetSum(double[] arr)
        {
            double sum = 0;
            foreach (double var in arr)
                sum += var;
            return sum;
        }

        private static double[] GetSubArray(double[] arr, int start, int end)
        {
            List<double> l = new List<double>();
            for (int i = start; i <= end; i++)
                l.Add(arr[i]);

            return l.ToArray();
        }


        public static int? FindIndex(double[] array, double accuracy)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length < 3)
                throw new ArgumentException();
            if (accuracy <= 0 || accuracy >= 1)
                throw new ArgumentOutOfRangeException();

            double[] subarrLeft;
            double[] subarrRight;

            double sum1 = 0, sum2 = 0;
            for (int i = 1; i < array.Length - 1; i++)
            {
                subarrLeft = GetSubArray(array, 0, i - 1);
                subarrRight = GetSubArray(array, i + 1, array.Length - 1);
                sum1 = GetSum(subarrLeft);
                sum2 = GetSum(subarrRight);
                if (Math.Abs(sum1 - sum2) <= accuracy)
                    return i;
            }

            return null;
        }
    }
}