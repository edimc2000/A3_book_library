namespace Library.support;

using static Formatting;

/// <summary>Provides utility methods for library operations</summary>
/// <remarks>
/// <para>Author: Eddie C.</para>
/// <para>Version: 1.1</para>
/// <para>Since: 2025-11-22</para>
/// </remarks>
public class Utility
{

    /// <summary>// width for menu box</summary>
    public const int StandardWidth = 47;
    
    /// <summary>Contains menu type constants</summary>
    public static class MenuTypes
    {
        public const string MainMenu = "Main Menu";
        public const string BookType = "Book Type";
        public const string AddMore = "Add More";
        public const string Borrow = "Borrow";
        public const string Return = "Return";
    }

    /// <summary>Contains input type constants</summary>
    public static class InputTypes
    {
        public const string Choice = "choice";
        public const string Title = "title";
    }

    /// <summary>Contains error type constants</summary>
    public static class ErrorTypes
    {
        public const string NoResult = "no result";
        public const string TitleUnavailable = "title not available";
        public const string MultipleResult = "multiple result";
    }

    /// <summary>Contains book action constants</summary>
    public static class BookActions
    {
        public const string Borrowed = "borrowed";
        public const string Returned = "returned";
        public const string Find = "search";

    }


    /// <summary>Displays formatted menu based on menu type</summary>
    /// <param name="menuType">Type of menu to display</param>
    public static void DisplayMenu(string menuType)
    {
        switch (menuType)
        {
            case MenuTypes.MainMenu:

                DisplayTitle("Main Menu", "all", StandardWidth);

                DisplayTitle("", "top", StandardWidth);

                WriteLine(PrintCenteredTitle("Type\t(1) - to Add a new book ", StandardWidth));
                WriteLine(PrintCenteredTitle("\t(2) - to Find a book", StandardWidth));
                WriteLine(PrintCenteredTitle("\t(3) - to Borrow    ", StandardWidth));
                WriteLine(PrintCenteredTitle("\t(4) - to Return    ", StandardWidth));
                WriteLine(PrintCenteredTitle("", StandardWidth));
                WriteLine(PrintCenteredTitle("\t(0) - to Exit      ", StandardWidth));

                DisplayTitle("", "bottom", StandardWidth);
                break;

            case MenuTypes.BookType:
                DisplayTitle("", "top", StandardWidth);

                WriteLine(PrintCenteredTitle("Book Type", StandardWidth));
                WriteLine(PrintCenteredTitle("", StandardWidth));
                WriteLine(PrintCenteredTitle("Choose from the following Book Type", StandardWidth));
                WriteLine(PrintCenteredTitle("", StandardWidth));
                WriteLine(PrintCenteredTitle("Type\t(1) - for E-Book        ", StandardWidth));
                WriteLine(PrintCenteredTitle("\t(2) - for Hard Cover", StandardWidth));
                WriteLine(PrintCenteredTitle("\t(3) - for Audio Book", StandardWidth));

                DisplayTitle("", "bottom", StandardWidth);
                break;

            // this is a demo that the program can be made to prompt user to add more books
            // instead of returning to main menu directly
            case MenuTypes.AddMore:
                DisplayTitle("", "top", StandardWidth);

                WriteLine(PrintCenteredTitle("Add a book", StandardWidth));
                WriteLine(PrintCenteredTitle("Choose from the following Options", StandardWidth));
                WriteLine(PrintCenteredTitle("", StandardWidth));
                WriteLine(PrintCenteredTitle("Type\t(1) - to Add More       ", StandardWidth));
                WriteLine(PrintCenteredTitle("\t(0) - to Exit       ", StandardWidth));

                DisplayTitle("", "bottom", StandardWidth);
                break;

            case MenuTypes.Borrow:
                DisplayTitle("", "top", StandardWidth);

                WriteLine(PrintCenteredTitle("Choose from the following Options", StandardWidth));
                WriteLine(PrintCenteredTitle("", StandardWidth));
                WriteLine(PrintCenteredTitle("Type\t(1) - Mark as borrowed  ", StandardWidth));
                WriteLine(PrintCenteredTitle("\t(0) - to Exit       ", StandardWidth));

                DisplayTitle("", "bottom", StandardWidth);
                break;

            case MenuTypes.Return:
                DisplayTitle("", "top", StandardWidth);
                WriteLine(PrintCenteredTitle("Choose from the following Options", StandardWidth));

                WriteLine(PrintCenteredTitle("", StandardWidth));
                WriteLine(PrintCenteredTitle("Type\t(1) - Mark as returned  ", StandardWidth));
                WriteLine(PrintCenteredTitle("\t(0) - to Exit       ", StandardWidth));

                DisplayTitle("", "bottom", StandardWidth);
                break;

            default:
                break;
        }
    }

    /// <summary>Gets user input with appropriate prompt</summary>
    /// <param name="inputType">Type of input requested</param>
    /// <returns>Trimmed user input string</returns>
    public static string GetInput(string inputType)
    {
        switch (inputType)
        {
            case InputTypes.Choice:
                Write("\n  Enter your choice\t\t: ");
                break;

            case InputTypes.Title:
                Write("\n  Enter the title of the book\t: ");
                break;

            default:
                break;
        }

        return ReadLine()?.Trim() ?? "";
    }

    /// <summary>Displays error messages with colored formatting</summary>
    /// <param name="errorType">Type of error to display</param>
    /// <param name="context">Context information for the error</param>
    public static void DisplayErrorOperation(string? errorType = null, string? context=null)
    {
        switch (errorType)
        {
            case ErrorTypes.NoResult:
                WriteLine(
                    $"  {AnsiColorCodes.Error}  The book \"{context}\" does not exist in the library.  " +
                    $"{AnsiColorCodes.Reset}");
                break;

            case ErrorTypes.TitleUnavailable:
                WriteLine(
                    $"  {AnsiColorCodes.Error}  This title is currently unavailable.  " +
                    $"{AnsiColorCodes.Reset}");
                break;

            case ErrorTypes.MultipleResult:
                WriteLine(
                    $"  {AnsiColorCodes.Error}  Multiple matches found. Please refine your search.  " +
                    $"{AnsiColorCodes.Reset}");
                break;

            default:
                WriteLine(
                    $"  {AnsiColorCodes.Error}  This operation is not supported, please try again.  " +
                    $"{AnsiColorCodes.Reset}");
                break;
        }
    }


    /// <summary>Displays success message for book operations</summary>
    /// <param name="instance">The book instance operated on</param>
    /// <param name="action">Action performed (borrowed/returned)</param>
    public static void SuccessMessage(IBook instance, string action)
    {
        string actionFormatted =
            action.Equals(BookActions.Borrowed)
                ? $"{AnsiColorCodes.BookBorrowed} {BookActions.Borrowed} {AnsiColorCodes.Reset}"
                : $"{AnsiColorCodes.BookAvailable} {BookActions.Returned} {AnsiColorCodes.Reset}";


        WriteLine($"\nTitle: {instance.Title}" +
                  $"\nItem successfully marked as {actionFormatted}");
    }
}