using System;
using System.Collections.Generic;

namespace LibraryManager
{
    // Class to represent a Book
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }

    class Program
    {
        // List to store books
        static List<Book> library = new List<Book>();

        static void Main()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n====== Library Management System ======");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Search for a Book");
                Console.WriteLine("4. Remove a Book");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        ViewBooks();
                        break;
                    case "3":
                        SearchBook();
                        break;
                    case "4":
                        RemoveBook();
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("❌ Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static void AddBook()
        {
            Console.WriteLine("\n--- Add New Book ---");
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            Console.Write("Enter Year: ");
            int year;

            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.Write("Please enter a valid year: ");
            }

            library.Add(new Book { Title = title, Author = author, Year = year });
            Console.WriteLine("✅ Book added successfully!");
        }

        static void ViewBooks()
        {
            Console.WriteLine("\n--- All Books ---");
            if (library.Count == 0)
            {
                Console.WriteLine("No books in the library yet.");
                return;
            }

            foreach (var book in library)
            {
                Console.WriteLine($"📖 {book.Title} by {book.Author} ({book.Year})");
            }
        }

        static void SearchBook()
        {
            Console.Write("\nEnter title or author to search: ");
            string keyword = Console.ReadLine().ToLower();
            bool found = false;

            foreach (var book in library)
            {
                if (book.Title.ToLower().Contains(keyword) || book.Author.ToLower().Contains(keyword))
                {
                    Console.WriteLine($"🔍 Found: {book.Title} by {book.Author} ({book.Year})");
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No matching books found.");
        }

        static void RemoveBook()
        {
            Console.Write("\nEnter the title of the book to remove: ");
            string title = Console.ReadLine();
            int removed = library.RemoveAll(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (removed > 0)
                Console.WriteLine("🗑️ Book removed successfully!");
            else
                Console.WriteLine("❌ Book not found.");
        }
    }
}
