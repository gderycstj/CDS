using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CDS
{
    /// <summary>
    /// Logique d'interaction pour ecranDebutPartie.xaml
    /// </summary>
    public partial class ecranDebutPartie : Window
    {
        bool verification = true;
        public ecranDebutPartie(string provenance,string mode2)
        {
            InitializeComponent();
            Globale.mode = mode2;
            if (Globale.j1.getNom() == "visiteur")
            {
                txtPub.Text = "Vous souhaitez partager vos pointages également? Créez-vous un compte dès maintenant pour envoyé automatiquement vos pointages et à accéder a de nombreux autres modes de jeux!";
            }
            else
            {
              txtPub.Text = "";
            }
            if(provenance == "menuJouer")
            {
                btnCommencerPartie.Content = "Retour";
                verification = false;
            }
            else
            {
                btnCommencerPartie.Content = "Commencer la partie";
                if (Globale.j1.getNom() != "visiteur")
                {
                    txtMeilleursScores.Text= "Votre Top 10";
                    txtPub.Text ="Pouvez-vous surpasser vos anciens scores? \n\nSurvivez le plus longtemps possible pour le découvrir";
                }
            }
            AfficherScore();
        }

        public void AfficherScore()
        {
            List<string>[] meilleurScore;

            if(verification == true && Globale.j1.getNom() != "visiteur")
            {
                meilleurScore = Globale.score.obtenirScore(false);
            }
            else
            {
                meilleurScore = Globale.score.obtenirScore(true);
            }

            for (int i = 0; i < meilleurScore.Length; i++)
            {
                if (meilleurScore[i][0] != "")
                {
                    Thickness marge = new Thickness();
                    marge.Left = 10;
                    marge.Top = 3;

                    TextBlock nom = new TextBlock();
                    TextBlock score = new TextBlock();

                    //Change le font Family
                    nom.FontFamily = new FontFamily("Agency FB");
                    score.FontFamily = new FontFamily("Agency FB");

                    //Change le fontSize
                    nom.FontSize = 18;
                    score.FontSize = 18;

                    //Change le padding
                    nom.Padding = marge;
                    score.Padding = marge;

                    nom.Text = meilleurScore[i][0];
                    score.Text = meilleurScore[i][1];

                    Grid.SetColumn(nom, 0);
                    Grid.SetRow(nom, i);

                    Grid.SetColumn(score, 1);
                    Grid.SetRow(score, i);
                    GrilleScore.Children.Add(nom);
                    GrilleScore.Children.Add(score);
                }
            }


        }

        private void btnCommencerPartie_Click(object sender, RoutedEventArgs e)
        {
            if(verification == false)
            {
                menuJouer menuJ = new menuJouer();
                menuJ.Show();
            }
            Close();
        }
    }
}
