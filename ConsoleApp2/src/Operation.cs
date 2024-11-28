using System;

class Operation
{
#region Properties
    public OperationName operationName { get; private set; }
    public OperationType operationType { get; private set; }
    public OperationStatus operationStatus { get; private set; }
    public double operationCost { get; private set; }
    public DayOfWeek operationDate { get; private set; }
#endregion

#region Public Methods
    public void SetOperation()
    {
        operationDate = DateTime.Now.DayOfWeek;
        // TODO: Implement set operation logic
        /*
            1. Get user input for OperationName, OperationType:
               - Show user operation options
               - validate user input
               - create new operation object
               - save operation to database
        */
        switch (operationName)
        {
            case OperationName.AnxietyTreatment:
                operationCost = (double)OperationCost.AnxietyTreatment;
                break;
            case OperationName.SchizophreniaTreatment:
                operationCost = (double)OperationCost.SchizophreniaTreatment;
                break;
            case OperationName.DepressionTreatment:
                operationCost = (double)OperationCost.DepressionTreatment;
                break;
            case OperationName.BipolarDisorderTreatment:
                operationCost = (double)OperationCost.BipolarDisorderTreatment;
                break;
            case OperationName.PanicAttackTreatment:
                operationCost = (double)OperationCost.PanicAttackTreatment;
                break;
            default:
                break;
        }
        Console.WriteLine("Set Operation Successful");
    }

    public void Load() // Might take in UID and be called in login for no redundancy
    {
        // Load from SQL based on UID, Ask for UID again - Redundant but extra safety measure despite needing it to login
    }

    public void ShowDetails(Operation operation)
    {
        Console.WriteLine($"Operation Name: {operation.operationName}");        // - Operation Name
        Console.WriteLine($"Operation Type: {operation.operationType}");        // - Operation Type
        Console.WriteLine($"Operation Status: {operation.operationStatus}");    // - Operation Status
        Console.WriteLine($"Operation Cost: {operation.operationCost}");        // - Operation Cost
        Console.WriteLine($"Operation Date: {operation.operationDate}");        // - Operation Date
        // Console.WriteLine("Show Operation Details Successful"); // DEBUG LOG
    }
#endregion

#region Private Methods
    
#endregion
}