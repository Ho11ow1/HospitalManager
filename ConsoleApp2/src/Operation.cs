using System;

class Operation
{
#region Properties
    public Disorder disorder { get; private set; }
    public Treatment treatment { get; private set; }
    public Status status { get; private set; }
    public double cost { get; private set; }
    public DateTime date { get; private set; }
    public UInt64 ID { get; private set; }

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

        date = DateTime.Now;
        ID = accountID;

        DB.SaveOperation(this); // Has an issue with passing Enums
        Console.Clear();
        Console.WriteLine("Set Operation Successful");
    }
    // 
    public void ShowDetails(Operation operation)
    {
        Console.WriteLine($"Operation Name: {operation.disorder}");
        Console.WriteLine($"Operation Type: {operation.treatment}");
        Console.WriteLine($"Operation Status: {operation.status}");
        Console.WriteLine($"Operation Cost: {operation.cost}");
        Console.WriteLine($"Operation Date: {operation.date}");
        // Console.WriteLine("Show Operation Details Successful"); // DEBUG LOG
    }
    //

#endregion

#region Private Methods
    
#endregion
}