using System;
using System.Linq;

class User
{
    #region Fields and Properties
    private readonly Operations _operation = new Operations();
    private readonly Random _random = new Random();
    private readonly DataBase _database = new DataBase();

    internal string UserName { get; private set; } = "";
    internal string UserSurname { get; private set; } = "";
    internal string UserPassword { get; private set; } = "";
    public UInt64 UserId { get; private set; }
    #endregion

    #region Constants
    private const string NAME_PREFIX = "User Name: ";
    private const string SURNAME_PREFIX = "User Surname: ";
    private const string PASSWORD_PREFIX = "User Password: ";
    private const string SEPARATOR = "=====================";
    #endregion

    #region Public Methods
    public void Fn_CreateUser()
    {
        if (!_database.Fn_DB_Exist())
        {
            Console.WriteLine("Database does not exist, creating new database...");
        }

        UserName = Fn_GetValidInput("Enter User Name", Constants.MIN_LENGTH, Constants.MAX_LENGTH);
        UserSurname = Fn_GetValidInput("Enter User Surname", Constants.MIN_LENGTH, Constants.MAX_LENGTH);
        UserPassword = Fn_GetValidInput("Enter User Password", Constants.MIN_LENGTH, Constants.MAX_LENGTH);
        UserId = Fn_GetID();
        
        _database.Fn_Save_To_DB(this); // Same as _database.Fn_Save_To_DB(UserName, UserSurname, UserPassword, UserId);
    }

    public bool Fn_LoginUser()
    {
        // Get user credentials from console input as a tuple (name, surname, password)
        var inputData = Fn_GetUserInput();
        bool userFound = false;

        Console.Clear();
        // Console.WriteLine("=== Login ===\n"); // DEBUG LOG
        try
        {
            using (StreamReader sr = new StreamReader(Constants.DB_NAME))
            {
                string line;
                string tempUserName = "", tempUserSurname = "", tempUserPassword = "";

                while ((line = sr.ReadLine()) != null) // while std::getline(file, line)
                {
                    if (line.StartsWith(NAME_PREFIX)) // line.find(NAME_PREFIX) != string::npos
                    {
                        tempUserName = line.Substring(NAME_PREFIX.Length).Trim(); // line.substr(NAME_PREFIX.length())
                    }
                    else if (line.StartsWith(SURNAME_PREFIX))
                    {
                        tempUserSurname = line.Substring(SURNAME_PREFIX.Length).Trim();
                    }
                    else if (line.StartsWith(PASSWORD_PREFIX))
                    {
                        tempUserPassword = line.Substring(PASSWORD_PREFIX.Length).Trim();
                    }
                    else if (line.Contains(SEPARATOR)) // line.find(SEPARATOR) != string::npos
                    {
                        // Check if current user record matches input credentials
                        if (Fn_ValidateLogin((tempUserName, tempUserSurname, tempUserPassword), inputData))
                        {
                            // If match found, set user data and exit loop
                            Fn_SetUserData((tempUserName, tempUserSurname, tempUserPassword));
                            userFound = true;
                            break;  // Found the user, no need to continue reading
                        }
                        // Reset temp for next user login
                        tempUserName = tempUserSurname = tempUserPassword = "";
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading from database: {e.Message}");
            return false;
        }

        // Console.WriteLine(userFound ? $"Login successful\n{SEPARATOR}" : $"Login failed\n{SEPARATOR}\n"); // DEBUG LOG
        return userFound;
    }

    public void Fn_ShowUserDetails()
    {
        Console.WriteLine("=== User Details ===");
        Console.WriteLine($"User Name: {UserName}");
        Console.WriteLine($"User Surname: {UserSurname}");
        Console.WriteLine($"User Password: {UserPassword}");
        Console.WriteLine($"Operation: {_operation.Operation}");
        Console.WriteLine("===================\n");
    }

    public UInt64 Fn_GetID() => Fn_SetID();
    #endregion

    #region Input and Validation Methods
    private string Fn_GetValidInput(string prompt, UInt16 minLength, UInt16 maxLength)
    {
        string input;
        do
        {
            Console.Write($"{prompt} ({minLength}-{maxLength} characters, letters only): ");
            input = Console.ReadLine()?.Trim() ?? "";
        }
        while (!Fn_ValidateInput(input, minLength, maxLength));

        return input;
    }

    private bool Fn_ValidateInput(string input, UInt16 minLength, UInt16 maxLength)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input cannot be empty.");
            return false;
        }

        if (!Fn_IsAlpha(input))
        {
            Console.WriteLine("Input must contain only letters.");
            return false;
        }

        UInt16 length = (UInt16)input.Length;
        if (length < minLength || length > maxLength)
        {
            Console.WriteLine($"Input must be between {minLength} and {maxLength} characters long.");
            return false;
        }

        return true;
    }

    private bool Fn_IsAlpha(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return false;
        }

        return str.All(char.IsLetter);
    }
    #endregion

    #region Helper Methods
    private (string name, string surname, string password) Fn_GetUserInput()
    {
        Console.Write("Input User Name: ");
        string inputUserName = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Input User Surname: ");
        string inputUserSurname = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Input User Password: ");
        string inputUserPassword = Console.ReadLine()?.Trim() ?? "";

        return (inputUserName, inputUserSurname, inputUserPassword);
    }

    private bool Fn_ValidateLogin((string name, string surname, string password) stored, (string name, string surname, string password) input)
    {
        return (stored.name == input.name) && (stored.surname == input.surname) && (stored.password == input.password);
    }

    private void Fn_SetUserData((string name, string surname, string password) userData)
    {
        UserName = userData.name;
        UserSurname = userData.surname;
        UserPassword = userData.password;
    }

    private UInt64 Fn_SetID()
    {
        return (UInt64)Math.Abs(_random.NextInt64());
    }
    #endregion
}
