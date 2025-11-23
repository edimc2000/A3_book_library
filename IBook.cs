namespace Library;

public interface IBook
{
    string Title { get; set; }
    string Location { get; set; }
    bool isAvailable { get; set; }

    void MarkAsBorrowed();
    void MarkAsReturned();
    void GetLocation();
}