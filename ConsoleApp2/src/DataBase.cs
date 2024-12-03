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
                    AccountID INTEGER NOT NULL,
                    Disorder INTEGER NOT NULL,
                    Treatment INTEGER NOT NULL,
                    Status INTEGER NOT NULL,
                    Cost REAL NOT NULL,
                    Date TEXT NOT NULL,
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
                VALUES ($AccountID, $Name, $Surname, $Password, $Date)";

            cmd.Parameters.AddWithValue("$AccountID", user.accountID);
            cmd.Parameters.AddWithValue("$Name", user.name);
            cmd.Parameters.AddWithValue("$Surname", user.surname);
            cmd.Parameters.AddWithValue("$Password", user.password);
            cmd.Parameters.AddWithValue("$Date", user.dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            
            cmd.ExecuteNonQuery();
        }
        // Console.WriteLine("Save User Successful");
    }

    public void SaveOperation(Operation operation)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Operations (AccountID, Disorder, Treatment, Status, Cost, Date)
                VALUES ($accountId, $disorder, $treatment, $status, $cost, $date)";

            cmd.Parameters.AddWithValue("$accountId", operation.oaccountID);
            cmd.Parameters.AddWithValue("$disorder", (int)operation.disorder + 1);
            cmd.Parameters.AddWithValue("$treatment", (int)operation.treatment + 1);
            cmd.Parameters.AddWithValue("$status", (int)operation.status + 1);
            cmd.Parameters.AddWithValue("$cost", operation.cost);
            cmd.Parameters.AddWithValue("$date", operation.date.ToString("yyyy-MM-dd HH:mm:ss"));

            cmd.ExecuteNonQuery();
        }
        // Console.WriteLine("Save Operation Successful");
    }

    public void DisplayOperation(Operation operation)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Disorder, Treatment, Status, Cost, Date 
                FROM Operations
                WHERE AccountID = @AccountID
                ORDER BY Date ASC";

            cmd.Parameters.AddWithValue("@AccountID", operation.oaccountID);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Disorder: {0}, Treatment: {1}, Status: {2}, Cost: {3}, Date: {4}",
                        reader["Disorder"],
                        reader["Treatment"],
                        reader["Status"],
                        reader["Cost"],
                        reader["Date"]);
                }
            }
        }
    }

    #endregion

    #region Private Methods
    #endregion
}