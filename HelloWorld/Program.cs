// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HelloWorld
{
    using System;

    /// <summary>
    /// </summary>
    public class Program
    {
        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        static void Main(string[] args)
        {
            // Create an unsorted array of string elements
            int[] unsorted = { 1, 2, 6, 3, 4, 5, 9, 12, 13, 14, 15 };

            // Sort the array
            Quicksort2(unsorted, 0, unsorted.Length - 1);

            // Print the sorted array
            for (int i = 0; i < unsorted.Length; i++)
            {
                Console.Write(unsorted[i] + " ");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        public static int partition(int[] arr, int start, int end)
        {
            // We assume last element of array as pivot element
            int pivot = (start + end) / 2;
            int i = start, j = end, temp;
            while (i < j)
            {
                // traverse the array and find index where element is greater than pivot element
                while (i < end && arr[i] < arr[pivot])
                    i++;
                // traverse the array and find index where element is smaller than pivot element
                while (j > start && arr[j] > arr[pivot])
                    j--;

                //exchange elements on indexes found by i and j
                if (i < j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            // finally put pivot element at its right position in array
            temp = arr[pivot];
            arr[pivot] = arr[j];
            arr[j] = temp;
            // return pivot index
            return j;
        }
        // Quick sort procedure
        public static void Quicksort2(int[] arr, int start, int end)
        {
            if (start < end)
            {
                // find the pivot index
                int pivotIndex = partition(arr, start, end);
                // recursivly call itself for array element before pivot index
                Quicksort2(arr, start, pivotIndex - 1);
                // recursivly call itself for array element after pivot index
                Quicksort2(arr, pivotIndex + 1, end);
            }
        }


        public static void Quicksort(int[] elements, int left, int right)
        {
            int i = left, j = right;
            int pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }



        #endregion
    }
}