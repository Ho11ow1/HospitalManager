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
            cmd.Parameters.AddWithValue("$date", user.dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            
            cmd.ExecuteNonQuery();
        }
    }
    public void SaveOperation(Operation operation)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Operations (AccountID, OperationName, OperationType, OperationStatus, OperationCost, OperationDate)
                VALUES ($AID, $Oname, $Otype, $Ostatus, $Ocost, $Odate)";

            // cmd.Parameters.AddWithValue("$AID", user.accountID); // Not 100% sure about foreign key to link to User account table
            cmd.Parameters.AddWithValue("$Oname", operation.disorder);
            cmd.Parameters.AddWithValue("$Otype", operation.treatment);
            cmd.Parameters.AddWithValue("$Ostatus", operation.status);
            cmd.Parameters.AddWithValue("$Ocost", operation.cost);
            cmd.Parameters.AddWithValue("$Odate", operation.date.ToString("yyyy-MM-dd HH:mm:ss"));

            cmd.ExecuteNonQuery();
        }
        Console.WriteLine("Save Operation Successful");
    }
#endregion
// Essentailly the same function as IsAccountIDUnique but used for a different purpose
#region Private Methods
    // - UpdateUserRecord()
#endregion
}