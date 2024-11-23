using System;
using System.IO;

class DataBase
{
#region Public Methods
    public bool DBExists()
    {
        return File.Exists("2B.txt");
    }
    public void SaveUser(User user)
    {
        // TODO: Implement save user logic
        try
        {
            using (StreamWriter writer = new StreamWriter("2B.txt", true))
            {
                writer.WriteLine(user.ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving user: {e.Message}");
        }
        /*
            1. Format user data:
            - Create database entry format
            - Add separators (=====================)
            - Format all fields according to spec
            
            2. Write to file:
            - Check if file exists, create if not
            - Append user data to 2B.txt
            - Use proper file handling (using statement)
            
            3. Error handling:
            - Handle FileNotFoundException
            - Handle IOException
            - Handle UnauthorizedAccessException
            - Verify write success
        */
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
    public bool IsPasswordUnique(string password)
    {
        using (StreamReader reader = new StreamReader("2B.txt"))
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
#endregion

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