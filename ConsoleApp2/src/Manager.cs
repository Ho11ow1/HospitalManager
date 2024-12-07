using System;

class HospitalManager
{
#region Fields
    private bool loggedIn = false;
    private bool running = true;
    private UInt16 choice = 0;

    private readonly User user = new User();
    private readonly Operation operation = new Operation();
    private readonly DataBase DB = new DataBase();
#endregion

#region Public Methods
    public void Run()
    {
        if (!DB.DBExists())
        {
            DB.CreateDB();
        }
        try
        {
            while (running)
            {
                if (!loggedIn)
                {
                    Console.WriteLine("Welcome to our HospitalManager app\n");

                    Console.WriteLine("Would you like to login or create a new account?");
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Create Account");
                    Console.WriteLine("3. Exit Program");

                    Console.Write("Choose option: ");
                    choice = Convert.ToUInt16(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            if (user.Login()) { if (operation.LoginOperation(user.accountID)) {loggedIn = true;}}
                        break;

                        case 2:
                            Console.Clear();
                            if (user.Register()) {loggedIn = true;}
                        break;

                        case 3:
                            Console.WriteLine("Thank you for using our app...");
                            running = false;
                        break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid input");
                        continue;
                    }
                    continue;
                }

                while (running && loggedIn) 
                {
                    DB.CheckOperations(operation);
                    // Console.WriteLine("\n=== Hospital Menu ==="); // DEBUG LOG
                    Console.WriteLine("=== Hospital Menu ===");
                    Console.WriteLine("1. Show User Details");
                    Console.WriteLine("2. Set Operation");
                    Console.WriteLine("3. Show Operation Details");
                    Console.WriteLine("4. Logout");
                    Console.WriteLine("5. Exit Program");
                    if (operation.TimeToTreat == true)
                    {
                        Console.WriteLine("6. Take treatment");
                    }
                    Console.WriteLine("==================");

                    Console.Write("Choose option: ");
                    choice = Convert.ToUInt16(Console.ReadLine());

                    Console.Clear();

                    switch (choice)
                    {
                        case 1:
                            user.ShowDetails();
                        break;

                        case 2:
                            operation.SetOperation(user.accountID);
                        break;

                        case 3:
                            operation.ShowDetails(operation);
                        break;

                        case 4:
                            operation.TimeToTreat = false;
                            loggedIn = false;
                        break;

                        case 5:
                            Console.WriteLine("Thank you for using our app...");
                            running = false;
                        break;

                        case 6:
                            operation.Treat(operation);
                        break;

                        default:
                            Console.WriteLine("Invalid Input");
                        continue;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
#endregion
}