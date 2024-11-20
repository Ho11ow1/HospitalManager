using System;

class HospitalManager
{
    #region Fields
    private bool _loggedIn = false;
    private bool _running = true;
    private UInt16 _choice = 0;
    private readonly User _user = new User();
    private readonly Operations _operation = new Operations();
    #endregion

    #region Public Methods
    public void Fn_Run()
    {
        try
        {
            while (_running)
            {
                if (!_loggedIn)
                {
                    Console.WriteLine("Welcome to our HospitalManager app\n");

                    Console.WriteLine("Would you like to login or create a new account?");
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Create Account");
                    Console.WriteLine("3. Exit Program");

                    Console.Write("Choose option: ");
                    _choice = Convert.ToUInt16(Console.ReadLine());

                    switch (_choice)
                    {
                        case 1:
                            Console.Clear();
                            if (_user.Fn_LoginUser()) { _loggedIn = true; }
                        break;

                        case 2:
                            Console.Clear();
                            _user.Fn_CreateUser();
                            _loggedIn = true;
                        break;

                        case 3:
                            Console.WriteLine("Thank you for using our app...");
                            _running = false;
                        break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid input");
                            continue;
                        break;
                    }
                    continue;
                }

                while (_running && _loggedIn) 
                {
                    // Console.WriteLine("\n=== Hospital Menu ==="); // DEBUG LOG
                    Console.WriteLine("=== Hospital Menu ===");
                    Console.WriteLine("1. Show User Details");
                    Console.WriteLine("2. Set Operation");
                    Console.WriteLine("3. Show Operation Details");
                    Console.WriteLine("4. Logout");
                    Console.WriteLine("5. Exit Program");
                    Console.WriteLine("==================");

                    Console.Write("Choose option: ");
                    _choice = Convert.ToUInt16(Console.ReadLine());

                    Console.Clear();

                    switch (_choice)
                    {
                        case 1:
                            _user.Fn_ShowUserDetails();
                        break;

                        case 2:
                            _operation.Fn_SetOperation();
                        break;

                        case 3:
                            _operation.Fn_ShowOperationDetails();
                        break;

                        case 4:
                            _loggedIn = false;
                        break;

                        case 5:
                            Console.WriteLine("Thank you for using our app...");
                            _running = false;
                        break;

                        default:
                            Console.WriteLine("Invalid Input");
                            continue;
                        break;
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