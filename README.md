# C--project

Simple console-based Library Management application written in C#.

## Overview
This small program implements a text-menu driven library manager that allows adding, viewing, searching, and removing books. Core types and logic live in `program.cs`:

- Book model: `LibraryManager.Book` (`program.cs`)  
- Application entry + menu: `LibraryManager.Program` (`program.cs`)  
- Operations: `LibraryManager.Program.AddBook`, `LibraryManager.Program.ViewBooks`, `LibraryManager.Program.SearchBook`, `LibraryManager.Program.RemoveBook`

## Features
- Add a book (title, author, year)
- View all books
- Search books by title or author
- Remove a book by title

## Prerequisites
- .NET SDK (recommended) or the C# compiler (`csc`). Mono can be used to run the compiled executable on macOS/Linux.

## Build & Run

Option A — using csc (C# compiler):
```sh
csc program.cs
# On Windows:
program.exe
# On macOS/Linux (with Mono installed):
mono program.exe
```

Option B — using the dotnet SDK:
```sh
mkdir tmp && cd tmp
dotnet new console --force
# Replace the generated Program.cs content with the project's program.cs (one level up)
dotnet run
```

If you prefer a quick test without creating a new project, compile with `csc` as above and run the produced executable.

## Usage
Run the compiled executable and follow the on-screen menu:

1 — Add Book  
2 — View All Books  
3 — Search for a Book  
4 — Remove a Book  
5 — Exit

Follow prompts to enter book details when adding or searching. Search supports title or author matching.

## Contributing
Small improvements, bug fixes, and formatting tweaks are welcome. Please open a pull request with your changes or submit an issue describing the problem.

Guidelines:
- Keep changes focused and well-documented.
- Include a short description in the PR/commit message.
- Add tests or manual verification steps if applicable.

## License
This repository currently has no license. Add a LICENSE file if you want to specify terms. If you'd like, I can suggest a license to add (e.g., MIT, Apache 2.0) and provide the file content.

Thank you!
