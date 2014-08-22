namespace HelloWorld
{
    using System.Collections.Generic;

    using HelloWorld.Sort;

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
        private static void Main(string[] args)
        {
            // Create an unsorted array of string elements
            int[] unsorted = { 10, 2, 8, 6, 4, 7, 9, 3, 5, 7 };

            // int[] unsorted = { 10, 2 };
            List<int> list = new List<int>(unsorted);

            list.MergeSort();
            list.QuickSort(0, list.Count - 1);
        }

        #endregion
    }
}