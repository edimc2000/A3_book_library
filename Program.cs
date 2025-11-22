using static Library.Utility;

namespace Library;

internal class Program
{
    public static List<IBook> catalogue = new List<IBook>();

    private static void Main(string[] args)
    {
        bool isDisplayingMenu = true;
        DisplayMainMenu("Main Menu");

        while (isDisplayingMenu)
        {
            string? choice = GetInput("choice");

            switch (choice)
            {
                case "1": // add a new book 
                    AddNewBook(catalogue);
                    isDisplayingMenu = false;
                    break;

                case "2": // find a book
                    isDisplayingMenu = false;
                    break;

                case "3": // borrow a book 
                    isDisplayingMenu = false;
                    break;

                case "4":
                    isDisplayingMenu = false;
                    break;

                case "0":
                    isDisplayingMenu = false;
                    break;

                default:
                    WriteLine("This operation is not supported, please try again.");
                    break;
            }
        }

        WriteLine("******************");
        WriteLine( catalogue);

        foreach (IBook book in catalogue)
        {
            WriteLine($"Title: {book.Title}, Type: {book.GetType().Name}, " +
                      $"Borrowed:, Location:");
        }


    }
}