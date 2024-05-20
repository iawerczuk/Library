using System;
using Library.Domain;
using Library.Persistence;
using Library.ConsoleApp;

class Program
{
    static void Main()
    {
        BooksRepository repository = new BooksRepository();
        BookService bookService = new BookService(repository);

        Console.Write("Enter login: ");
        string login = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        if (login == "Admin" && password == "password")
        {
            Console.WriteLine("Access Granted");

            string command;
            do
            {
                Console.Clear();
                Console.WriteLine("Komendy: dodaj, usun, wypisz, zmien, dodaj zamowienie, lista zamowien, wyjdz");
                Console.Write("Wpisz komendę: ");
                command = Console.ReadLine();

                switch (command)
                {
                    case "dodaj":
                        bookService.AddBook();
                        break;
                    case "usun":
                        bookService.RemoveBook();
                        break;
                    case "wypisz":
                        bookService.ListBooks();
                        break;
                    case "zmien":
                        bookService.ChangeState();
                        break;
                    case "dodaj zamowienie":
                        Console.WriteLine("proba dodania nowego zamowienia");
                        break;
                    case "lista zamowien":
                        Console.WriteLine("proba wypisania wszystkich zamowien");
                        break;
                    case "wyjdz":
                        Console.WriteLine("Koniec programu");
                        break;
                    default:
                        Console.WriteLine("Nie wspierana komenda");
                        break;
                }

                if (command != "wyjdz")
                {
                    Console.WriteLine("Press AnyKey");
                    Console.ReadKey();
                }

            } while (command != "wyjdz");
        }
        else
        {
            Console.WriteLine("Access Denied");
        }
        Console.ReadLine();
    }
}
