namespace Library;

internal class Ebook : IBook
{
    public void MarkAsBorrowed()
    {
    }

    public void MarkAsReturned()
    {
    }

    public void GetLocation()
    {
    }

    public string? Title { get; set; }
    public string Location { get; set; }
    public bool isAvailable { get; set; }

    public Ebook(string title)
    {
        Title = title;
        Location = "Web";
        isAvailable = true;
    }
}