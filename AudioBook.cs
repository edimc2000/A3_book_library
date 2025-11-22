namespace Library;

internal class AudioBook : IBook
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


    public AudioBook(string title)
    {
        Title = title;
        Location = "Web";
    }
}