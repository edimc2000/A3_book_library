using static Library.Utility;
using static Library.LibraryManager;

namespace Library;

internal class Program
{
    //public static List<IBook> catalogue = new List<IBook>();


    private static void Main(string[] args)
    {
        bool isDisplayingMenu = true;
        //DisplayMenu("Main Menu");
        Clear();
        Collection.SeedCatalogue();

        //foreach (IBook book in Collection.catalogue)
        //{
        //    WriteLine("******************");
        //    WriteLine($"Title: {book.Title}, \nType: {book.GetType().Name}, " +
        //              $"\nAvailable:{book.isAvailable}, \nLocation: {book.Location}");
        //}

        while (isDisplayingMenu)
        {
            DisplayMenu("Main Menu");
            string? choice = GetInput("choice");

            switch (choice)
            {
                case "1": // add a new book 
                    AddNewBook(Collection.catalogue);
                    isDisplayingMenu = true;
                    break;

                case "2": // find a book
                    Search();
                    isDisplayingMenu = true;
                    break;

                case "3": // borrow a book 
                    isDisplayingMenu = true;
                    break;

                case "4":
                    isDisplayingMenu = true;
                    break;

                case "0":
                    isDisplayingMenu = false;
                    break;

                default:
                    DisplayErrorOperation();
                    break;
            }
        }

        //WriteLine("******************");
        //WriteLine(Collection.catalogue);

        //foreach (IBook book in Collection.catalogue)
        //{
        //    WriteLine("******************");
        //    WriteLine($"Title: {book.Title}, \nType: {book.GetType().Name}, " +
        //              $"\nAvailable:{book.isAvailable}, \nLocation: {book.Location}");
        //}
    }
}