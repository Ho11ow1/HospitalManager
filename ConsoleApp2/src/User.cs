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
            accountID = GenerateAccountID(); // Creative decision instead of using AUTOINCREMENT
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine($"Error registering user: {e.Message}");

            return false;
        }

        // DB.SaveUser(this); // Essentailly Pass the current user object to the function
        Console.WriteLine("Register Successful");

        return true;
    }
    //
    public bool Login()
    {
        UInt64 tempAccountID = Validation.GetValidNum("Enter your Account ID");
        string tempPassword = Validation.GetValidInput("Enter your password");

        // if (temp == real)
        // {
           // Assign each account value from DB
           // Assign each operation value from DB -- Probably a different method from operation class for ease of use which will probably be the case to call 2 methods so
           //                                                                                                                            if this returns true just load it
           // return true;
        // }

        // Seatch inside DB for user with matching Account ID and Password then compare with tempAccountID and tempPassword
        // If they match then load user data
        // Else throw exception or return false
        // TODO: Implement login logic
        /*
            1. Get user input with validation:
            - Account_ID (must be valid UInt64)
            - Password (3-24 chars)
            
            2. Check database:
            - Search for Account_ID
            - Verify password matches
            
            3. Handle outcomes:
            - Throw exception for invalid Account_ID
            - Throw exception for incorrect Password
            - Load user data if successful
            
            4. Session management:
            - Set login status
            - Load user's credentials and operation details
        */
        Console.WriteLine("Login Successful");
        return true;
    }
    //
    public void ShowDetails(User user)
    {                                                              // 1. Format user information:
        Console.WriteLine($"Account created: {user.dateTime}");    // - User Account Creation Date
        Console.WriteLine($"User ID: {user.accountID}");           // - User Account ID
        Console.WriteLine($"User name: {user.name}");              // - User Name
        Console.WriteLine($"User Surname: {user.surname}");        // - User Surname
        Console.WriteLine($"User Password: {user.password}");      // - User Password

        // Console.WriteLine("Show Details Successful"); // DEBUG LOG
    }
#endregion

#region Private Methods
    private UInt64 GenerateAccountID() // Creative decision instead of AUTOINCREMENT
    {
        Random random = new Random();
        return (UInt64)random.Next((int)Constants.USER_ID_MIN, (int)Constants.USER_ID_MAX);
    }
#endregion
}
