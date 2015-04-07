using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnCast.Assessment.Test
{
    public class Book
    {
        public string Title { get; private set; }
        public string AuthorName { get; private set; }
        public int EditionYear { get; private set; }
        public Book(int id, string name, string author, int edition)
        {
            this.Title = name;
            this.AuthorName = author;
            this.EditionYear = edition;
        }
    }
}
