# HospitalManager

A simple and effective HospitalManager made in ```C#```

## Features

- User Authentication
  - Create and manage user accounts
  - Login with credentials
  - View user details

- Operation Management
  - Set medical operations
  - Track operation history
  - Update operation status

- Data Persistence
  - Automatic database creation
  - Structured file storage
  - Error handling

- Input Validation
  - Character restrictions
  - Input sanitization
  - Error feedback

## Database Structure

The database file (`2B.txt`) follows this format:
```
=====================
Account Created: [`DateTime`]
Account ID: [`UInt64`]
User Name: [`string`]
User Surname: [`string`]
User Password: [`string`]
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

