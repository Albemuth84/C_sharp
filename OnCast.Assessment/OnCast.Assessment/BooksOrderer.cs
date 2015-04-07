using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCast.Assessment
{
    /// <summary>
    /// BooksOrdered service class, implementation of the IBookOrderer  interface. Uses the AddOrderingParamenter(Attribute, Direction) method for addim ordering parameters
    /// and a call to the Order(List<Book>) method will order the provided list considering such parameters
    /// </summary>
    public class BooksOrderer : IBooksOrderer
    {
        #region Private Fields
        /// <summary>
        /// The attribute/direction combinations list
        /// </summary>
        private List<Tuple<Attribute, Direction>> _orderingParameters;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BooksOrderer"/> class and initialize the ordering paramenter list.
        /// </summary>
        public BooksOrderer()
        {
            _orderingParameters = new List<Tuple<Attribute, Direction>>();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Creates the Func<T1,T2> delegate to be fed to the OrderBy/ThenBy extension methods given an attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <returns></returns>
        private Func<Book, object> CreateOrderByParameter(Attribute attribute)
        {
            switch (attribute)
            {
                case Attribute.Title: return b => b.Title;
                case Attribute.Author: return b => b.AuthorName;
                case Attribute.EditionYear: return b => b.EditionYear;
                default: return null;
            }
        }
        /// <summary>
        /// Clears the ordering parameters.
        /// </summary>
        private void ClearParameters()
        {
            _orderingParameters.Clear();
        }
        #endregion 

        #region Public Methods
        /// <summary>
        /// Orders the specified books.
        /// </summary>
        /// <param name="books">The book list.</param>
        /// <exception cref="OrderingException"></exception>
        public void Order(ref List<Book> books)
        {
            if (books == null)
                throw new OrderingException();

            if (!books.Any() || !_orderingParameters.Any())
                return;

            //The first attribute/direction combination ordering runs with the OrderBy/OrderByDescending methods
            Func<Book, object> orderByParameter = CreateOrderByParameter(_orderingParameters[0].Item1);
            IOrderedEnumerable<Book> orderedBooks;
            
            if (_orderingParameters[0].Item2.Equals(Direction.Ascending))
                orderedBooks = books.OrderBy(orderByParameter);
            else
                orderedBooks = books.OrderByDescending(orderByParameter);

            //The remainder of the combinations run with the ThenBy/ThenByDescending methods
            for (int i = 1; i < _orderingParameters.Count; i++)
            {
                Attribute attribute = _orderingParameters[i].Item1;
                Direction direction = _orderingParameters[i].Item2;

                orderByParameter = CreateOrderByParameter(attribute);

                if (direction.Equals(Direction.Ascending))
                    orderedBooks = orderedBooks.ThenBy(orderByParameter);
                else
                    orderedBooks = orderedBooks.ThenByDescending(orderByParameter);
            }

            books = orderedBooks.ToList();
            ClearParameters();
        }
        /// <summary>
        /// Adds a combination of attribute (Ascending or descending) and direction (Title, Author and Edition Year). The call order for those
        /// combinations is the same order this method is continuosly called.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <param name="direction">The direction.</param>
        public void AddOrderingParamenter(Attribute attribute, Direction direction)
        {
            if (_orderingParameters.Exists(p => p.Item1.Equals(attribute)))
                return;
            _orderingParameters.Add(new Tuple<Attribute, Direction>(attribute, direction));
        }
        #endregion
    }
}
