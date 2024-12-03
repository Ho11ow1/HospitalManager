using System;

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
        Console.WriteLine($"1. {Disorder.Anxiety}");
        Console.WriteLine($"2. {Disorder.Schizophrenia}");
        Console.WriteLine($"3. {Disorder.Depression}");
        Console.WriteLine($"4. {Disorder.Bipolar}");
        Console.WriteLine($"5. {Disorder.PanicAttack}\n");

        choice = Validation.GetValidNum("Which mental disorder do you have");
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