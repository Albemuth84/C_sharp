using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCast.Assessment
{
    interface IBooksOrderer
    {
        void Order(ref List<Book> books);
    }
}
