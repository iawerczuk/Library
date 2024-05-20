using System;
using System.Collections.Generic;
using System.Linq;
using Library.Domain;

namespace Library.Persistence
{
    public class BooksRepository
    {
        private readonly List<Book> _database;

        public BooksRepository()
        {
            _database = new List<Book>
            {
                new Book("Stary człowiek i morze", "Ernest Hemingway", 1986, "AAAA", 10, 19.99m),
                new Book("Komu bije dzwon", "Ernest Hemingway", 1997, "BBBB", 0, 119.99m),
                new Book("Alicja w krainie czarów", "C.K. Lewis", 1998, "CCCC", 53, 39.99m),
                new Book("Opowieści z Narnii", "C.K. Lewis", 1999, "DDDD", 33, 49.99m),
                new Book("Harry Potter", "J.K. Rowling", 2000, "EEEE", 23, 69.99m),
                new Book("Paragraf 22", "Joseph Heller", 2001, "FFFF", 5, 45.99m),
                new Book("Lalka", "Bolesław Prus", 2002, "GGGG", 7, 76.99m),
                new Book("To", "Stephen King", 2003, "HHHH", 2, 12.99m),
                new Book("Idiota", "Fiodor Dostojewski", 1950, "IIII", 89, 25.99m),
                new Book("Mistrz i Małgorzata", "Michaił Bułhakow", 1965, "JJJJ", 41, 36.99m),
            };
        }

        public void Insert(Book book)
        {
            _database.Add(book);
        }

        public List<Book> GetAll()
        {
            return _database;
        }

        public void RemoveByTitle(string title)
        {
            var book = _database.FirstOrDefault(b => b.Title == title);
            if (book != null)
            {
                _database.Remove(book);
            }
        }

        public void ChangeState(string title, int stateChange)
        {
            var book = _database.FirstOrDefault(b => b.Title == title);
            if (book != null)
            {
                book.ProductsAvailable += stateChange;
            }
        }
    }
}
