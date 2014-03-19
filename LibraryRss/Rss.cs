namespace LecteurRSS.Business
{
    public class Rss
    {
        public string Flux { get; set; }
        public string Nom { get; set; }

        public Rss(string flux, string name)
        {
            Flux = flux;
            Nom = name;
        }
    }
}