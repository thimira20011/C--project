namespace LibraryManager
{
    // Main program entry point
    class Program
    {
        static void Main()
        {
            Library library = new Library();
            UIManager uiManager = new UIManager(library);
            uiManager.Run();
        }
    }
}
