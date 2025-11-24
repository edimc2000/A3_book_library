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
        public const string AddTitle = "Add a Book";
        public const string BorrowTitle = "Borrow a Book";
        public const string ReturnTitle = "Return a Book ";
        public const string SearchTitle = "Find a Book ";

        
        public const string ConfirmProcess = "1";
        public const string ExitProcess = "0";
        
        public const string TypeEbook = "1"; 
        public const string TypeHardCover = "2";
        public const string TypeAudioBook = "3";
    }


    public static void AddNewBook(List<IBook> catalogue)

    {
        DisplayTitle(BookProcesses.AddTitle, "all", StandardWidth);
        bool addMore = true;
        while (addMore)
        {
            string? title = GetInput(InputTypes.Title);
            DisplayAndAddBook(title);
            WriteLine("\n  Entry added.\n\n");

            // this is a demo that the program can be made to prompt user to add more books
            // instead of returning to main menu directly
            addMore = AddMoreOrExit();
        }
    }

    private static void DisplayAndAddBook(string title)
    {
        DisplayMenu(MenuTypes.BookType);
        bool isDisplayingMenu = true;
        while (isDisplayingMenu)
        {
            string? choice = GetInput(InputTypes.Choice);

            switch (choice)
            {
                case BookProcesses.TypeEbook:
                    Ebook eBook = new(title);
                    Collection.Catalogue.Add(eBook);
                    isDisplayingMenu = false;
                    break;

                case BookProcesses.TypeHardCover:
                    HardCover book = new(title);
                    Collection.Catalogue.Add(book);
                    isDisplayingMenu = false;
                    break;

                case BookProcesses.TypeAudioBook:
                    AudioBook audioBook = new(title);
                    Collection.Catalogue.Add(audioBook);
                    isDisplayingMenu = false;
                    break;

                default:
                    DisplayErrorOperation();
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
                case BookProcesses.ConfirmProcess:
                    return true;

                case BookProcesses.ExitProcess:
                    isDisplayingMenu = false;
                    break;

                default:
                    DisplayErrorOperation();
                    break;
            }
        }

        return isDisplayingMenu;
    }


    public static List<IBook> Search(bool isSubRoutine, string action)
    {
        if (!isSubRoutine) DisplayTitle(BookProcesses.SearchTitle, "all", StandardWidth);

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

        if (results.Count == 0 && action.Equals(BookActions.Find))
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

            IBook targetBook = book[0];


            string choice = GetInput(InputTypes.Choice);
            switch (choice)
            {
                case BookProcesses.ConfirmProcess:
                    if (BookActions.Borrowed.ToLower().Contains(firstWordTitle))
                    {
                        ////   how to not have a magic number 
                        targetBook.MarkAsBorrowed();

                        // only affects hardcover books
                        ChangeLocation(targetBook, BookLocations.Borrowed);
                        SuccessMessage(targetBook, BookActions.Borrowed);
                    }
                    else
                    {
                        targetBook.MarkAsReturned();

                        // only affects hardcover books
                        ChangeLocation(targetBook, BookLocations.Returned);

                        SuccessMessage(targetBook, BookActions.Returned);
                    }

                    break;


                case BookProcesses.ExitProcess:
                    break;

                default:
                    DisplayErrorOperation("", "");
                    ;
                    break;
            }
        }
    }
}