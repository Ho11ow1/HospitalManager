using Microsoft.Data.Sqlite;

class User
{
#region Fields and Properties
    public DateTime dateTime { get; private set; }
    public string name { get; private set; }
    public string surname { get; private set; }
    public string password { get; private set; }
    public UInt64 accountID { get; private set; }

    private DataBase DB = new DataBase();
    #endregion

    #region Public Methods

    public bool Register()
    {
        try
        {
            dateTime = DateTime.Now;
            name = Validation.GetValidInput("Enter your name");
            surname = Validation.GetValidInput("Enter your surname");
            password = Validation.GetValidInput("Enter your password");
            accountID = GenerateAccountID(); // Creative decision
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine($"Error registering user: {e.Message}");

            return false;
        }

        DB.SaveUser(this);
        Console.WriteLine("Register Successful");

        return true;
    }
    //
    public bool Login()
    {
        UInt64 tempAccountID = Validation.GetValid64("Enter your Account ID");
        string tempPassword = Validation.GetValidInput("Enter your password");

        using (var connection = new SqliteConnection(DataBase.ConnectionString))
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Name, Surname, CreationDate
                FROM Users
                WHERE AccountID = @AccountID AND Password = @Password";

            cmd.Parameters.AddWithValue("@AccountID", tempAccountID);
            cmd.Parameters.AddWithValue("@Password", tempPassword);

            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                {
                    Console.WriteLine("Login failed: Invalid Account ID or Password.");
                    return false;
                }

                dateTime = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
                name = reader.GetString(reader.GetOrdinal("Name"));
                surname = reader.GetString(reader.GetOrdinal("Surname"));
                password = tempPassword;
                accountID = tempAccountID;

            }
        }
        // Console.WriteLine("Login Successful");
        return true;
    }
    //
    public void ShowDetails(User user)
    {
        Console.WriteLine($"Account created: {user.dateTime}");
        Console.WriteLine($"User ID: {user.accountID}");
        Console.WriteLine($"User name: {user.name}");
        Console.WriteLine($"User Surname: {user.surname}");
        Console.WriteLine($"User Password: {user.password}");

        // Console.WriteLine("Show Details Successful"); // DEBUG LOG
    }
#endregion

#region Private Methods
    private UInt64 GenerateAccountID() // Creative decision
    {
        Random random = new Random();
        return (UInt64)random.Next((int)Constants.USER_ID_MIN, (int)Constants.USER_ID_MAX);
    }
#endregion
}
