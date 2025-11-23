
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

        public string Title  { get; set; }

        public string Location { get; set; }
        public bool isAvailable { get; set; }

        public HardCover(string title)
        {
            Title = title;
            Location = "Library";
            isAvailable = true;
        }

    }

}
