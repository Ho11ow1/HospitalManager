using System;
using System.IO;

class DataBase
{
#region Constants
    private string SEPERATOR = "================================";
#endregion

#region Public Methods
    public bool DBExists()
    {
        return File.Exists(Constants.DB_NAME);
    }
    // Refactor this into a method that can be used for both user and operation saving
    public void SaveUser(User user)
    { // Pass the current user object to the function and save data to the DB
        try
        {
            using (StreamWriter writer = new StreamWriter(Constants.DB_NAME, true))
            {
                writer.WriteLine($"{SEPERATOR}");
                writer.WriteLine($"Account created: {user.dateTime}");
                writer.WriteLine($"User ID: {user.accountID}");
                writer.WriteLine($"User name: {user.name}");
                writer.WriteLine($"User Surname: {user.surname}");
                writer.WriteLine($"User Password: {user.password}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving user: {e.Message}");
        }
        Console.WriteLine("Save User Successful");
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
        using (StreamReader reader = new StreamReader(Constants.DB_NAME))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(password))
                {
                    return false;
                }
            }
        }
        return true;
    }
    public bool IsAccountIDUnique(UInt64 accountID)
    {
        using (StreamReader reader = new StreamReader(Constants.DB_NAME))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(accountID.ToString()))
                {
                    return false;
                }
            }
        }
        return true;
    }
#endregion
// Essentailly the same function as IsAccountIDUnique but used for a different purpose
#region Private Methods
    private bool FindUserInDatabase(string accountID)
    {
        using (StreamReader reader = new StreamReader("2B.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(accountID)) 
                {
                    return true;
                }
            }
        }
        return false;
    }
    // - UpdateUserRecord()
#endregion
}