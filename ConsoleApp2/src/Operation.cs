using Microsoft.Data.Sqlite;
using System.ComponentModel;

class Operation
{
#region Properties
    public Disorder disorder { get; private set; }
    public Treatment treatment { get; private set; }
    public Status status { get; private set; }
    public double cost { get; private set; }
    public DateTime date { get; private set; }
    public UInt64 oaccountID { get; private set; }
    public bool TimeToTreat = false;

    private UInt16 choice;
    private DataBase DB = new DataBase();
#endregion

#region Public Methods
    public void SetOperation(UInt64 accountID)
    {
        try
        {
            Console.WriteLine($"1. {Disorder.Anxiety}");
            Console.WriteLine($"2. {Disorder.Schizophrenia}");
            Console.WriteLine($"3. {Disorder.Depression}");
            Console.WriteLine($"4. {Disorder.Bipolar}");
            Console.WriteLine($"5. {Disorder.PanicAttack}");
            Console.WriteLine($"6. Go back\n");

            choice = Validation.GetValidNum("Which mental disorder do you have");
            if (choice == 6)
            {
                return;
            }

            disorder = ((Disorder)choice - 1);
            switch (disorder)
            {
                case Disorder.Anxiety:
                    cost = (double)Cost.AnxietyTreatment;
                    treatment = Treatment.Medication;
                    break;
                case Disorder.Schizophrenia:
                    cost = (double)Cost.SchizophreniaTreatment;
                    treatment = Treatment.Checkup;
                    break;
                case Disorder.Depression:
                    cost = (double)Cost.DepressionTreatment;
                    treatment = Treatment.Medication;
                    break;
                case Disorder.Bipolar:
                    cost = (double)Cost.BipolarDisorderTreatment;
                    treatment = Treatment.Checkup;
                    break;
                case Disorder.PanicAttack:
                    cost = (double)Cost.PanicAttackTreatment;
                    treatment = Treatment.Checkup;
                    break;
            }

            oaccountID = accountID;
            date = DateTime.Now;

            DB.SaveOperation(this);
            Console.WriteLine("Set Operation Successful");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error setting operation: {e.Message}");
        }
    }
    //
    public bool LoginOperation(UInt64 accountID)
    {
        using (var connection = new SqliteConnection(DataBase.ConnectionString))
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT * FROM Operations
                WHERE AccountID = @AccountID";

            cmd.Parameters.AddWithValue("@AccountID", accountID);

            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                {
                    Console.WriteLine($"No operation details exist for ID: {accountID}.");
                    return true;
                }
                disorder = (Disorder)reader.GetInt16(reader.GetOrdinal("Disorder"));
                treatment = (Treatment)reader.GetInt16(reader.GetOrdinal("Treatment"));
                status = (Status)reader.GetInt16(reader.GetOrdinal("Status"));
                cost = reader.GetDouble(reader.GetOrdinal("Cost"));
                date = reader.GetDateTime(reader.GetOrdinal("Date"));
                oaccountID = accountID;

            }
        }
        // Console.WriteLine("Operation loading Successful");
        return true;
    }
    // 
    public void ShowDetails(Operation operation)
    {
        DB.DisplayOperation(operation);
        // Console.WriteLine("Show Operation Details Successful");
    }

    public void Treat(Operation operation)
    {
        Treatment treatmentType = DB.GetTreatment(operation);
        switch (treatmentType)
        {
            case Treatment.Medication:
                Medication(operation);
                break;

            case Treatment.Surgery:
                Surgery(operation);
                break;

            case Treatment.Checkup:
                Checkup(operation);
                break;
        }
    }

    #endregion

    #region Private Methods

    private void Medication(Operation operation)
    {
        Console.WriteLine("WARNING: This simulation contains potentially triggering content related to mental health conditions.");
        Console.WriteLine("Would you like to proceed with the full simulation? (Y/N)");
        Console.Write("If you select No, a more gentle version will be shown: ");
        bool fullSimulation = Validation.GetValidBool("Would you like to proceed with the full simulation? (Y/N)");
        Console.Clear();

        string[] words = fullSimulation ?
        new string[]
        { 
            "HELP ME", "PLEASE", "I CAN'T CONTROL MY THOUGHTS", "I'M SCARED", "I NEED HELP", "I'M DYING", "I'M GOING CRAZY",
            "I'M GOING TO KILL MYSELF", "I'M GOING TO KILL YOU", "I'M GOING TO KILL THEM", "I'M GOING TO KILL THEM ALL",  
            "THEY DESERVE IT", "IT'S ALL THEIR FAULT", "IT'S THEIR FAULT", "I HATE THEM", "I HATE YOU", "I HATE EVERYONE"
        } :
        new string[]
        {
            "HELP ME", "PLEASE", "I CAN'T CONTROL MY THOUGHTS", "I'M SCARED", "I NEED HELP", "I'M DYING", "I'M GOING CRAZY"
        };

        string[] thoughts = fullSimulation ?
        new string[]
        {
            "It feels different this time",
            "It's hard to breathe",
            "It's hard to think",
            "I can't stop shaking",
            "I can't stop crying",
            "I'm so tired of this",
            "I want to end it all",
            "Nothing feels real",
            "I'm so alone",
            "I just want to sleep"
        } :
        new string[]
        {
            "It feels different this time",
            "It's hard to breathe",
            "It's hard to think",
            "I can't stop shaking",
        };

        Random rand = new Random();
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;
        ConsoleColor[] colors =
        {
            ConsoleColor.DarkRed,
            ConsoleColor.DarkGray,
            ConsoleColor.Gray,
            ConsoleColor.White
        };
        ConsoleColor standard = ConsoleColor.Gray;

        bool running = true;
        if (fullSimulation)
        {
            Thread background = new Thread(() =>
            {
                while (running)
                {
                    int x = rand.Next(width - 24); // Account for certain message length
                    int y = rand.Next(height - 1); // Account for new line characters moving the console height
                    string word = words[rand.Next(words.Length)];
                    ConsoleColor color = colors[rand.Next(colors.Length)];

                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = color;
                    Console.Write(word);
                    Thread.Sleep(100);
                }
            });
            background.IsBackground = true;
            background.Start();
            goto input;
        }

        input:
        string message = "Press T to take medication:";
        Console.SetCursorPosition((width - message.Length) / 2 , height / 2);
        Console.Write($"{message}");
        if (Console.ReadKey().Key == ConsoleKey.T)
        {
            running = false;
            Thread.Sleep(150);
            Console.ForegroundColor = standard;

            Console.Clear();
            Console.WriteLine("Taking medication...");
            Console.WriteLine("Remember: Recovery is possible with proper treatment.");

            Thread.Sleep(1500);

            if (DB.SetCompleted(operation))
            {
                operation.TimeToTreat = false;
                Console.WriteLine("Medication taken\n");
            }
        }
        else
        {
            Console.WriteLine("Refused medication");
        }
    }

    private void Surgery(Operation operation)
    {
        // Possibly kill the user and remove him from the DB


        if (DB.SetCompleted(operation))
        {
            operation.TimeToTreat = false;
        }

    }

    private void Checkup(Operation operation)
    {
        // Just talk and return or send to Medicate and update DB based on response


        if (DB.SetCompleted(operation))
        {
            operation.TimeToTreat = false;
        }
    }

    #endregion
}