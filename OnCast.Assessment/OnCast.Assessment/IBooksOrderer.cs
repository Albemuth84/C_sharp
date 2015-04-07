using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCast.Assessment
{
    /// <summary>
    /// IBooksOrderer interface
    /// </summary
    interface IBooksOrderer
    {
        void Order(ref List<Book> books);
    }
}
