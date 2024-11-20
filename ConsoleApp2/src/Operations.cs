using System;

class Operations
{
    #region Properties
    internal string Operation { get; private set; } = "";
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
    #endregion

    #region Private Methods
    private string Fn_GetValidInput(string prompt, UInt16 minLength, UInt16 maxLength)
    {
        return "";
    }
    #endregion
}