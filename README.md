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

The database file (`2B.txt`) follows this format:
```
=====================
Account Created: [DateTime]
Account ID: [UInt64]
User Name: [string]
User Surname: [string]
User Password: [string]
Operation Name: [string]
Operation Type: [Medicine|Surgery|Checkup]
Operation Status: [NULL|Pending|InProgress|Completed]
Operation Date: [DateTime?]
=====================
```

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
- Ensure database file (`2B.txt`) has proper read/write permissions

