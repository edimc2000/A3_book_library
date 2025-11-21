
namespace Library
{
    internal class HardCover : IBook
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

        public string? Title  { get; set; }

        public HardCover(string title)
        {
            Title = title;
        }

    }

}
