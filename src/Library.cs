using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManager
{
    // Handles all operations related to the Library
    class Library
    {
        private List<Book> books;
        private readonly DataManager dataManager;

        public Library()
        {
            dataManager = new DataManager();
            books = dataManager.LoadData();
        }

        public void AddBook(string title, string author, int year)
        {
            int nextId = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
            Book newBook = new Book { Id = nextId, Title = title, Author = author, Year = year };
            books.Add(newBook);
            dataManager.SaveData(books);
            Console.WriteLine($"✅ Book added successfully! ID = {newBook.Id}");
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public List<Book> SearchBooks(string keyword)
        {
            return books.FindAll(b =>
                b.Title.ToLower().Contains(keyword.ToLower()) ||
                b.Author.ToLower().Contains(keyword.ToLower()));
        }

        public Book FindBookById(int id)
        {
            return books.Find(b => b.Id == id);
        }

        public bool RemoveBook(int id)
        {
            var bookToRemove = books.Find(b => b.Id == id);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                dataManager.SaveData(books);
                return true;
            }
            return false;
        }

        public void UpdateBook(Book book, string title, string author, int? year)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                book.Title = title;
            }
            if (!string.IsNullOrWhiteSpace(author))
            {
                book.Author = author;
            }
            if (year.HasValue)
            {
                book.Year = year.Value;
            }
            dataManager.SaveData(books);
        }
    }
}
