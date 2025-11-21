namespace Library;

internal class Program
{
    private static void Main(string[] args)
    {
        bool isDisplayingMenu = true;


        while (isDisplayingMenu)
        {
            string? choice = Utility.DisplayMenu();
            
            switch (choice)
            {
                case "0":
                    return; 
                case "1":
                    return; 
                case "2":
                    return; 
                case "3":
                    return; 
                case "4":
                    return; 

                default:
                    break; 
            }
            
        }


    }
}