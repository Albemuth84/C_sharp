using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnCast.Assessment
{
    /// <summary>
    /// Book entity class
    /// </summary
    public class Book
    {
        /// <summary>
        /// Gets the title of the book.
        /// </summary>
        /// <value>
        /// The title of the book.
        /// </value>
        public string Title { get; private set; }
        /// <summary>
        /// Gets the name of the author.
        /// </summary>
        /// <value>
        /// The name of the author.
        /// </value>
        public string AuthorName { get; private set; }
        /// <summary>
        /// Gets the edition year.
        /// </summary>
        /// <value>
        /// The edition year.
        /// </value>
        public int EditionYear { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The name of the author.</param>
        /// <param name="edition">The edition year.</param>
        public Book(string title, string author, int edition)
        {
            this.Title = title;
            this.AuthorName = author;
            this.EditionYear = edition;
        }
    }
}
