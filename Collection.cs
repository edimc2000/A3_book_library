namespace Library;

internal class Collection
{
    public static List<IBook> catalogue = new List<IBook>();
   
    private static HardCover seed1 =
        new HardCover("From Third World to First, The Singapore Story: " +
                      "Memoirs of Lee Kuan Yew");

    private static Ebook seed2 =
        new Ebook("One Man's view of the World");

    private static AudioBook seed3 =
        new AudioBook("Lee Kuan Yew: Hard Truths to Keep Singapore Going");


    private static AudioBook seed4 =
        new AudioBook("Singapore: A Modern History");



    public static void SeedCatalogue()
    {
        catalogue.Add(seed1);
        catalogue.Add(seed2);
        catalogue.Add(seed3);
        catalogue.Add(seed4);

        seed4.MarkAsBorrowed();
    }


}
