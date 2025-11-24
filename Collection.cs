namespace Library;

/// <summary>Represents a collection of books in the library system</summary>
/// <remarks>
/// <para>Author: Eddie C.</para>
/// <para>Version: 1.0</para>
/// <para>Since: 2025-11-22</para>
/// </remarks>
internal class Collection
{
    /// <summary>Gets the Catalogue of books in the collection</summary>
    public static List<IBook> Catalogue = new();

    private static readonly HardCover _seed1 =
        new("From Third World to First, The Singapore Story: " +
            "Memoirs of Lee Kuan Yew");

    private static readonly Ebook _seed2 = new("One Man's view of the World");

    private static readonly AudioBook _seed3 =
        new("Lee Kuan Yew: Hard Truths to Keep Singapore Going");


    private static readonly AudioBook _seed4 = new("Singapore: A Modern History");


    /// <summary>Seeds the catalogue with initial book data</summary><remarks>
    /// Adds four sample books to the catalogue and marks one as borrowed</remarks>
    public static void SeedCatalogue()
    {
        Catalogue.Add(_seed1);
        Catalogue.Add(_seed2);
        Catalogue.Add(_seed3);
        Catalogue.Add(_seed4);

        _seed4.MarkAsBorrowed();
    }
}