using static Library.Utility;

namespace Library;

internal class LibraryManager
{
    public static void AddNewBook(List<IBook> catalogue)
        //public static string AddNewBook()
    {
        DisplayTitle("Add a book", "all");
        bool isLooping = true;
        while (isLooping)
        {
            string? title = GetInput("title");
            WriteLine("DEBUG ===>>>800 ");
            DisplayAndAddBook(title);


            WriteLine("(1) Entry added.\n\n");


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
                    WriteLine("DEBUG ===>>>600 ");
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
        WriteLine("Search---------------");
        string? userInput = GetInput("title").ToLower();

     
        List<IBook> results = Collection.catalogue
            .Where(b => b.Title.ToLower().Contains(userInput))
            .ToList();

        int counter = 0; 
        foreach (IBook book in results)
        {
            WriteLine($"*{counter+1}********{results.Count}*********");
            WriteLine($"Title: {book.Title}, \nType: {book.GetType().Name}, " +
                      $"\nAvailable:{book.isAvailable}, \nLocation: {book.Location}");
            counter++; 
        }
    

        return results.Count;
    }
}