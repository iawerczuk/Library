using Library.Domain;
using Library.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ConsoleApp
{
    public class BookService
    {
        private readonly BooksRepository _repository;

        public BookService(BooksRepository repository)
        {
            _repository = repository;
        }

        public void AddBook()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            Console.Write("Enter author: ");
            string author = Console.ReadLine();
            Console.Write("Enter publication year: ");
            int publicationYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter products available: ");
            int productsAvailable = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Book newBook = new Book(title, author, publicationYear, isbn, productsAvailable, price);
            _repository.Insert(newBook);
        }

        public void RemoveBook()
        {
            Console.Write("Enter title of the book to remove: ");
            string title = Console.ReadLine();
            _repository.RemoveByTitle(title);
        }

        public void ListBooks()
        {
            var books = _repository.GetAll();
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        public void ChangeState()
        {
            Console.Write("Enter title of the book: ");
            string title = Console.ReadLine();
            Console.Write("Enter state change (e.g., -1 for decrease): ");
            int stateChange = Convert.ToInt32(Console.ReadLine());
            _repository.ChangeState(title, stateChange);
        }
    }
}
