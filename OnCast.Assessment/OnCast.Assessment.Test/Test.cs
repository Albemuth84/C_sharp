using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OnCast.Assessment;

namespace OnCast.Assessment.Test
{
    [TestFixture]
    public class Test
    {
        private Book _book1, _book2, _book3, _book4;
        private BooksOrderer _booksOrderer;

        [SetUp]
        public void Setup()
        {
            _book1 = new Book("Java How to Program", "Deitel & Deitel", 2007);
            _book2 = new Book("Patterns of Enterprise Application Architecture", "Martin Fowler", 2002);
            _book3 = new Book("Head First Design Patterns", "Elisabeth Freeman", 2004);
            _book4 = new Book("Internet & World Wide Web: How to Program", "Deitel & Deitel", 2007);
            _booksOrderer = new BooksOrderer();
        }

        [Test]
        public void TestTitleAscending()
        {
            List<Book> books = CreateOrder();
            _booksOrderer.AddOrderingParamenter(Attribute.Title, Direction.Ascending);
            _booksOrderer.Order(ref books);
            Assert.AreSame(_book3, books[0]);
            Assert.AreSame(_book4, books[1]);
            Assert.AreSame(_book1, books[2]);
            Assert.AreSame(_book2, books[3]);
        }

        [Test]
        public void TestAuthorAscendingTitleDescending()
        {
            List<Book> books = CreateOrder();
            _booksOrderer.AddOrderingParamenter(Attribute.Author, Direction.Ascending);
            _booksOrderer.AddOrderingParamenter(Attribute.Title, Direction.Descending);
            _booksOrderer.Order(ref books);
            Assert.AreSame(_book1, books[0]);
            Assert.AreSame(_book4, books[1]);
            Assert.AreSame(_book3, books[2]);
            Assert.AreSame(_book2, books[3]);
        }

        [Test]
        public void TestEditionYearDescendingAuthorDescendingTitleAscending()
        {
            List<Book> books = CreateOrder();
            _booksOrderer.AddOrderingParamenter(Attribute.EditionYear, Direction.Descending);
            _booksOrderer.AddOrderingParamenter(Attribute.Author, Direction.Descending);
            _booksOrderer.AddOrderingParamenter(Attribute.Title, Direction.Ascending);
            _booksOrderer.Order(ref books);
            Assert.AreSame(_book4, books[0]);
            Assert.AreSame(_book1, books[1]);
            Assert.AreSame(_book3, books[2]);
            Assert.AreSame(_book2, books[3]);
        }

        [Test]
        public void TestEmptySet()
        {
            List<Book> books = new List<Book>();
            _booksOrderer.Order(ref books);
            Assert.IsEmpty(books);
        }

        [Test]
        [ExpectedException(typeof(OrderingException))]
        public void TestNull()
        {
            List<Book> books = null;
            _booksOrderer.Order(ref books);
        }

        private List<Book> CreateOrder()
        {
            List<Book> books = new List<Book>();
            books.Add(_book1);
            books.Add(_book2);
            books.Add(_book3);
            books.Add(_book4);
            return books;
        }
    }
}
