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
    /// Logique d'interaction pour menuInstruction.xaml
    /// </summary>
    public partial class menuInstruction : Window
    {
        public menuInstruction()
        {
            InitializeComponent();
            txtContenu.Width = 512;
            desactivIMG();
            //Désactivation du button But
            if(btnBut.IsEnabled == true)
            {
                btnBut.IsEnabled = false;
            }
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            menuPrincipal menuP = new menuPrincipal();
            menuP.Show();
            Close();

        }

        private void btnBut_Click(object sender, RoutedEventArgs e)
        {
            txtTitreInstruc.Text = "But";
            txtContenu.Width = 512;
            desactivIMG();
            txtContenu.TextAlignment = TextAlignment.Center;
            txtContenu.Text = "La chambre de survie vous confrontera à plusieurs niveaux de survie qui augmente en difficulté. En outre, si la peur vous hante, vous pourriez toujours vous entrainer face aux plus puissants poursuivants avant de relevé le défi.\n Dans la chambre de survie, vous allez devoir survivre à des vagues de poursuivants de plus en plus acharnée au fil du temps et des niveaux. De plus, plusieurs variétés de poursuivants seront disponibles et s'ajouterons aux poursuivants de « base » présente dans les premiers niveaux. \n"+
            "Vous devrez éviter les poursuivants au péril de votre vie. Ceux-ci disparaitrons lorsqu'ils atteindront le bord de la grille vous donnant des points.Cependant, si vous êtes touchés 3 fois, la partie sera terminée.\n Saurez-vous survivre à la chambre de survie?";

            //Activation/Désactivation des boutons
            if (btnBut.IsEnabled == true)
            {
                btnBut.IsEnabled = false;
            }
            btnCommandes.IsEnabled = true;
            btnPoursuivants.IsEnabled = true;
            btnObjets.IsEnabled = true;
        }

        private void btnCommandes_Click(object sender, RoutedEventArgs e)
        {
            txtTitreInstruc.Text = "Commandes";
            txtContenu.Width = 350;
            txtContenu.Text = "|"+"Déplacement du Personnage"+"|"+" \n"+
            "Version Clavier\n Utiliser les flèches directionelles et la touche entrer pour passer votre tour.\n\n"+
            "Version Souris\n Cliquer sur les flèches directionelles directement dans l'interface du jeu et cliquer sur le bouton rouge pour passer votre tour.\n \n" +
            "|"+"Utilisation d'objet"+"|"+"\n"+
            "Version Clavier\n Utiliser les touches Z(Case de Gauche) et X(Case de droite) pour utiliser vos objets\n\n" +
            "Version Souris\n Cliquer sur la case contenant l'objet\n\n";

            //Désactivation des images
            desactivIMG();
            //Activation des images nécéssaires
            imgClavierMouv.Visibility = Visibility.Visible;
            imgClavierObjet.Visibility = Visibility.Visible;
            imgCliquerMouv.Visibility = Visibility.Visible;
            imgCliquerObjet.Visibility = Visibility.Visible;
            
            //Activation/Désactivation des boutons
            if (btnCommandes.IsEnabled == true)
            {
                btnCommandes.IsEnabled = false;
            }
            btnBut.IsEnabled = true;
            btnPoursuivants.IsEnabled = true;
            btnObjets.IsEnabled = true;
        }

        private void btnPoursuivants_Click(object sender, RoutedEventArgs e)
        {
            txtTitreInstruc.Text = "Poursuivants";
            txtContenu.Width = 350;
            txtContenu.Text ="|"+"Carré Vert"+"|"+" \n"+
            "Le carré vert se déplace en ligne droite(Horizontalement).\n Il se déplacera seulement de une case à chaque tour.\n\n"+
            "|"+"Carré bleu"+"|"+" \n"+ "Le carré bleu se déplace en ligne droite(Vertical).\n Il se déplacera seulement de une case à chaque tour.\n\n"+
            "|"+"Triangle"+"|"+" \n"+ "Le triangle se déplace de toutes les façon possible vers la bas selon la position du personnage.\n Il se déplacera seulement de une case à chaque tour.\n D'autres poursuivants sont disponible. À vous de les découvrir.";

            //Désactivation des images
            desactivIMG();
            //Activation des images nécéssaires
            imgCarreBleu.Visibility = Visibility.Visible;
            imgCarreVert.Visibility = Visibility.Visible;
            imgTriangle.Visibility = Visibility.Visible;

            //Activation/Désactivation des boutons
            if (btnPoursuivants.IsEnabled == true)
            {
                btnPoursuivants.IsEnabled = false;
            }
            btnCommandes.IsEnabled = true;
            btnBut.IsEnabled = true;
            btnObjets.IsEnabled = true;
        }

        private void btnObjets_Click(object sender, RoutedEventArgs e)
        {
            txtTitreInstruc.Text = "Objets";
            txtContenu.Width = 350;
            txtContenu.Text = "|" + "Potion de vie" + "|" + " \n" +
            "Lorsqu'elle est utilisée, la potion de vie vous redonne un point de vie\n\n" +
            "|" + "Potion de vitesse" + "|" + " \n" + "Lorsqu'elle est utilisée , la potion de vitesse vous permet de vous déplacé deux fois par tour pendant 2 tours\n\n" +
            "|" + "Bombe" + "|" + " \n" + "Lorsqu'elle est utilisée, la bombe se pose a votre case et explose 2 tours plus tard détruisant tous les poursuivants sur la case. \n\n\n D'autres objets sont disponible. À vous de les découvrir.";

            //Désactivation des images
            desactivIMG();
            //Activation des images nécéssaires
            imgBombe.Visibility = Visibility.Visible;
            imgPotionRouge.Visibility = Visibility.Visible;
            imgPotionVitesse.Visibility = Visibility.Visible;

            //Activation/Désactivation des boutons
            if (btnObjets.IsEnabled == true)
            {
                btnObjets.IsEnabled = false;
            }
            btnCommandes.IsEnabled = true;
            btnPoursuivants.IsEnabled = true;
            btnBut.IsEnabled = true;
        }

        public void desactivIMG()
        {
            imgBombe.Visibility = Visibility.Hidden;
            imgCarreBleu.Visibility = Visibility.Hidden;
            imgCarreVert.Visibility = Visibility.Hidden;
            imgClavierMouv.Visibility = Visibility.Hidden;
            imgClavierObjet.Visibility = Visibility.Hidden;
            imgCliquerMouv.Visibility = Visibility.Hidden;
            imgCliquerObjet.Visibility = Visibility.Hidden;
            imgPotionRouge.Visibility = Visibility.Hidden;
            imgPotionVitesse.Visibility = Visibility.Hidden;
            imgTriangle.Visibility = Visibility.Hidden;
        }
    }
}
