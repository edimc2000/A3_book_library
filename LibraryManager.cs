using static Library.Utility;

namespace Library;

internal class LibraryManager
{
    public static void AddNewBook(List<IBook> catalogue)
        //public static string AddNewBook()
    {
        bool isLooping = true;
        while (isLooping)
        {
            string? title = GetInput("title");
            WriteLine("DEBUG ===>>>800 ");
            DisplayAndAddBook(title, catalogue);


            WriteLine("(1) Entry added.\n\n");


            isLooping = AddMoreOrExit(catalogue);
        }
    }

    private static void DisplayAndAddBook(string title, List<IBook> catalogue)
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
                    catalogue.Add(eBook);
                    isDisplayingMenu = false;
                    break;

                case "2":
                    HardCover book = new(title);
                    catalogue.Add(book);
                    isDisplayingMenu = false;
                    break;

                case "3":
                    AudioBook audioBook = new(title);
                    catalogue.Add(audioBook);
                    isDisplayingMenu = false;
                    break;

                default:
                    DisplayErrorOperation();
                    break;
            }
        }
    }

    private static bool AddMoreOrExit(List<IBook> catalogue)
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
}