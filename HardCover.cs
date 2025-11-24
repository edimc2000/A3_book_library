namespace Library;

/// <summary>Represents a hard cover book in the library system</summary>
/// <remarks>
/// <para>Author: Eddie C.</para>
/// <para>Version: 1.0</para>
/// <para>Since: 2025-11-22</para>
/// </remarks>
internal class HardCover : IBook
{
    /// <summary>Gets or sets the book title</summary>
    public string Title { get; set; }


    /// <summary>Gets or sets the book title</summary>
    public bool IsAvailable { get; set; }


    /// <summary>Gets or sets the book location</summary>
    public string Location { get; set; }

    /// <summary>Initializes a new hardcover book</summary>
    /// <param name="title">The title of the book</param>
    public HardCover(string title)
    {
        Title = title;
        Location = "Library";
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
    /// <summary>Changes location</summary>
    /// /// <param name="location">new location</param>
    //public void ChangeLocation(string location)
    //{
    //    Location = location;
    //}
}