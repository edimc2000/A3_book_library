namespace Library;

public class Utility
{
    public static void DisplayMenu(string menuType)
    {
        switch (menuType)
        {
            case "Main Menu":
                WriteLine(string.Format("{0}\n{1}\n\n{2}\n{3}\n{4}\n{5}\n\n{6}",
                    "Menu",
                    "Choose from the following",
                    "Type\t(1) - to Add a new book",
                    "\t(2) - to Find a book",
                    "\t(3) - to Borrow",
                    "\t(4) - to Return",
                    "\t(0) - to Exit\n"
                ));
                break;

            case "Book Type":
                WriteLine(string.Format("{0}\n{1}\n\n{2}\n{3}\n{4}\n",
                    "Book Type",
                    "Choose from the following Book Type ",
                    "Type\t(1) - for E-Book",
                    "\t(2) - for Hard Cover",
                    "\t(3) - for Audio Book"
                ));

                break;

            case "Add More":
                WriteLine(string.Format("{0}\n{1}\n\n{2}\n{3}\n",
                    "Add a book",
                    "Choose from the following Options ",
                    "Type\t(1) - to Add More",
                    "\t(0) - to Exit"
                ));

                break;


            default:
                break;
        }
    }


    public static string GetInput(string inputType)
    {
        switch (inputType)
        {
            case "choice":
                Write("Enter your choice\t: ");
                break;

            case "title":
                Write("Enter the title of the book\t: ");

                break;

            default:
                break;
        }

        string? choice = ReadLine().Trim() ?? "";
        return choice;
    }
}