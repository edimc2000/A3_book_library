
namespace Library
{
    internal class HardCover : IBook
    {
        public void MarkAsBorrowed()
        {
            isAvailable = false;
        }

        public void MarkAsReturned()

        {
            isAvailable = true;
        }

        public string GetLocation()
        {
            return Location;
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
