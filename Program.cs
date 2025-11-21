namespace Library;

internal class Program
{
    private static void Main(string[] args)
    {
        bool isDisplayingMenu = true;


        //while (isDisplayingMenu)
        //{


        //    string? choice = Utility.DisplayMenu();


        //    switch (choice)
        //    {
        //        case "0":
        //            return; 
        //        case "1": // add a new book 
        //            return; 
        //        case "2": // find a book
        //            return; 
        //        case "3": // borrow a book 
        //            return; // return 
        //        case "4":
        //            return; 

        //        default:
        //            break; 
        //    }

        //}


        // new book sequence test 

        HardCover HC1 = new("testing title Dekada 70");
        WriteLine(HC1.Title);
    }
}