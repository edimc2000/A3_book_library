namespace Library.support;

/// <summary>Provides text formatting utilities for console display</summary>
/// <remarks>
/// <para>Author: Eddie C.</para>
/// <para>Version: 1.0</para>
/// <para>Since: 2025-11-24</para>
/// </remarks>
internal class Formatting
{
    /// <summary> Displays formatted title with decorative borders</summary>
    /// <param name="title">The title text to display</param>
    /// <param name="cover">Border type: "all", "top", or default for bottom</param>
    public static void DisplayTitle(string title, string cover, int charWdith)
    {
        string lineBoxTop = new('─', charWdith);
        const string cornerLeftTop = " ┌";
        const string cornerRightTop = "┐ ";
        const string cornerLeftBottom = " └";
        const string cornerRightBottom = "┘ ";

        string top = cornerLeftTop + lineBoxTop + cornerRightTop;
        string bottom = cornerLeftBottom + lineBoxTop + cornerRightBottom;

        switch (cover)
        {
            case "all":
                WriteLine();
                string middle = PrintCenteredTitle(title, charWdith);
                ApplyHighlighter(top);
                ApplyHighlighter(middle);
                ApplyHighlighter(bottom);
                break;

            case "top":
                WriteLine(top);
                break;

            default:
                WriteLine(bottom);
                break;
        }
    }


    /// <summary>Applies ANSI color highlighting to text for console display</summary>
    /// <param name="text">Text to apply highlighting to</param>
    public static void ApplyHighlighter(string text)
    {
        text = AnsiColorCodes.Background + AnsiColorCodes.Foreground + text + AnsiColorCodes.Reset;
        WriteLine(text);
    }

    /// <summary>Changes location only for HardCover books</summary>
    /// <param name="instance">Book instance to modify</param>
    /// <param name="location">New location value</param>
    public static void ChangeLocation(IBook instance, string location)
    {
        if (instance is HardCover hardCover) hardCover.Location = location;
    }


    /// <summary>Centers text within a specified width for display formatting</summary>
    /// <param name="title">Text to center</param>
    /// <param name="width">Total width for centering</param>
    /// <returns>Formatted centered string with border characters</returns>
    public static string PrintCenteredTitle(string title, int width)
    {
        int availableWidth = width;

        string centeredTitle = string.Format(" │{0,-" + availableWidth + "}│ ",
            title.PadLeft((availableWidth + title.Length) / 2).PadRight(availableWidth));
        return centeredTitle;
    }

    /// <summary>Formats text as left-aligned within bordered display</summary>
    /// <param name="title">Text to format</param>
    /// <param name="width">Total width for formatting</param>
    /// <returns>Left-aligned string with border characters</returns>
    public static string PrintLeftAlignedBordered(string title, int width)
    {
        int availableWidth = width;
        string borderedAlignedLeft = string.Format(" │  {0,-" + availableWidth + "}│ ", title);
        return borderedAlignedLeft;
    }
}