using static Library.Utility;
using static Library.LibraryManager;

namespace Library;

internal class Program
{
    //public static List<IBook> catalogue = new List<IBook>();


    private static void Main(string[] args)
    {
        //DisplayMenu("Add More");
        //debugging


        bool isDisplayingMenu = true;

        Clear();
        Collection.SeedCatalogue();



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
                    Search(false, "search");
                    isDisplayingMenu = true;
                    break;

                case "3": // borrow a book 
                    Borrow();
                    isDisplayingMenu = true;
                    break;

                case "4":
                    Return();
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

    }
}