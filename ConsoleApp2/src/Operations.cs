using System;

class Operations
{
    #region Properties
    internal string Operation_Name { get; private set; } = "";
    internal OperationType Operation_Type { get; private set; } = OperationType.Medicine; // TODO: Set to NULL by default
    internal OperationStatus Status { get; private set; } = OperationStatus.Pending; // Set to pending by default
    internal DateTime Operation_Date { get; private set; } = DateTime.Now; // TODO: Change to DayOfWeek
    #endregion

    #region Public Methods
    public void Fn_Operation(string newOperation)
    {
        try
        {
            Operation_Name = newOperation;
            Console.WriteLine($"Operation set to: {Operation_Name}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void Fn_SetOperation() // Set Operation based on request with switch
    {
        Fn_Operation(Fn_GetValidInput("Enter Operation", Constants.MIN_LENGTH, Constants.MAX_LENGTH));
    }

    public void Fn_ShowOperationDetails() // Temporary until DB is implemented
    {
        Console.WriteLine($"Operation Name: {Operation_Name}");
        Console.WriteLine($"Operation Type: {Operation_Type}");
        Console.WriteLine($"Operation Status: {Status}");
        Console.WriteLine($"Operation Date: {Operation_Date}");
    }

    public void Fn_UpdateOperationStatus(OperationStatus newStatus)
    {
        Status = newStatus;
        Console.WriteLine($"Operation status updated to: {Status}");

        // TODO: Implement day-of-week specific operation status updates
        switch (DateTime.Now.DayOfWeek)
        {
            // TODO: Implement day-specific operations
            // TODO: Implement time-specific operations for:
            //   Morning   (06:00 - 12:00) -> InProgress
            //   Afternoon (12:00 - 18:00) -> Completed
            //   Evening   (18:00 - 24:00) -> Pending
            // Example: Status = Operation_Type == OperationType.Surgery ? OperationStatus.InProgress : Status;
            
            default:
                Console.WriteLine("Day-specific operations not yet implemented");
                break;
        }
    }
    #endregion

    #region Private Methods
    private string Fn_GetValidInput(string prompt, UInt16 minLength, UInt16 maxLength)
    {
        return "";
    }
    #endregion
}