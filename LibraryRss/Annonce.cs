namespace LecteurRSS.Business
{
    public class Annonce
    {

        public string Titre { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }

        public Annonce(string title, string descrip, string url)
        {
            Titre = title;
            Description = descrip;
            URL = url;
        }
    }
}