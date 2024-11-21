using System;

class Operations
{
    #region Properties
    internal string Operation_Name { get; private set; } = "";
    internal OperationType Operation_Type { get; private set; } = OperationType.NULL;// = OperationType.Medicine; // TODO: Set to NULL by default
    internal OperationStatus Operation_Status { get; private set; } = OperationStatus.NULL;// = OperationStatus.Pending; // Set to pending by default
    //internal DateTime Operation_Date { get; private set; } // TODO: Change to DayOfWeek
    internal DateTime? Operation_Date { get; private set; } = null;

    //private readonly DataBase _database = new DataBase();
    #endregion

    #region Public Methods
    public void Fn_Operation()
    {
        try
        {
            Operation_Name = Fn_SetOperation();
            Console.WriteLine($"Operation set to: {Operation_Name}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public string Fn_SetOperation() // Set Operation based on request with switch
    {
        return Validation.GetValidInput("Enter Operation:");
    }

    public void Fn_ShowOperationDetails() // Temporary until DB is implemented
    {
        Console.WriteLine($"Operation Name: {Operation_Name}");
        Console.WriteLine($"Operation Type: {Operation_Type}");
        Console.WriteLine($"Operation Status: {Operation_Status}");
        Console.WriteLine($"Operation Date: {Operation_Date}");
    }

    public void Fn_UpdateOperationStatus(OperationStatus newStatus)
    {
        Operation_Status = newStatus;
        Console.WriteLine($"Operation status updated to: {Operation_Status}");

        // TODO: Implement day-of-week specific operation status updates
        switch (DateTime.Now.DayOfWeek)
        {
            // TODO: Implement day-specific operations
            // TODO: Implement time-specific operations for:
            //   Morning   (06:00 - 12:00) -> InProgress
            //   Afternoon (12:00 - 18:00) -> Completed
            //   Evening   (18:00 - 24:00) -> Pending
            // Example: Operation_Status = Operation_Type == OperationType.Surgery ? OperationStatus.InProgress : Operation_Status;
            
            default:
                Console.WriteLine("Day-specific operations not yet implemented");
                break;
        }
    }
    #endregion

    #region Private Methods
    
    #endregion
}