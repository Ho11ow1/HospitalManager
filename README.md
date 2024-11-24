# HospitalManager

A simple and effective Hospital Management System made in `C#` specializing in mental health treatments.

## Features

- User Authentication
  - Create and manage user accounts
  - Secure login with credentials
  - View detailed user information
  - Unique user IDs for each account

- Mental Health Operation Management
  - Five specialized treatments:
    - Anxiety Treatment (€150)
    - Schizophrenia Treatment (€300)
    - Depression Treatment (€100)
    - Bipolar Disorder Treatment (€250)
    - Panic Attack Treatment (€200)
  - Track operation status (Pending, InProgress, Completed)
  - Three operation types:
    - Medicine
    - Surgery
    - Checkup
  - Manage operation dates and scheduling
  - Update operation status based on time of day

- Data Persistence
  - Automatic SQLite database creation and management
  - Structured file storage with error handling
  - Record updating and maintenance
  - Data integrity checks and constraints

- Input Validation
  - Character length restrictions (3-24 characters)
  - Alphabetic input validation
  - Comprehensive error feedback
  - Null value handling

## Database Structure

The SQLite database (`2B.db`) contains two tables:

### Users Table
- AccountID (INTEGER PRIMARY KEY)
- Name (TEXT NOT NULL)
- Surname (TEXT NOT NULL)
- Password (TEXT NOT NULL)
- CreationDate (TEXT NOT NULL, ISO 8601 format: YYYY-MM-DD HH:MM:SS)

### Operations Table
- OperationID (INTEGER PRIMARY KEY AUTOINCREMENT)
- AccountID (INTEGER, FOREIGN KEY)
- OperationName (INTEGER, maps to enum: 0-5)
- OperationType (INTEGER, maps to enum: 0-3)
- OperationStatus (INTEGER, maps to enum: 0-3)
- OperationCost (REAL, non-negative values)
- OperationDate (TEXT, ISO 8601 format: YYYY-MM-DD HH:MM:SS)

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
- Verify SQLite dependencies are properly installed
