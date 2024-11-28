using System;
using System.Linq;

public static class Validation
{
    public static string GetValidInput(string prompt)
    {
        string input;
        do
        {
            Console.Write($"{prompt} ({Constants.MIN_LENGTH}-{Constants.MAX_LENGTH} characters, letters only): ");
            input = Console.ReadLine()?.Trim() ?? "";
        }
        while (!ValidateInput(input, Constants.MIN_LENGTH, Constants.MAX_LENGTH));

        return input;
    }

    public static UInt64 GetValidNum(string prompt)
    {
        UInt64 temp = 0;

        do
        {
            Console.Write($"{prompt}: ");
            temp = Convert.ToUInt64(Console.ReadLine()?.Trim() ?? "");
        }
        while (!ValidateNum(temp, Constants.USER_ID_MAX_LENGTH));

        return temp;
    }

    private static bool ValidateNum(UInt64 input, UInt16 length)
    {
        return true;
    }

    private static bool ValidateInput(string input, UInt16 minLength, UInt16 maxLength)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input cannot be empty.");
            return false;
        }

        if (!IsAlpha(input))
        {
            Console.WriteLine("Input must contain only letters.");
            return false;
        }

        UInt16 length = (UInt16)input.Length;
        if (length < minLength || length > maxLength)
        {
            Console.WriteLine($"Input must be between {minLength} and {maxLength} characters long.");
            return false;
        }

        return true;
    }

    private static bool IsAlpha(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return false;
        }

        return str.All(c => char.IsLetter(c));
    }
}
