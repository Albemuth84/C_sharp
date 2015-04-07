using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCast.Assessment.Test
{
    public enum Direction
    {
        Ascending,
        Descending
    }
    public enum Attribute
    {
        Title,
        Author,
        EditionYear
    }
    public delegate IOrderedEnumerable<Book> OrderBy(IOrderedEnumerable<Book> list, Func<Book, object> byParameter);
}
