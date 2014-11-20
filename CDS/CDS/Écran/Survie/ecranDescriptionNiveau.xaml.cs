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
    /// Logique d'interaction pour ecranDescriptionNiveau.xaml
    /// </summary>
    public partial class ecranDescriptionNiveau : Window
    {
        public ecranDescriptionNiveau(string nom,int valeur)
        {       
            InitializeComponent();
            txtTitre.Text = "Niveau " + Globale.iNumeroDuNiveauAJouer;
            Affichage();
            switch(nom)
            {
                case "Point":
                txtObjectif.Text = "Pour gagner, il vous faudra atteindre un pointage de " + valeur + " points en évitant les poursuivants à vos trousses. Les objets sont là pour vous aidez. Utilisez-les";
                break;

                case "Tour":
                txtObjectif.Text = "Pour gagner, il vous faudra survivre pendant  " + valeur + " tours en évitant les poursuivants à vos trousses. Les objets sont là pour vous aidez. Utilisez-les";
                break;

                case "Armure":
                txtObjectif.Text = "Il vous faudra récupérer des objets 'Armure' et les garder en stock. Garder "+ valeur +" armures en stock pour gagner";
                break;
            }
        }

        private void btnCommencer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Affichage()
        {
               switch(Globale.iNumeroDuNiveauAJouer)
            {
                case 1:
                    txtTitreNiveau.Text = "Que la fête commence!";
                    txtPoursuivantDispo.Text = "Carré, Losange";
                    txtObjetDispo.Text = "Potion de vitesse, Barrière, Potion de vie";
                    txtRestriction.Text = "Aucune";
                    imgPoursuivant.Source = new BitmapImage(new Uri(@"/image/carreVert.png", UriKind.Relative));
                    break;
                case 2:
                    txtTitreNiveau.Text = "Rupture de Stock: Potion de vie";
                    txtPoursuivantDispo.Text = "Carré, Losange";
                    txtObjetDispo.Text = "Potion de vitesse, Barrière";
                    txtRestriction.Text = "Aucune";
                    imgPoursuivant.Source = new BitmapImage(new Uri(@"/image/potionVie.png", UriKind.Relative));
                    break;
                case 3:
                    txtTitreNiveau.Text = "Diagonale?!";
                    txtPoursuivantDispo.Text = "Losange, Triangle";
                    txtObjetDispo.Text = "Potion de vitesse, Barrière, Armure";
                    txtRestriction.Text = "Une Vie Seulement";
                    imgPoursuivant.Source = new BitmapImage(new Uri(@"/image/LosangeJaune.png", UriKind.Relative));
                    break;
                case 4:
                    txtTitreNiveau.Text = "Un Triangle!?";
                    txtPoursuivantDispo.Text = "Carré, Losange, Triangle";
                    txtObjetDispo.Text = "Potion de vitesse, Barrière, Armure";
                    txtRestriction.Text = "Deux Vies Seulement";
                    imgPoursuivant.Source = new BitmapImage(new Uri(@"/image/triangle.png", UriKind.Relative));
                    break;
                case 5:
                    txtTitreNiveau.Text = "Au gouffre de la mort";
                    txtPoursuivantDispo.Text = "Carré, Losange, Zappy, Cercle";
                    txtObjetDispo.Text = "Potion de vitesse, Barrière, Armure";
                    txtRestriction.Text = "Une Vie Seulement";
                    imgPoursuivant.Source = new BitmapImage(new Uri(@"/image/coeurPlein.png", UriKind.Relative));
                    break;
                case 6:
                    txtTitreNiveau.Text = "Zappyyyyyyyyyyyyy!";
                    txtPoursuivantDispo.Text = "Zappy";
                    txtObjetDispo.Text = "Potion de vitesse";
                    txtRestriction.Text = "Aucune";
                    imgPoursuivant.Source = new BitmapImage(new Uri(@"/image/zappy.png", UriKind.Relative));
                    break;
                case 7:
                    txtTitreNiveau.Text = "Armure à gogo";
                    txtPoursuivantDispo.Text = "Carré, Losange, Triangle, Zappy, Cercle";
                    txtObjetDispo.Text = "Barrière, Armure";
                    txtRestriction.Text = "Aucune";
                    imgPoursuivant.Source = new BitmapImage(new Uri(@"/image/armure.png", UriKind.Relative));
                    break;
                case 8:
                    txtTitreNiveau.Text = "Erreur Impossible";
                    txtPoursuivantDispo.Text = "Triangle, Zappy, Cercle";
                    txtObjetDispo.Text = "Potion de vitesse, Barrière";
                    txtRestriction.Text = "Une Vie Seulement";
                    imgPoursuivant.Source = new BitmapImage(new Uri(@"/image/bonhommeMort.png", UriKind.Relative));
                    break;
                case 9:
                    txtTitreNiveau.Text = "Sauvez-vous pauvre fou!";
                    txtPoursuivantDispo.Text = "Triangle";
                    txtObjetDispo.Text = "Potion de vie, Armure";
                    txtRestriction.Text = "Deux Vies ,Deux d'armures au départ";
                    imgPoursuivant.Source = new BitmapImage(new Uri(@"/image/sprint.png", UriKind.Relative));
                    break;
                case 10:
                    txtTitreNiveau.Text = "C'est la fin!";
                    txtPoursuivantDispo.Text = "Cercle";
                    txtObjetDispo.Text = "Potion de vie, Armure, Barrière, Potion de vitesse";
                    txtRestriction.Text = "Aucune";
                    imgPoursuivant.Source = new BitmapImage(new Uri(@"/image/cercle.png", UriKind.Relative));
                    break;

            }
        }
    }
}
