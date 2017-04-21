using System;

namespace AlgorithmsMadeEasy
{
    public class MergeSortAlgo
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");
        //    var program = new Program();
        //    //var newArray = program.getArray(new int[5] { 0, 1, 2, 3, 4 }, 1, 3);
        //    //var newArray1 = program.getArray(new int[5] { 0, 1, 2, 3, 4 }, 1, 1);
        //    // mergedArray = program.Merge(new int[] { 3, 5, 9}, new int[] { 6, 8, 10 });

        //    var mergeSort = program.MergeSort(new int[] { 9, 8, 3 });
        //    var mergeSort1 = program.MergeSort(new int[] { 9, 8, 3, 1, 2, 6, 7, 4, 11 });
        //}
        /// <summary>
        /// 1 2 3 4 5
        /// 1 2 3| 4 5
        /// 1 2|3  |  4 | 5
        /// 1 | 2  | 3  |  4 | 5
        /// </summary>
        /// <param name="array"></param>
        /// <param name="firstIndex"></param>
        /// <param name="midIndex"></param>
        /// <param name="lastIndex"></param>
        /// <returns></returns>

        public int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int midIndex = array.Length / 2;
            var leftArray = getArray(array, 0, midIndex - 1);
            var rightArray = getArray(array, midIndex, (array.Length - 1));

            var leftSide = MergeSort(leftArray);
            var rightSide = MergeSort(rightArray);

            return Merge(leftSide, rightSide);
        }

        public int[] Merge(int[] lowHalf, int[] highHalf)
        {
            var mergedArray = new int[lowHalf.Length + highHalf.Length];
            int lowHalfIndex = 0, highHalfIndex = 0, mergedArrayIndex = 0;

            while (lowHalfIndex < lowHalf.Length && highHalfIndex < highHalf.Length)
            {
                if (lowHalf[lowHalfIndex] < highHalf[highHalfIndex])
                {
                    mergedArray[mergedArrayIndex] = lowHalf[lowHalfIndex];
                    lowHalfIndex++;
                }
                else
                {
                    mergedArray[mergedArrayIndex] = highHalf[highHalfIndex];
                    highHalfIndex++;
                }
                mergedArrayIndex++;
            }

            while (lowHalfIndex < lowHalf.Length)
            {
                mergedArray[mergedArrayIndex] = lowHalf[lowHalfIndex];
                lowHalfIndex++;
                mergedArrayIndex++;
            }

            while (highHalfIndex < highHalf.Length)
            {
                mergedArray[mergedArrayIndex] = highHalf[highHalfIndex];
                highHalfIndex++;
                mergedArrayIndex++;
            }

            return mergedArray;
        }


        private int[] getArray(int[] array, int startIndex, int lastIndex)
        {
            if ((lastIndex - startIndex) <= array.Length)
            {
                var newArray = new int[lastIndex - startIndex + 1];
                for (var cnt = 0; cnt <= lastIndex - startIndex; cnt++)
                {
                    newArray[cnt] = array[startIndex + cnt];
                }
                return newArray;
            }

            return new int[0];
        }
    }
}