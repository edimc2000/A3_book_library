using System.ComponentModel.Design;
using static Library.support.Formatting;
using static Library.support.LibraryManager;
using static Library.support.Utility;

namespace Library.support;

internal class LibraryManager
{
    /// <summary>Contains book locations</summary>
    public static class BookLocations
    {
        public const string Borrowed = "Client";
        public const string Returned = "Library";
    }

    public static class BookProcesses
    {
        public const string BorrowTitle = "Borrow a Book";
        public static string ReturnTitle = "Return a Book ";
    }


    public static void AddNewBook(List<IBook> catalogue)

    {
        DisplayTitle("Add a book", "all", 46);
        bool isLooping = true;
        while (isLooping)
        {
            string? title = GetInput(InputTypes.Title);
            DisplayAndAddBook(title);
            WriteLine("\n  Entry added.\n\n");

            // this is a demo that the program can be made to prompt user to add more books
            // instead of returning to main menu directly
            isLooping = AddMoreOrExit();
        }
    }

    private static void DisplayAndAddBook(string title)
    {
        DisplayMenu("Book Type");
        bool isDisplayingMenu = true;
        while (isDisplayingMenu)
        {
            string? choice = GetInput(InputTypes.Choice);

            switch (choice)
            {
                case "1":
                    Ebook eBook = new(title);
                    Collection.Catalogue.Add(eBook);
                    isDisplayingMenu = false;
                    break;

                case "2":
                    HardCover book = new(title);
                    Collection.Catalogue.Add(book);
                    isDisplayingMenu = false;
                    break;

                case "3":
                    AudioBook audioBook = new(title);
                    Collection.Catalogue.Add(audioBook);
                    isDisplayingMenu = false;
                    break;

                default:
                    DisplayErrorOperation("", "");
                    break;
            }
        }
    }

    private static bool AddMoreOrExit()
    {
        // this is a demo that the program can be made to prompt user to add more books
        // instead of returning to main menu directly
        DisplayMenu("Add More");
        bool isDisplayingMenu = true;
        while (isDisplayingMenu)
        {
            string? choice = GetInput(InputTypes.Choice);
            switch (choice)
            {
                case "1":
                    return true;

                case "0":
                    isDisplayingMenu = false;
                    break;

                default:
                    DisplayErrorOperation("", "");
                    break;
            }
        }

        return isDisplayingMenu;
    }


    public static List<IBook> Search(bool isSubRoutine, string action)
    {
        if (!isSubRoutine) DisplayTitle("Find a book", "all", 46);

        string? userInput = GetInput(InputTypes.Title).ToLower();

        int boxWidth = 0;
        List<IBook> results;

        // get the max width for the search result items box
        foreach (IBook book in Collection.Catalogue)
        {
            string availableOrBorrowed = book.IsAvailable ? "available" : "borrowed";
            string message = $"The book \"{book.Title}\" is {availableOrBorrowed}";
            if (message.Length > boxWidth)
                boxWidth = message.Length + 2;
        }

        switch (action)
        {
            case MenuTypes.Borrow:
                results = Collection.Catalogue
                    .Where(b => b.Title.ToLower().Contains(userInput) && b.IsAvailable)
                    .ToList();
                break;

            case MenuTypes.Return:
                results = Collection.Catalogue
                    .Where(b => b.Title.ToLower().Contains(userInput) && !b.IsAvailable)
                    .ToList();
                break;


            default:
                results = Collection.Catalogue
                    .Where(b => b.Title.ToLower().Contains(userInput))
                    .ToList();
                break;
        }


        DisplayTitle("", "top", boxWidth + 2);
        WriteLine(PrintCenteredTitle("Search Results", boxWidth + 2));
        DisplayTitle("", "bottom", boxWidth + 2);

        foreach (IBook book in results)
        {
            string bookTitle = $"Title {":".PadLeft(5)} {book.Title}";
            string bookType = $"Book Type : {book.GetType().Name}";
            string bookStatus = $"Available : {book.IsAvailable}";
            string bookLocation = $"Location  : {book.GetLocation()}";
            string availableOrBorrowed = book.IsAvailable ? "available" : "borrowed";
            string message = $"The book \"{book.Title}\" is {availableOrBorrowed}";

            DisplayTitle("", "top", boxWidth + 2);

            WriteLine(PrintLeftAlignedBordered(bookTitle, boxWidth));
            WriteLine(PrintLeftAlignedBordered(bookType, boxWidth));
            WriteLine(PrintLeftAlignedBordered(bookStatus, boxWidth));
            WriteLine(PrintLeftAlignedBordered(bookLocation, boxWidth));
            WriteLine(PrintLeftAlignedBordered("", boxWidth));
            WriteLine(PrintLeftAlignedBordered(message, boxWidth));

            DisplayTitle("", "bottom", boxWidth + 2);
        }

        if (results.Count == 0 && action.Equals("search"))
            DisplayErrorOperation("no result", userInput);

        return results;
    }

    public static void Borrow()
    {
        ProcessBookOperation(BookProcesses.BorrowTitle, MenuTypes.Borrow);
    }


    public static void Return()
    {
        ProcessBookOperation(BookProcesses.ReturnTitle, MenuTypes.Return);
        
    }


    public static void ProcessBookOperation (string operationTitle, string menuItem)
    {
        string firstWordTitle = operationTitle.Split(" ")[0].ToLower();
        DisplayTitle(operationTitle, "all", StandardWidth);
        List<IBook> book = Search(true, menuItem);

        if (book.Count > 1)
        {
            DisplayErrorOperation(ErrorTypes.MultipleResult, "");
        }

        else if (book.Count == 0)
        {
            DisplayErrorOperation(ErrorTypes.TitleUnavailable, "");
        }
        else if (book.Count == 1)
        {
            DisplayMenu(menuItem);

            string choice = GetInput(InputTypes.Choice);
            switch (choice)
            {
                case "1":

                    if (BookActions.Borrowed.ToLower().Contains(firstWordTitle))
                    {
                        ////   how to not have a magic number 
                        book[0].MarkAsBorrowed();

                        // only affects hardcover books
                        ChangeLocation(book[0], BookLocations.Borrowed);
                        SuccessMessage(book[0], BookActions.Borrowed);
                    }
                    else
                    {
                        book[0].MarkAsReturned();

                        // only affects hardcover books
                        ChangeLocation(book[0], BookLocations.Returned);

                        SuccessMessage(book[0], BookActions.Returned);
                    }

                    break;


                case "0":
                    break;
                default:
                    DisplayErrorOperation("", "");
                    ;
                    break;
            }
        }
    }
}