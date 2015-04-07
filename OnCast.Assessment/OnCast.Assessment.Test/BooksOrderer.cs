using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCast.Assessment.Test
{
    public class BooksOrderer : IBooksOrderer
    {
        #region Private Fields
        private List<Tuple<Attribute, Direction>> _orderingParameters;
        #endregion

        #region Constructor
        public BooksOrderer()
        {
            _orderingParameters = new List<Tuple<Attribute, Direction>>();
        }
        #endregion

        #region Private Methods
        private IOrderedEnumerable<Book> ThenByAscending(IOrderedEnumerable<Book> books, Func<Book, object> byParameter)
        {
            return books.ThenBy(byParameter);
        }
        private IOrderedEnumerable<Book> ThenByDescending(IOrderedEnumerable<Book> books, Func<Book, object> byParameter)
        {
            return books.ThenByDescending(byParameter);
        }
        private Func<Book, object> GetFunc(Attribute attribute)
        {
            switch (attribute)
            {
                case Attribute.Title: return b => b.Title;
                case Attribute.Author: return b => b.AuthorName;
                case Attribute.EditionYear: return b => b.EditionYear;
                default: return null;
            }
        }
        private void ClearParameters()
        {
            _orderingParameters.Clear();
        }
        #endregion 

        #region Public Methods
        public void Order(ref List<Book> books)
        {
            if (_orderingParameters.Count == 0 || books == null)
                throw new OrderingException();

            OrderBy thenOrderBy;
            Func<Book, object> byFunc = GetFunc(_orderingParameters[0].Item1);
            IOrderedEnumerable<Book> orderedBooks;
            
            if (_orderingParameters[0].Item2.Equals(Direction.Ascending))
                orderedBooks = books.OrderBy(byFunc);
            else
                orderedBooks = books.OrderByDescending(byFunc);

            for (int i = 1; i < _orderingParameters.Count; i++)
            {
                Attribute attribute = _orderingParameters[i].Item1;
                Direction direction = _orderingParameters[i].Item2;

                if (direction.Equals(Direction.Ascending))
                    thenOrderBy = new OrderBy(ThenByAscending);
                else
                    thenOrderBy = new OrderBy(ThenByDescending);

                byFunc = GetFunc(attribute);
                orderedBooks = thenOrderBy.Invoke(orderedBooks, byFunc);
            }

            books = orderedBooks.ToList();
            ClearParameters();
        }
        public void AddOrderingParamenter(Attribute attribute, Direction direction)
        {
            if (_orderingParameters.Exists(p => p.Item1.Equals(attribute)))
                return;
            _orderingParameters.Add(new Tuple<Attribute, Direction>(attribute, direction));
        }
        #endregion
    }
}
