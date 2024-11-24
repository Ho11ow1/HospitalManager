class User
{
#region Fields and Properties
    public DateTime dateTime { get; private set; } = DateTime.Now;
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
            name = Validation.GetValidInput("Enter your name");
            surname = Validation.GetValidInput("Enter your surname");
            password = Validation.GetValidInput("Enter your password");
            if (!DB.IsPasswordUnique(password))
            {
                throw new Exception("We're sorry but this password is already taken, please try a different one.");
            }
            accountID = GenerateAccountID();
            if (!DB.IsAccountIDUnique(accountID))
            {
                throw new Exception("We're sorry but this Account ID is already taken, please try again.");
            }
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine($"Error registering user: {e.Message}");

            return false;
        }

        DB.SaveUser(this); // Essentailly Pass the current user object to the function
        Console.WriteLine("Register Successful");

        return true;
    }
    //
    public bool Login()
    {
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
    public void ShowDetails(User user, Operation? operation)
    {
        try
        {// Refactor this into reading data from the DB                // 1. Format user information:
            Console.WriteLine($"Account created: {user.dateTime}");    // - User Account Creation Date
            Console.WriteLine($"User ID: {user.accountID}");           // - User Account ID
            Console.WriteLine($"User name: {user.name}");              // - User Name
            Console.WriteLine($"User Surname: {user.surname}");        // - User Surname
            Console.WriteLine($"User Password: {user.password}");      // - User Password

            if (operation != null)
            {                                                                           // 2. Format operation details:
                Console.WriteLine($"Operation Name: {operation.operationName}");        // - Operation Name
                Console.WriteLine($"Operation Type: {operation.operationType}");        // - Operation Type
                Console.WriteLine($"Operation Status: {operation.operationStatus}");    // - Operation Status
                Console.WriteLine($"Operation Cost: {operation.operationCost}");        // - Operation Cost
                Console.WriteLine($"Operation Date: {operation.operationDate}");        // - Operation Date
            }
            //Console.WriteLine("Show Details Successful"); // DEBUG LOG
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine($"Error showing user details: {e.Message}");
        }
        // TODO: Implement show details logic
        /*
            3. Display formatting:
            - Add separators for readability
            - Handle NULL values appropriately
            
            4. Error handling:
            - Verify data exists
            - Handle missing information
        */
        Console.WriteLine("Show Details Successful");
    }
#endregion

#region Private Methods
    private UInt64 GenerateAccountID()
    {
        Random random = new Random();
        return (UInt64)random.Next((int)Constants.USER_ID_MIN, (int)Constants.USER_ID_MAX);
    }
#endregion
}
