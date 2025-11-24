namespace Library.support;

public class Utility
{
    public static void DisplayMenu(string menuType)
    {

        int standardWidth = 47;
        switch (menuType)
        {

            case "Main Menu":

                DisplayTitle("Main Menu", "all", standardWidth);

                DisplayTitle("", "top", standardWidth);
                WriteLine(string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}",
                    PrintCenteredTitle("Type\t(1) - to Add a new book ", standardWidth),
                    PrintCenteredTitle("\t(2) - to Find a book", standardWidth),
                    PrintCenteredTitle("\t(3) - to Borrow    ", standardWidth),
                    PrintCenteredTitle("\t(4) - to Return    ", standardWidth),
                    PrintCenteredTitle("", standardWidth),
                    PrintCenteredTitle("\t(0) - to Exit      ", standardWidth)
                ));
                WriteLine(PrintCenteredTitle("", standardWidth));
                DisplayTitle("", "bottom", standardWidth);
                break;

            case "Book Type":
                DisplayTitle("", "top", standardWidth);
                WriteLine(PrintCenteredTitle("Book Type", standardWidth));
                WriteLine(PrintCenteredTitle("", standardWidth));
                WriteLine(string.Format("{0}\n{1}\n{2}\n{3}\n{4}",
                    PrintCenteredTitle("Choose from the following Book Type", standardWidth),
                    PrintCenteredTitle("", standardWidth),
                    PrintCenteredTitle("Type\t(1) - for E-Book        ", standardWidth),
                    PrintCenteredTitle("\t(2) - for Hard Cover", standardWidth),
                    PrintCenteredTitle("\t(3) - for Audio Book", standardWidth)
                ));

                WriteLine(PrintCenteredTitle("", standardWidth));
                DisplayTitle("", "bottom", standardWidth);
                break;

            case "Add More":
                DisplayTitle("", "top", standardWidth);
                WriteLine(PrintCenteredTitle("Add a book", standardWidth));
                WriteLine(string.Format("{0}\n{1}\n{2}\n{3}",
                    PrintCenteredTitle("Choose from the following Options", standardWidth),
                    PrintCenteredTitle("", standardWidth),
                    PrintCenteredTitle("Type\t(1) - to Add More       ", standardWidth),
                    PrintCenteredTitle("\t(0) - to Exit       ", standardWidth)
                ));
                WriteLine(PrintCenteredTitle("", standardWidth));
                DisplayTitle("", "bottom", standardWidth);
                break;

            case "Borrow":
                DisplayTitle("", "top", standardWidth);
                WriteLine(PrintCenteredTitle("Choose from the following Options", standardWidth));
                WriteLine(string.Format("{0}\n{1}\n{2}",
                    PrintCenteredTitle("", standardWidth),
                    PrintCenteredTitle("Type\t(1) - Mark as borrowed  ", standardWidth),
                    PrintCenteredTitle("\t(0) - to Exit       ", standardWidth)
                ));
                WriteLine(PrintCenteredTitle("", standardWidth));
                DisplayTitle("", "bottom", standardWidth);
                break;

            case "Return":
                DisplayTitle("", "top", standardWidth);
                WriteLine(PrintCenteredTitle("Choose from the following Options", standardWidth));
                WriteLine(string.Format("{0}\n{1}\n{2}",
                    PrintCenteredTitle("", standardWidth),
                    PrintCenteredTitle("Type\t(1) - Mark as returned  ", standardWidth),
                    PrintCenteredTitle("\t(0) - to Exit       ", standardWidth)
                ));
                WriteLine(PrintCenteredTitle("", standardWidth));
                DisplayTitle("", "bottom", standardWidth);
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
                Write("\n  Enter your choice\t\t: ");
                break;

            case "title":
                Write("\n  Enter the title of the book\t: ");
                break;

            default:
                break;
        }

        string? choice = ReadLine().Trim() ?? "";
        return choice;
    }


    public static void DisplayErrorOperation(string errorType, string otherVariable)
    {
        switch (errorType)
        {
            case "no result":
                WriteLine(
                    $"  {AnsiColorCodes.Error}  The book \"{otherVariable}\" does not exist in the library.  " +
                    $"{AnsiColorCodes.Reset}");
                break;

            case "title not available":
                WriteLine(
                    $"  {AnsiColorCodes.Error}  This title is currently unavailable.  " +
                    $"{AnsiColorCodes.Reset}");
                break;

            default:
                WriteLine(
                    $"  {AnsiColorCodes.Error}  This operation is not supported, please try again.  " +
                    $"{AnsiColorCodes.Reset}");
                break;
        }
    }

    /// <summary> Displays formatted title with decorative borders</summary>
    /// <param name="title">The title text to display</param>
    /// <param name="cover">Border type: "all", "top", or default for bottom</param>
    public static void DisplayTitle(string title, string cover, int charWdith)
    {
        string lineBoxTop = new('─', charWdith);
        const string cornerLeftTop = " ┌";
        const string cornerRightTop = "┐ ";
        const string cornerLeftBottom = " └";
        const string cornerRightBottom = "┘ ";

        string top = cornerLeftTop + lineBoxTop + cornerRightTop;
        string bottom = cornerLeftBottom + lineBoxTop + cornerRightBottom;


        switch (cover)
        {
            case "all":
                WriteLine();
                string middle = PrintCenteredTitle(title, charWdith);
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


    public static string PrintLeftAlignedBordered(string title, int width)
    {
        int availableWidth = width;
        string borderedAlignedLeft = string.Format(" │  {0,-" + availableWidth + "}│ ", title);
        return borderedAlignedLeft;
    }


    /// <summary>Applies ANSI color highlighting to text for console display</summary>
    /// <param name="text">Text to apply highlighting to</param>
    public static void ApplyHighlighter(string text)
    {
        text = AnsiColorCodes.Background + AnsiColorCodes.Foreground + text + AnsiColorCodes.Reset;
        WriteLine(text);
    }

    //public static bool IsDouble(string input)
    //{
    //    double result;
    //    return double.TryParse(input, out result);
    //}


    public static void HardCoverChangeLocation(IBook instance, string location)
    {
        instance.Location = instance.GetType().Name.Equals("HardCover")
            ? location
            : instance.Location;
    }

    public static void successMessage(IBook instance, string action)
    {

        string actionFromatted =
            action.Equals("borrowed")
                ? $"{AnsiColorCodes.BookBorrowed} {action} {AnsiColorCodes.Reset}"
                : $"{AnsiColorCodes.BookAvailable} {action} {AnsiColorCodes.Reset}";



        WriteLine($"\nTitle: {instance.Title}" +
                  $"\nItem successfully marked as {actionFromatted}");

    }
}