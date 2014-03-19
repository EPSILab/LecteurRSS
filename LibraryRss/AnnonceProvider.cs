using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace LecteurRSS.Business
{
    public static class AnnonceProvider
    {
        /// <summary>
        /// Changer auteur par la description et mettre en place un affichage correct !
        /// </summary>
        /// <param name="fluxrss">Le flux RSS à charger</param>
        /// <returns></returns>
        public static IList<Annonce> Lecture(Rss fluxrss)
        {
            string URL = string.Empty;
            IList<Annonce> annonces = new List<Annonce>();

            XmlTextReader reader = new XmlTextReader(fluxrss.Flux);
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            if (feed != null)
            {
                foreach (SyndicationItem item in feed.Items)
                {
                    foreach (SyndicationLink item2 in feed.Links)
                    {
                        URL += item2.Uri + " ";
                    }

                    annonces.Add(new Annonce(item.Title.Text, item.Summary.Text, URL));
                }
            }

            return annonces;
        }
    }
}
