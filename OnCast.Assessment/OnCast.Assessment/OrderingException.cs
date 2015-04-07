using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnCast.Assessment
{
    public class OrderingException : Exception
    {
        public OrderingException()
            : base("Ordering Exeption raised")
        {

        }
    }
}
