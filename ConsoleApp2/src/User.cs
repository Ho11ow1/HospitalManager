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
        { // Set user details
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
        try
        {
            UInt64 tempAccountID = Validation.GetValid64("Enter your Account ID");
            string tempPassword = Validation.GetValidInput("Enter your password");

            // Query DB, If exists laod User & Operation, else return

            //if (!DB.FindUser(tempAccountID))
            //{
            //    return false;
            //}

            //dateTime = DateTime.Now;
            //name = DB;
            //surname = DB;
            //password = DB;
            //accountID = DB;

            //LoadOperation();

            Console.WriteLine("Login Successful");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Login failed: {e.Message}");
            return false;
        }
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
