namespace Library;

public class Utility
{
    public static void DisplayMenu(string menuType)
    {
        switch (menuType)
        {
            case "Main Menu":
                WriteLine();
                DisplayTitle("Main  Menu", "all");

                DisplayTitle("", "top");
                WriteLine(string.Format("{0}\n{1}\n{2}\n{3}\n{4}",

                    PrintCenteredTitle("Type\t(1) - to Add a new book  ", 44),
                    PrintCenteredTitle("\t(2) - to Find a book", 45),
                    PrintCenteredTitle("\t(3) - to Borrow     ", 45),
                    PrintCenteredTitle("\t(4) - to Return     ", 45),
                    PrintCenteredTitle("\t(0) - to Exit       ", 45)
     
                ));
                DisplayTitle("", "bottom");
                break;

            case "Book Type":

               
                WriteLine(string.Format("{0}\n{1}\n\n{2}\n{3}\n{4}\n",
                    "Book Type",
                    "Choose from the following Book Type ",
                    "Type\t(1) - for E-Book",
                    "\t(2) - for Hard Cover",
                    "\t(3) - for Audio Book"
                ));

                break;

            case "Add More":
                WriteLine(string.Format("{0}\n{1}\n\n{2}\n{3}\n",
                    "Add a book",
                    "Choose from the following Options ",
                    "Type\t(1) - to Add More",
                    "\t(0) - to Exit"
                ));

                break;


            default:
                break;
        }
    }


    public static string GetInput(string inputType)
    {
        switch (inputType)
        {
            case "choice":
                Write("Enter your choice\t: ");
                break;

            case "title":
                Write("Enter the title of the book\t: ");
                break;

            default:
                break;
        }

        string? choice = ReadLine().Trim() ?? "";
        return choice;
    }


    public static void DisplayErrorOperation()
    {
        WriteLine("This operation is not supported, please try again.");
    }

    /// <summary> Displays formatted title with decorative borders</summary>
    /// <param name="title">The title text to display</param>
    /// <param name="cover">Border type: "all", "top", or default for bottom</param>
    public static void DisplayTitle(string title, string cover)
    {
        string lineBoxTop = new('─', 46);
        const string cornerLeftTop = " ┌";
        const string cornerRightTop = "┐ ";
        const string cornerLeftBottom = " └";
        const string cornerRightBottom = "┘ ";

        string top = cornerLeftTop + lineBoxTop + cornerRightTop;
        string bottom = cornerLeftBottom + lineBoxTop + cornerRightBottom;


        switch (cover)
        {
            case "all":
                string middle = PrintCenteredTitle(title, 46);
                ApplyHighlighter(top);
                ApplyHighlighter(middle);
                ApplyHighlighter(bottom);
                break;

            case "top":
                WriteLine(top);
                break;

            default:
                WriteLine(bottom);
                break;
        }
    }

    /// <summary>Centers text within a specified width for display formatting</summary>
    /// <param name="title">Text to center</param>
    /// <param name="width">Total width for centering</param>
    /// <returns>Formatted centered string with border characters</returns>
    public static string PrintCenteredTitle(string title, int width)
    {
        int availableWidth = width;

        string centeredTitle = string.Format(" │{0,-" + availableWidth + "}│ ",
            title.PadLeft((availableWidth + title.Length) / 2).PadRight(availableWidth));
        return centeredTitle;
    }


    /// <summary>Applies ANSI color highlighting to text for console display</summary>
    /// <param name="text">Text to apply highlighting to</param>
    public static void ApplyHighlighter(string text)
    {
        text = AnsiColorCodes.Background + AnsiColorCodes.Foreground + text + AnsiColorCodes.Reset;
        WriteLine(text);
    }

    public static bool IsDouble(string input)
    {
        double result;
        return double.TryParse(input, out result);
    }
}