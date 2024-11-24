# HospitalManager

A simple and effective HospitalManager made in ```C#```

## Features

- User Authentication
  - Create and manage user accounts
  - Secure login with credentials
  - View detailed user information
  - Unique user IDs for each account

- Operation Management
  - Set medical operations with names
  - Track operation status (NULL, Pending, InProgress, Completed)
  - Define operation types (Medicine, Surgery, Checkup)
  - Manage operation dates and scheduling
  - Update operation status based on time of day
  - Fixed cost structure for each treatment type (ranging from 100 to 300)

- Data Persistence
  - Automatic database creation and management
  - Structured file storage with error handling
  - Record updating and maintenance
  - Data integrity checks

- Input Validation
  - Character length restrictions (3-24 characters)
  - Alphabetic input validation
  - Comprehensive error feedback
  - Null value handling

## Database Structure

The SQLite database (`2B.db`) contains two tables:

### Users Table
- AccountID (INTEGER PRIMARY KEY)
- Name (TEXT)
- Surname (TEXT)
- Password (TEXT)
- CreationDate (TEXT)

### Operations Table
- OperationID (INTEGER PRIMARY KEY AUTOINCREMENT)
- AccountID (INTEGER, FOREIGN KEY)
- OperationName (INTEGER)
- OperationType (INTEGER)
- OperationStatus (INTEGER)
- OperationCost (REAL)
- OperationDate (TEXT)

# Installation Guide

## Prerequisites
- Git installed
- .NET SDK installed
- Command line terminal (Command Prompt, PowerShell, or Terminal)

## Installation Steps

### 1. Clone the repository
```bash
git clone https://github.com/Ho11ow1/HospitalManager
```

### 2. Navigate to project directory
```bash
cd HospitalManager/ConsoleApp2
```

### 3. Build the program
```bash
dotnet build
```

### 4. Run the program
```bash
dotnet run
```

## Troubleshooting

If you encounter errors:

- Make sure you're in the correct directory
- Verify .NET is installed: `dotnet --version`
- Check if all source files exist: `dir src\*.cs`
- Ensure database file (`2B.db`) has proper read/write permissions

