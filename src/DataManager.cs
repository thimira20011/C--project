using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LibraryManager
{
    // Handles data persistence for the library
    class DataManager
    {
        private const string FilePath = "library.json"; // Save file

        public List<Book> LoadData()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Book>();
            }

            try
            {
                string json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
            }
            catch (Exception ex) when (ex is IOException || ex is JsonException)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                // Return an empty list if loading fails
                return new List<Book>();
            }
        }

        public void SaveData(List<Book> books)
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
    }
}
