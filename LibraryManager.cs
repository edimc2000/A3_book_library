using static Library.Utility;

namespace Library;

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
                    Collection.catalogue.Add(eBook);
                    isDisplayingMenu = false;
                    break;

                case "2":
                    HardCover book = new(title);
                    Collection.catalogue.Add(book);
                    isDisplayingMenu = false;
                    break;

                case "3":
                    AudioBook audioBook = new(title);
                    Collection.catalogue.Add(audioBook);
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
                    DisplayErrorOperation();
                    break;
            }
        }

        return isDisplayingMenu;
    }


    public static int Search()
    {
        DisplayTitle("Find a book", "all", 46);
        string? userInput = GetInput("title").ToLower
            ();


        List<IBook> results = Collection.catalogue
            .Where(b => b.Title.ToLower().Contains(userInput))
            .ToList();


        DisplayTitle("", "top", 46);
        WriteLine(PrintCenteredTitle("Search Results", 46));
        DisplayTitle("", "bottom", 46);
        
        int counter = 0;
        foreach (IBook book in results)
        {
            string bookTitle = $"Title {":".PadLeft(5)} {book.Title}";
            string bookType = $"Book Type : {book.GetType().Name}";
            string bookStatus = $"Available : {book.isAvailable}";
            string availableOrBorrowed = book.isAvailable ? "available" : "borrowed";
            string sentence = $"The book \"{book.Title}\" is {availableOrBorrowed}";
            
            DisplayTitle("", "top", sentence.Length + 4);
            WriteLine(PrintLeftAlignedBordered(bookTitle, sentence.Length + 2));
            WriteLine(PrintLeftAlignedBordered(bookType, sentence.Length + 2));
            WriteLine(PrintLeftAlignedBordered(bookStatus, sentence.Length + 2));
            WriteLine(PrintLeftAlignedBordered("", sentence.Length + 2));
            WriteLine(PrintLeftAlignedBordered(sentence, sentence.Length + 2));


            DisplayTitle("", "bottom", sentence.Length + 4);

            counter++;
        }

        if (results.Count == 0)
        {
            string sentence = $"The book \"{userInput}\" does not exist in the library";

            DisplayTitle("", "top", sentence.Length + 4);
            WriteLine(PrintCenteredTitle(sentence, sentence.Length + 4));
            DisplayTitle("", "bottom", sentence.Length + 4);
        }

        return results.Count;
    }
}