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
            txtContenu.TextAlignment = TextAlignment.Center;
            txtContenu.Text = "La chambre de survie vous confrontera à plusieurs niveaux de survie qui augmente en difficulté. En outre, si la peur vous hante, vous pourriez toujours vous entrainer face aux plus puissants poursuivants avant de relevé le défi.\n Dans la chambre de survie, vous allez devoir survivre à des vagues de poursuivants de plus en plus acharnée au fil du temps et des niveaux. De plus, plusieurs variétés de poursuivants seront disponibles et s'ajouterons aux poursuivants de « base » présente dans les premiers niveaux. \n"+
            "Sauvegardez votre  partie, partagez vos score mémorables, surpassez l'élite des survivants. Le défi sera de taille. Et si vous finissez par le vaincre, d'autres chambres seront assemblées par vous et les autres survivants. Saurez-vous survivre à \n"+
            "la chambre de survie?";

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
            txtContenu.Text = "blablablabla";

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
            txtContenu.Text = "blablablabla";

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
            txtContenu.Text = "blablablabla";

            //Activation/Désactivation des boutons
            if (btnObjets.IsEnabled == true)
            {
                btnObjets.IsEnabled = false;
            }
            btnCommandes.IsEnabled = true;
            btnPoursuivants.IsEnabled = true;
            btnBut.IsEnabled = true;
        }
    }
}
