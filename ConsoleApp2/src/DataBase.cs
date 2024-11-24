using System;
using System.IO;
using Microsoft.Data.Sqlite;

class DataBase
{
#region Constants
    private const string ConnectionString = "Data Source=" + Constants.DB_NAME;
#endregion

#region Public Methods
    public bool DBExists()
    {
        return File.Exists(Constants.DB_NAME);
    }
    public void CreateDB()
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users 
                (
                    AccountID INTEGER PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Surname TEXT NOT NULL,
                    Password TEXT NOT NULL,
                    CreationDate TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Operations 
                (
                    OperationID INTEGER PRIMARY KEY AUTOINCREMENT,
                    AccountID INTEGER NOT NULL,
                    OperationName INTEGER NOT NULL,
                    OperationType INTEGER NOT NULL,
                    OperationStatus INTEGER NOT NULL,
                    OperationCost REAL NOT NULL,
                    OperationDate TEXT NOT NULL,
                    FOREIGN KEY(AccountID) REFERENCES Users(AccountID)
                );";
            
            command.ExecuteNonQuery();
        }
    }
    public void SaveUser(User user)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Users (AccountID, Name, Surname, Password, CreationDate)
                VALUES ($id, $name, $surname, $password, $date)";

            cmd.Parameters.AddWithValue("$id", user.accountID);
            cmd.Parameters.AddWithValue("$name", user.name);
            cmd.Parameters.AddWithValue("$surname", user.surname);
            cmd.Parameters.AddWithValue("$password", user.password);
            cmd.Parameters.AddWithValue("$date", user.dateTime.ToString());
            
            cmd.ExecuteNonQuery();
        }
    }
    public void SaveOperation(Operation operation)
    {
        // TODO: Implement save operation logic
        /*
            1. Locate user record:
            - Find user by Account_ID
            - Validate user exists
            
            2. Update operation fields:
            - Operation Name
            - Operation Type
            - Operation Status
            - Operation Cost
            - Operation Date
            
            3. Write updates:
            - Read entire file
            - Update specific user's section
            - Write back entire file
            - Maintain file format integrity
            
            4. Error handling:
            - Handle file access errors
            - Handle user not found
            - Verify update success
        */
        Console.WriteLine("Save Operation Successful");
    }
    // Refactor this into a method that can be used for both password and accountID uniqueness checks
    public bool IsPasswordUnique(string password)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();
            
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Password = $password";
            cmd.Parameters.AddWithValue("$password", password);
            
            try
            {
                UInt16 count = Convert.ToUInt16(cmd.ExecuteScalar());
                return count == 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Database has too many entries to process this check");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error checking password uniqueness: {e.Message}");
                return false;
            }
        }
    }
    public bool IsAccountIDUnique(UInt64 accountID)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();
        
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE AccountID = $id";
            cmd.Parameters.AddWithValue("$id", accountID);
            
            try
            {
                UInt16 count = Convert.ToUInt16(cmd.ExecuteScalar());
                return count == 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Database has too many entries to process this check");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error checking account ID uniqueness: {e.Message}");
                return false;
            }
        }
    }
#endregion
// Essentailly the same function as IsAccountIDUnique but used for a different purpose
#region Private Methods
    // - UpdateUserRecord()
#endregion
}