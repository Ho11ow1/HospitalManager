using Microsoft.Data.Sqlite;

class Operation
{
#region Properties
    public Disorder disorder { get; private set; }
    public Treatment treatment { get; private set; }
    public Status status { get; private set; }
    public double cost { get; private set; }
    public DateTime date { get; private set; }
    public UInt64 oaccountID { get; private set; }

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
                    Console.WriteLine($"Login failed: Couldn't find operation details for ID: {accountID}.");
                    return false;
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

#endregion

#region Private Methods
    
#endregion
}