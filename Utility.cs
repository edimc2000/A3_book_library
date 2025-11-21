using Microsoft.VisualBasic;

namespace Library;

public class Utility
{
    public static string DisplayMenu()
    {
        WriteLine("Menu");
        WriteLine("");
        WriteLine("Choose from the following");
        WriteLine("");
        WriteLine("Type (1) - to Add a new book");
        WriteLine("Type (2) - to Find a book");
        WriteLine("Type (3) - to Borrow");
        WriteLine("Type (4) - to Return");
        WriteLine("");
        WriteLine("Type (0) - to Exit");

        Write("Enter your choice: ");

        string? choice = ReadLine().Trim() ?? "";


        WriteLine("displaying menu choice validation: " + ValidateInput(choice, "menu"));

        WriteLine("------------------------");
        return choice;
    }


    private static bool ValidateInput(string input, string inputTYpe)
    {
        switch (input)
        {
            case "menu":
                bool isConvertible = int.TryParse(input, out int result);
                return result is >= 0 and <= 4;


            default:
                break;
        }

        return false;
    }
}