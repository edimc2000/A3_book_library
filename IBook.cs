namespace Library;

internal interface IBook
{
    string Title { get; set; }

    void MarkAsBorrowed();
    void MarkAsReturned();
    void GetLocation();
}