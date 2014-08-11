// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HelloWorld
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// </summary>
    public class PronInfo : IComparable<PronInfo>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PronInfo"/> class.
        /// </summary>
        /// <param name="pron">
        /// The pron.
        /// </param>
        /// <param name="word">
        /// The word.
        /// </param>
        /// <param name="example">
        /// The example.
        /// </param>
        public PronInfo(string pron, string word, string example)
        {
            this.Pronunciation = pron;
            this.Count = 0;
            this.Persentage = 0;
            this.IsMatch = false;
            this.IsPreferred = false;
            this.Example = example;
            this.Word = word;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the example.
        /// </summary>
        public string Example { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is match.
        /// </summary>
        public bool IsMatch { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is preferred.
        /// </summary>
        public bool IsPreferred { get; set; }

        /// <summary>
        /// Gets or sets the persentage.
        /// </summary>
        public double Persentage { get; set; }

        /// <summary>
        /// Gets or sets the pronunciation.
        /// </summary>
        public string Pronunciation { get; set; }

        /// <summary>
        /// Gets or sets the word.
        /// </summary>
        public string Word { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="send">
        /// The send.
        /// </param>
        /// <returns>
        /// </returns>
        public int CompareTo(PronInfo send)
        {
            if (send.Count == this.Count)
            {
                return 0;
            }

            if (send.Count > this.Count)
            {
                return 1;
            }

            return -1;
        }

        #endregion
    }

    /// <summary>
    /// </summary>
    internal class Program
    {
        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            var list = new List<PronInfo>();
            var pron = new PronInfo("a", "b", "c");
            pron.Count = 1;
            list.Add(pron);
            pron = new PronInfo("a", "b", "c");
            pron.Count = 22;
            list.Add(pron);
            pron = new PronInfo("a", "b", "c");
            pron.Count = 3;
            list.Add(pron);
            list.Sort();
            foreach (PronInfo pr in list)
            {
                Console.WriteLine(pr.Count);
            }
        }

        #endregion
    }
}