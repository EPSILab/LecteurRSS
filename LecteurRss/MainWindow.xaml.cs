using LecteurRSS.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LecteurRss.IHM
{
    public partial class MainWindow
    {
        private readonly IList<Rss> _liste = new List<Rss>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCharger_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtURL.Text) &&
                !string.IsNullOrEmpty(txtNom.Text) &&
                Uri.IsWellFormedUriString(txtURL.Text, UriKind.Absolute))
            {

                // URL Blog: http://www.jbvigneron.fr/index.php/tutos/linq-1-utiliser-linq-pour-rechercher-calculer-trier-comparer-des-listes/
                bool dejaPresent = _liste.Any(item => item.Nom == txtNom.Text || item.Flux == txtURL.Text);

                if (dejaPresent)
                {
                    MessageBox.Show("Nom ou URL déjà utilisé");
                }
                else
                {
                    Rss rss = new Rss(txtURL.Text, txtNom.Text);
                    listFlux.Items.Add(rss);
                    _liste.Add(rss);
                }
            }
        }

        private void listRSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listFlux.SelectedItem != null)
            {
                Rss selection = (Rss)listFlux.SelectedItem;
                listItems.ItemsSource = AnnonceProvider.Lecture(selection);
            }
        }

        private void lnkItem_Click(object sender, RoutedEventArgs e)
        {
            Annonce selection = (Annonce)listItems.SelectedItem;
            string url = selection.URL;

            if (!string.IsNullOrEmpty(url))
            {
                Process.Start(url);
            }
        }
    }
}