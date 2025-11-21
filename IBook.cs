namespace Library;

internal interface IBook
{
    void MarkAsBorrowed();
    void MarkAsReturned();
    void GetLocation();
}