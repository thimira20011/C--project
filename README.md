# C--project

Simple console-based Library Management application written in C#.

## Overview
This small program implements a text-menu driven library manager that allows adding, viewing, searching, and removing books. Core types and logic live in [program.cs](program.cs):
- Book model: [`LibraryManager.Book`](program.cs)  
- Application entry + menu: [`LibraryManager.Program`](program.cs)  
- Operations: [`LibraryManager.Program.AddBook`](program.cs), [`LibraryManager.Program.ViewBooks`](program.cs), [`LibraryManager.Program.SearchBook`](program.cs), [`LibraryManager.Program.RemoveBook`](program.cs)

## Features
- Add a book (title, author, year)
- View all books
- Search books by title or author
- Remove a book by title

## Prerequisites
- .NET SDK or the C# compiler (csc).

## Build & Run
Option A — using csc (C# compiler):
```sh
csc program.cs
./program.exe   # on Windows: program.exe
```

Option B — using dotnet SDK:
```sh
mkdir tmp && cd tmp
dotnet new console --force
# replace Program.cs content with ../program.cs content, then:
dotnet run
```

## Usage
Run the compiled executable. Use the on-screen menu to choose:
1 — Add Book  
2 — View All Books  
3 — Search for a Book  
4 — Remove a Book  
5 — Exit

## Contributing
Small improvements, bug fixes, and formatting tweaks welcome. Open a pull request.

## License
Unlicensed — add a LICENSE file if you want to specify terms.
