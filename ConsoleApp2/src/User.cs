using System;
using ConsoleApp2.src.util;

class User
{
    #region Fields and Properties
    
    #endregion

    #region Constants

    #endregion

    #region Public Methods
    public void Register()
    {
        // TODO: Implement register logic
        /*
            1. Get user input with validation:
               - Name (3-24 chars, alphabetic)
               - Surname (3-24 chars, alphabetic)
               - Password (3-24 chars, non-whitespace)
            
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

    public void Login()
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

    #region Helper Methods

    #endregion
}
