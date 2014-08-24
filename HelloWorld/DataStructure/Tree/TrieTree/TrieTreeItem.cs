// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrieTreeItem.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace HelloWorld.DataStructure.Tree.TrieTree
{
    using System.Collections.Generic;

    /// <summary>
    /// </summary>
    public class TrieTreeItem
    {
        #region Fields

        /// <summary>
        /// </summary>
        public string Ch;

        public bool IsTerminal { get; set; }

        /// <summary>
        /// </summary>
        public Dictionary<string, TrieTreeItem> Children;

        /// <summary>
        /// </summary>
        private string _word;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TrieTreeItem" /> class.
        /// </summary>
        /// <param name="c">
        ///     The c.
        /// </param>
        /// <param name="father">
        ///     The father.
        /// </param>
        /// <param name="floor">
        ///     The floor.
        /// </param>
        /// <param name="id">
        ///     The id.
        /// </param>
        public TrieTreeItem(string c, TrieTreeItem father, int floor, bool isTerminal)
        {
            this.Ch = c;
            this.Father = father;
            this.Floor = floor;
            this.IsTerminal = isTerminal;
            this.Children = new Dictionary<string, TrieTreeItem>();
            this.GetWord();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TrieTreeItem" /> class.
        /// </summary>
        /// <param name="c">
        ///     The c.
        /// </param>
        /// <param name="father">
        ///     The father.
        /// </param>
        /// <param name="floor">
        ///     The floor.
        /// </param>
        /// <param name="id">
        ///     The id.
        /// </param>
        public TrieTreeItem(char c, TrieTreeItem father, int floor, bool isTerminal)
            : this(c.ToString(), father, floor, isTerminal)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the father.
        /// </summary>
        public TrieTreeItem Father { get; set; }

        /// <summary>
        ///     Gets or sets the floor.
        /// </summary>
        public int Floor { get; set; }

        /// <summary>
        ///     Gets or sets the word.
        /// </summary>
        public string Word
        {
            get
            {
                return this._word;
            }

            set
            {
                this._word = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        private void GetWord()
        {
            if (this.Father != null)
            {
                this._word = this.Father.Word + this.Ch;
            }
            else
            {
                this._word = this.Ch;
            }
        }

        #endregion
    }
}