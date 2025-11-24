using static Library.support.Utility;
namespace Library.support;

internal class LibraryManager
{
    public static void AddNewBook(List<IBook> catalogue)
        //public static string AddNewBook()
    {
        DisplayTitle("Add a book", "all", 46);
        bool isLooping = true;
        while (isLooping)
        {
            string? title = GetInput("title");
            DisplayAndAddBook(title);
            WriteLine("\n  Entry added.\n\n");
            isLooping = AddMoreOrExit();
        }
    }

    private static void DisplayAndAddBook(string title)
    {
        DisplayMenu("Book Type");
        bool isDisplayingMenu = true;
        while (isDisplayingMenu)
        {
            string? choice = GetInput("choice");

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
        DisplayMenu("Add More");
        bool isDisplayingMenu = true;
        while (isDisplayingMenu)
        {
            string? choice = GetInput("choice");
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

        string? userInput = GetInput("title").ToLower();

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
            case "borrow":
                results = Collection.Catalogue
                    .Where(b => b.Title.ToLower().Contains(userInput) && b.IsAvailable)
                    .ToList();
                break;

            case "return":
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
        DisplayTitle("Borrow a book", "all", 46);

        List<IBook> bookCount = Search(true, "borrow");
        if (bookCount.Count > 1)
            WriteLine("\nMultiple matches found. Please refine your search.");

        else if (bookCount.Count == 0)
            DisplayErrorOperation("title not available", "");

        else if (bookCount.Count == 1)
        {
            DisplayMenu("Borrow");

            string choice = GetInput("choice");
            switch (choice)
            {
                case "1":
                    bookCount[0].MarkAsBorrowed();

                    HardCoverChangeLocation(bookCount[0], "Client");

                    successMessage(bookCount[0], "borrowed");
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


    public static void Return()
    {
        DisplayTitle("Return a book", "all", 46);

        List<IBook> bookCount = Search(true, "return");
        if (bookCount.Count > 1)
        {
            WriteLine("\nMultiple matches found. Please refine your search.");
        }

        else if (bookCount.Count == 0)
        {
            DisplayErrorOperation("title not available", "");
        }
        else if (bookCount.Count == 1)
        {
            DisplayMenu("Return");

            string choice = GetInput("choice");
            switch (choice)
            {
                case "1":
                    bookCount[0].MarkAsReturned();

                    HardCoverChangeLocation(bookCount[0], "Library");

                    successMessage(bookCount[0], "returned");

                    break;
                case "0":
                    break;
                default:
                    DisplayErrorOperation("", "");
                    break;
            }
        }
    }
}