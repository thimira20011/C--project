# Project Overview

This is a simple console-based Library Management application written in C#. It allows users to manage a collection of books with functionalities to add, view, search, update, and remove books. The application persists the library data to a `library.json` file.

The core logic is contained within the `program.cs` file, which defines the `Book` model, the `Library` class for operations, and the `Program` class for the main entry point and user interface.

# Building and Running

To build and run this project, you need the .NET SDK or the C# compiler (csc) installed.

**Option A: Using the C# compiler (csc)**

1.  **Build:**
    ```sh
    csc program.cs
    ```

2.  **Run:**
    ```sh
    ./program.exe
    ```
    (On Windows, you can run `program.exe`)

**Option B: Using the .NET SDK**

1.  **Create a new console project in a temporary directory:**
    ```sh
    mkdir tmp && cd tmp
    dotnet new console --force
    ```

2.  **Replace the content of `Program.cs` in the `tmp` directory with the content of the project's `program.cs` file.**

3.  **Run the application:**
    ```sh
    dotnet run
    ```

# Development Conventions

*   **Code Style:** The code follows standard C# conventions.
*   **Data Storage:** The library data is stored in a JSON file named `library.json`.
*   **Error Handling:** The application includes basic error handling for file I/O and user input.
*   **User Interface:** The user interface is a simple text-based menu in the console.
