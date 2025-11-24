namespace Library;

/// <summary>Represents a book in the library system</summary>
/// <remarks>
/// <para>Author: Eddie C.</para>
/// <para>Version: 1.2</para>
/// <para>Since: 2025-11-23</para>
/// </remarks>
public interface IBook
{
    /// <summary>Gets or sets the book title</summary>
    string Title { get; set; }

    /// <summary>Gets or sets the book location</summary>
    string Location { get; set; }

    /// <summary>Gets or sets availability status</summary>
    bool IsAvailable { get; set; }

    /// <summary>Marks the book as borrowed</summary>
    void MarkAsBorrowed();

    /// <summary>Marks the book as returned</summary>
    void MarkAsReturned();

    /// <summary>Gets the current location</summary>
    /// <returns>The book location</returns>
    string GetLocation();
}