class User
{
#region Fields and Properties
    private string name;
    private string surname;
    private string password;
    private UInt64 accountID;

    private DataBase DB = new DataBase();
#endregion

#region Public Methods
    public void Register()
    {
        try
        {
            name = Validation.GetValidInput("Enter your name");
            surname = Validation.GetValidInput("Enter your surname");
            password = Validation.GetValidInput("Enter your password");
            if (!DB.IsPasswordUnique(password))
            {
                throw new Exception("2 Users cannot have the same password");
            }
            accountID = GenerateAccountID();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error registering user: {e.Message}");
        }
        // TODO: Implement register logic
        /*
            2. Check database:
            - Generate unique Account_ID
            - Verify user doesn't already exist
            
            3. Create new user:
            - Create timestamp for Account Created
            - Initialize Operation fields to NULL
            - Format data according to database structure
            
            4. Save to database:
            - Write new user data to file
            - Handle any I/O exceptions
            
            5. Return success/failure:
            - Throw specific exceptions for each failure case
            - Confirm success to user
        */
        Console.WriteLine("Register Successful");
    }

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

    public void ShowDetails()
    {
        // TODO: Implement show details logic
        /*
            1. Format user information:
            - Account ID
            - Name and Surname
            - Account Creation Date
            
            2. Format operation details (if exists):
            - Operation Name
            - Operation Type
            - Operation Status
            - Operation Cost
            - Operation Date
            
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
