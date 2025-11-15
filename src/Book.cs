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
}
