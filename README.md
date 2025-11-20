# 📚 Library Management System

A modern, console-based Library Management System built with C# and .NET 9.0. This application provides a complete solution for managing a personal or small library collection with an intuitive text-based interface and persistent JSON storage.

## ✨ Features

- **📖 Add Books** - Add new books with title, author, and publication year
- **👀 View All Books** - Display the complete library collection with formatted output
- **🔍 Search Books** - Search by title or author with case-insensitive matching
- **✏️ Update Books** - Modify book details (title, author, or year)
- **🗑️ Remove Books** - Delete books with confirmation prompts
- **💾 Persistent Storage** - Automatic data persistence using JSON file storage
- **✅ Input Validation** - Comprehensive validation for user inputs
- **🎨 User-Friendly Interface** - Clean, intuitive menu-driven console interface

## 🏗️ Project Structure

The application follows a clean, modular architecture with separation of concerns:

```
C--project/
├── src/
│   ├── Program.cs       # Application entry point
│   ├── Book.cs          # Book model/entity
│   ├── Library.cs       # Core business logic and operations
│   ├── DataManager.cs   # JSON data persistence layer
│   ├── UIManager.cs     # User interface and menu system
│   └── library-manager.csproj
├── C--project.sln       # Visual Studio solution file
└── README.md
```

### Architecture Overview

- **`Book.cs`**: Defines the Book entity with properties (Id, Title, Author, Year)
- **`Library.cs`**: Manages the book collection and business operations (CRUD operations)
- **`DataManager.cs`**: Handles data persistence to/from JSON file
- **`UIManager.cs`**: Manages all user interactions and console I/O
- **`Program.cs`**: Application entry point that initializes and runs the system

## 🚀 Getting Started

### Prerequisites

- [.NET SDK 9.0](https://dotnet.microsoft.com/download) or later
- Any text editor or IDE (Visual Studio, Visual Studio Code, Rider, etc.)

### Installation & Running

#### Option 1: Using .NET CLI (Recommended)

1. **Clone the repository:**
   ```bash
   git clone https://github.com/thimira20011/C--project.git
   cd C--project
   ```

2. **Build the project:**
   ```bash
   dotnet build
   ```

3. **Run the application:**
   ```bash
   dotnet run --project src/library-manager.csproj
   ```

#### Option 2: Using Visual Studio

1. Open `C--project.sln` in Visual Studio
2. Press `F5` or click "Start" to build and run
3. The console window will appear with the application menu

#### Option 3: Build and Run Executable

```bash
cd C--project
dotnet build -c Release
cd src/bin/Release/net9.0
./library-manager
```

## 📖 Usage Guide

### Main Menu

When you run the application, you'll see the following menu:

```
====== Advanced Library Management System ======
1. Add Book
2. View All Books
3. Search Books
4. Update Book
5. Remove Book
6. Exit
Choose an option:
```

### Example Workflow

1. **Add a Book:**
   - Select option `1`
   - Enter title: `The Great Gatsby`
   - Enter author: `F. Scott Fitzgerald`
   - Enter year: `1925`
   - Book is added with auto-generated ID

2. **View All Books:**
   - Select option `2`
   - See all books in format: `[ID] Title by Author (Year)`

3. **Search Books:**
   - Select option `3`
   - Enter search term (matches title or author)
   - View matching results

4. **Update a Book:**
   - Select option `4`
   - Enter book ID
   - Enter new values (leave blank to keep current)
   - Changes are saved automatically

5. **Remove a Book:**
   - Select option `5`
   - Enter book ID
   - Confirm deletion (y/n)
   - Book is removed from the library

### Data Storage

- Library data is automatically saved to `library.json` in the application directory
- Data persists between application sessions
- File is created automatically on first use
- Uses human-readable JSON format for easy inspection

## 🛠️ Technology Stack

- **Language**: C# 9.0+
- **Framework**: .NET 9.0
- **Data Format**: JSON
- **Serialization**: System.Text.Json
- **Architecture**: Object-Oriented, Separation of Concerns

## 🧪 Development

### Building for Development

```bash
dotnet build
```

### Building for Release

```bash
dotnet build -c Release
```

### Code Style

The project follows standard C# coding conventions:
- PascalCase for class names and public members
- camelCase for private fields and local variables
- Meaningful variable and method names
- Comprehensive error handling

## 🤝 Contributing

Contributions are welcome! Here's how you can help:

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/AmazingFeature`)
3. **Commit** your changes (`git commit -m 'Add some AmazingFeature'`)
4. **Push** to the branch (`git push origin feature/AmazingFeature`)
5. **Open** a Pull Request

### Contribution Guidelines

- Ensure your code follows the existing style and conventions
- Add comments for complex logic
- Test your changes thoroughly
- Update documentation if needed
- Keep commits focused and well-described

### Ideas for Contribution

- Add unit tests
- Implement book categories/genres
- Add ISBN support
- Create a book lending/borrowing system
- Add export/import functionality (CSV, XML)
- Implement book ratings and reviews
- Add multi-user support

## 📝 License

This project is currently unlicensed. Feel free to use it for educational purposes. If you plan to use or distribute this code, please consider adding an appropriate license (such as MIT or Apache 2.0).

## 👤 Author

**thimira20011**
- GitHub: [@thimira20011](https://github.com/thimira20011)

## 🙏 Acknowledgments

- Built as a learning project to demonstrate C# fundamentals
- Showcases OOP principles and clean code architecture
- Inspired by real-world library management needs

---

⭐ If you find this project useful, please consider giving it a star!

**Happy Reading! 📚✨**
