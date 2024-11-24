using System;

class Operation
{
#region Properties
    public OperationName operationName { get; private set; }
    public OperationType operationType { get; private set; }
    public OperationStatus operationStatus { get; private set; }
    public double operationCost { get; private set; }
    public DayOfWeek operationDate { get; private set; } = DateTime.Now.DayOfWeek;
#endregion

#region Public Methods
    public void SetOperation()
    {
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
            case OperationName.NULL:
                operationCost = (double)OperationCost.NULL;
                break;
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

    public void ShowDetails()
    {
        // TODO: Implement show details logic
        Console.WriteLine("Show Operation Details Successful");
    }
#endregion

#region Private Methods
    
#endregion
}