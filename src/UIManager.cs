using System;
using System.Collections.Generic;

namespace LibraryManager
{
    // Handles all user interface interactions
    class UIManager
    {
        private readonly Library library;

        public UIManager(Library library)
        {
            this.library = library;
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        ViewAllBooks();
                        break;
                    case "3":
                        SearchBooks();
                        break;
                    case "4":
                        UpdateBook();
                        break;
                    case "5":
                        RemoveBook();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("\n====== Advanced Library Management System ======");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Search Books");
            Console.WriteLine("4. Update Book");
            Console.WriteLine("5. Remove Book");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
        }

        private void AddBook()
        {
            Console.WriteLine("\n--- Add New Book ---");
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty. Book not added.");
                return;
            }

            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Author cannot be empty. Book not added.");
                return;
            }

            Console.Write("Enter Year: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Invalid year. Book not added.");
                return;
            }

            library.AddBook(title, author, year);
        }

        private void ViewAllBooks()
        {
            Console.WriteLine("\n--- All Books ---");
            var books = library.GetBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("No books available in the library.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        private void SearchBooks()
        {
            Console.Write("\nEnter title or author to search: ");
            string keyword = Console.ReadLine();
            var results = library.SearchBooks(keyword);

            if (results.Count == 0)
            {
                Console.WriteLine("No matching books found.");
            }
            else
            {
                Console.WriteLine("\n--- Search Results ---");
                foreach (var b in results)
                {
                    Console.WriteLine(b);
                }
            }
        }

        private void UpdateBook()
        {
            Console.Write("\nEnter the ID of the book to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            var book = library.FindBookById(id);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.WriteLine($"Editing: {book.Title} by {book.Author} ({book.Year})");
            Console.Write("Enter new title (leave blank to keep): ");
            string title = Console.ReadLine();
            Console.Write("Enter new author (leave blank to keep): ");
            string author = Console.ReadLine();
            Console.Write("Enter new year (leave blank to keep): ");
            string yearInput = Console.ReadLine();

            int? newYear = null;
            if (!string.IsNullOrWhiteSpace(yearInput))
            {
                if (int.TryParse(yearInput, out int year))
                {
                    newYear = year;
                }
                else
                {
                    Console.WriteLine("Invalid year format. Year not updated.");
                }
            }

            library.UpdateBook(book, title, author, newYear);
            Console.WriteLine("✏️ Book updated successfully!");
        }

        private void RemoveBook()
        {
            Console.Write("\nEnter the ID of the book to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            var bookToRemove = library.FindBookById(id);
            if (bookToRemove == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.WriteLine($"You are about to remove: {bookToRemove}");
            Console.Write("Are you sure? (y/n): ");
            string confirmation = Console.ReadLine().ToLower();

            if (confirmation == "y")
            {
                if (library.RemoveBook(id))
                {
                    Console.WriteLine("🗑️ Book removed successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to remove book.");
                }
            }
            else
            {
                Console.WriteLine("Remove operation cancelled.");
            }
        }
    }
}
