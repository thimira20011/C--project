using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LibraryManager
{
    // Represents a single Book entity
    class Book
    {
        public int Id { get; set; }  // Auto-generated unique ID
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Title} by {Author} ({Year})";
        }
    }

    // Handles all operations related to the Library
    class Library
    {
        private List<Book> books = new List<Book>();
        private const string FilePath = "library.json"; // Save file

        public Library()
        {
            LoadData();
        }

        public void AddBook()
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

            int nextId = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
            Book newBook = new Book { Id = nextId, Title = title, Author = author, Year = year };
            books.Add(newBook);
            SaveData();

            Console.WriteLine($"✅ Book added successfully! ID = {newBook.Id}");
        }

        public void ViewBooks()
        {
            Console.WriteLine("\n--- All Books ---");
            if (books.Count == 0)
            {
                Console.WriteLine("No books available in the library.");
                return;
            }

            foreach (var book in books)
                Console.WriteLine(book);
        }

        public void SearchBooks()
        {
            Console.Write("\nEnter title or author to search: ");
            string keyword = Console.ReadLine().ToLower();
            var results = books.FindAll(b =>
                b.Title.ToLower().Contains(keyword) ||
                b.Author.ToLower().Contains(keyword));

            if (results.Count == 0)
                Console.WriteLine("No matching books found.");
            else
            {
                Console.WriteLine("\n--- Search Results ---");
                foreach (var b in results)
                    Console.WriteLine(b);
            }
        }

        public void RemoveBook()
        {
            Console.Write("\nEnter the ID of the book to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            var bookToRemove = books.Find(b => b.Id == id);
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
                books.Remove(bookToRemove);
                SaveData();
                Console.WriteLine("🗑️ Book removed successfully!");
            }
            else
            {
                Console.WriteLine("Remove operation cancelled.");
            }
        }

        public void UpdateBook()
        {
            Console.Write("\nEnter the ID of the book to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            var book = books.Find(b => b.Id == id);
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

            if (!string.IsNullOrWhiteSpace(title)) book.Title = title;
            if (!string.IsNullOrWhiteSpace(author)) book.Author = author;
            if (!string.IsNullOrWhiteSpace(yearInput))
            {
                if (int.TryParse(yearInput, out int newYear))
                {
                    book.Year = newYear;
                }
                else
                {
                    Console.WriteLine("Invalid year format. Year not updated.");
                }
            }


            SaveData();
            Console.WriteLine("✏️ Book updated successfully!");
        }

        // --- Data Persistence Methods ---
        private void SaveData()
        {
            try
            {
                string json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex) when (ex is IOException || ex is JsonException)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        private void LoadData()
        {
            if (!File.Exists(FilePath)) return;
            try
            {
                string json = File.ReadAllText(FilePath);
                books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
            }
            catch (Exception ex) when (ex is IOException || ex is JsonException)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                // Optional: Handle the error more gracefully, e.g., by starting with an empty library
                books = new List<Book>();
            }
        }
    }

    // Main program entry point
    class Program
    {
        static void Main()
        {
            Library library = new Library();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n====== Advanced Library Management System ======");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Search Books");
                Console.WriteLine("4. Update Book");
                Console.WriteLine("5. Remove Book");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": library.AddBook(); break;
                    case "2": library.ViewBooks(); break;
                    case "3": library.SearchBooks(); break;
                    case "4": library.UpdateBook(); break;
                    case "5": library.RemoveBook(); break;
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
    }
}
