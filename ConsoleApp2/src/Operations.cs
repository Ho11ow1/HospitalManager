using System;

class Operations
{
    #region Properties
    internal string Operation { get; private set; } = "";
    internal string Operation_Type { get; private set; } = "";
    internal OperationStatus Status { get; private set; } = OperationStatus.Pending;
    #endregion

    #region Public Methods
    public void Fn_Operation(string newOperation)
    {
        try
        {
            Operation = newOperation;
            Console.WriteLine($"Operation set to: {Operation}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void Fn_SetOperation()
    {
        Fn_Operation(Fn_GetValidInput("Enter Operation", Constants.MIN_LENGTH, Constants.MAX_LENGTH));
    }

    public void Fn_ShowOperationDetails()
    {
        Console.WriteLine($"Operation: {Operation}");
        Console.WriteLine($"Operation Type: {Operation_Type}");
        Console.WriteLine($"Status: {Status}");
    }

    public void Fn_UpdateOperationStatus(OperationStatus newStatus)
    {
        Status = newStatus;
        Console.WriteLine($"Operation status updated to: {Status}");
    }
    #endregion

    #region Private Methods
    private string Fn_GetValidInput(string prompt, UInt16 minLength, UInt16 maxLength)
    {
        return "";
    }
    #endregion
}