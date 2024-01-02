using BookManager.Application.Abstractions.Services;
using BookManager.Core.Models;

namespace BookManager.UI
{
    public class App
    {
        private readonly IBookService _bookService;


        public App(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task Run(string[] args)
        {
            Console.WriteLine("Welcome to the Pennsylvania Public Library!");

            var isSessionOpen = true;

            while (isSessionOpen)
            {
                isSessionOpen = await MainMenu(isSessionOpen);
            }
            Console.WriteLine("Session closed.");
        }

        private async Task<bool> MainMenu(bool isSessionOpen)
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");

            Console.WriteLine("1. Look up books \n" +
                                "2. Return a book \n" +
                                "3. Borrow a book \n" +
                                "4. Exit \n");

            switch ((Console.ReadLine() ?? "").Trim().ToLower())
            {
                case "1":
                    {
                        await LookupBooks();
                        break;
                    }
                case "2":
                    {
                        await ReturnBooks();
                        break;
                    }
                case "3":
                    {
                        await BorrowBooks();
                        break;
                    }
                case "4":
                    {
                        isSessionOpen = false;
                        Console.WriteLine();
                        Console.WriteLine("Closing session... \n");
                        break;
                    }
                default: Console.WriteLine("Invalid Input."); break;
            }

            return isSessionOpen;
        }

        private async Task LookupBooks()
        {
            string? titleFilter = null;
            string? authorFilter = null;
            string? typeFilter = null;

            Console.WriteLine();
            Console.WriteLine("How would you like to look up books? \n");

            Console.WriteLine("1. By Title \n" +
                                "2. By Author \n" +
                                "3. By Book Type \n" +
                                "4. Exit \n");

            switch ((Console.ReadLine() ?? "").Trim().ToLower())
            {
                case "1":
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter the title of the book you're looking for:");
                        titleFilter = Console.ReadLine() ?? "".ToLower();

                        Console.WriteLine();
                        Console.WriteLine("Looking up books... \n");

                        var books = await _bookService.RetrieveBooksByTitleAsync(titleFilter);

                        ShowBooks(books);

                        break;
                    }
                case "2":
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter the author of the book you're looking for:");
                        authorFilter = Console.ReadLine() ?? "".ToLower();
                        var books = await _bookService.RetrieveBooksByAuthorAsync(authorFilter);

                        ShowBooks(books);

                        break;
                    }
                case "3":
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter the type of the book you're looking for:");
                        typeFilter = Console.ReadLine() ?? "".ToLower();
                        var books = await _bookService.RetrieveBooksByTypeAsync(typeFilter);

                        ShowBooks(books);

                        break;
                    }
                case "4":
                    {
                        Console.WriteLine();
                        Console.WriteLine("Exiting the menu...");
                        break;
                    }
                default:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid Input.");
                        break;
                    }
            }
        }

        private async Task BorrowBooks()
        {
            Console.WriteLine();
            Console.WriteLine("Borrowing a book... \n");
        }

        private async Task ReturnBooks()
        {
            Console.WriteLine();
            Console.WriteLine("Returning a book... \n");
        }

        private void ShowBooks(List<Book> books)
        {
            if (!books.Any())
            {
                Console.WriteLine("No books found!");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine($"Book Title: {book.Title} \n" +
                                    $"By {book.Author.Name} \n" +
                                    $"In \"{book.Type.Description}\" \n" +
                                    $"Book ID: {book.Id}");
                Console.WriteLine();
            }

            return;
        }

    }
}
