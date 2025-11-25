using static Library.support.Utility;
using static Library.support.LibraryManager;

namespace Library;

/// <summary>Main entry point for the Library Management System</summary>
/// <remarks>
/// <para>Author: Eddie C.</para>
/// <para>Version: 1.0</para>
/// <para>Since: 2025-11-22</para>
/// </remarks>
internal class Program
{
    /// <summary>Main application entry point</summary>
    /// <param name="args">Command line arguments</param>
    /// <remarks>Initializes the library system and displays the main menu loop</remarks>
    private static void Main(string[] args)
    {
        bool isDisplayingMenu = true;

        Clear();
        Collection.SeedCatalogue();

        while (isDisplayingMenu)
        {
            DisplayMenu(MenuTypes.MainMenu);
            string? choice = GetInput(InputTypes.Choice);

            switch (choice)
            {
                case BookProcesses.MainMenuAdd:
                    AddNewBook(Collection.Catalogue);
                    isDisplayingMenu = true;
                    break;

                case BookProcesses.MainMenuSearch:
                    Search(false, BookActions.Find);
                    isDisplayingMenu = true;
                    break;

                case BookProcesses.MainMenuBorrow:
                    Borrow();
                    isDisplayingMenu = true;
                    break;

                case BookProcesses.MainMenuReturn:
                    Return();
                    isDisplayingMenu = true;
                    break;

                case BookProcesses.MainMenuExit:
                    isDisplayingMenu = false;
                    break;

                default:
                    DisplayErrorOperation();
                    break;
            }
        }
    }
}