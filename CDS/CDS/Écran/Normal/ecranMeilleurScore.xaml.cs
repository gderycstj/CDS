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
    /// Logique d'interaction pour ecranMeilleurScore.xaml
    /// </summary>
    public partial class ecranMeilleurScore : Window
    {
        public ecranMeilleurScore()
        {
            InitializeComponent();
            if (Globale.j1.getNom() == "visiteur")
            {
                txtPub.Text = "Vous souhaitez partager vos pointages également? Créez-vous un compte dès maintenant pour envoyé automatiquement vos pointages et à accéder a de nombreux autres modes de jeux!";
            }
            else 
            {
                //envoie le meilleur score
                Globale.score.envoyerScore();

                txtPub.Text = "Votre pointage a été enregistré, merci d'avoir joué.";
            
            }
            AfficherScore();
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            menuJouer menuJ = new menuJouer();
            menuJ.Show();
            Close();
        }

        private void btnRejouer_Click(object sender, RoutedEventArgs e)
        {
            Globale.j1.positionJoueur.posX=5;
            Globale.j1.positionJoueur.posY=5;
            JeuNormal menuJeu = new JeuNormal();
            menuJeu.Show();
            Close();
        }

        public void AfficherScore() 
        {
            List<string>[] meilleurScore;

            meilleurScore = Globale.score.obtenirScore(true);
            for (int i = 0; i < meilleurScore.Length; i++) 
            {
                if(meilleurScore[i][0] != "")
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

                     Grid.SetColumn(nom,0);
                     Grid.SetRow(nom, i);

                     Grid.SetColumn(score,1);
                     Grid.SetRow(score, i);
                     GrilleScore.Children.Add(nom);
                     GrilleScore.Children.Add(score);
                 }
            }
        
        
        }
    }
}
