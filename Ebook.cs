namespace Library;

internal class Ebook : IBook
{
    public void MarkAsBorrowed()
    {
        IsAvailable = false;
    }

    public void MarkAsReturned()

    {
        IsAvailable = true;
    }

    public string GetLocation()
    {
        return Location;
    }

    public string? Title { get; set; }
    public string Location { get; set; }
    public bool IsAvailable { get; set; }

    public Ebook(string title)
    {
        Title = title;
        Location = "Web";
        IsAvailable = true;
    }
}
