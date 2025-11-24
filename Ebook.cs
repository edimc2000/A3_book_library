namespace Library;

/// <summary>Represents an ebook in the library system</summary>
/// <remarks>
/// <para>Author: Eddie C.</para>
/// <para>Version: 1.0</para>
/// <para>Since: 2025-11-22</para>
/// </remarks>
internal class Ebook : IBook
{
    /// <summary>Gets or sets the book title</summary>
    public string Title { get; set; }


    /// <summary>Gets or sets the book title</summary>
    public bool IsAvailable { get; set; }


    /// <summary>Gets or sets the book location</summary>
    public string Location { get; set; }

    /// <summary>Initializes a new Ebook</summary>
    /// <param name="title">The title of the book</param>
    public Ebook(string title)
    {
        Title = title;
        Location = "Web";
        IsAvailable = true;
    }


    /// <summary>Marks the book as borrowed</summary>
    public void MarkAsBorrowed()
    {
        IsAvailable = false;
    }

    /// <summary>Marks the book as returned</summary>
    public void MarkAsReturned()

    {
        IsAvailable = true;
    }

    /// <summary>Gets the current location</summary>
    /// <returns>The book location</returns>
    public string GetLocation()
    {
        return Location;
    }
}