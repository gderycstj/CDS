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
    /// Logique d'interaction pour menuSelectionNiveau.xaml
    /// </summary>
    public partial class menuSelectionNiveau : Window
    {
        public menuSelectionNiveau()
        {
            InitializeComponent();
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            menuSurvie menuS = new menuSurvie();
            menuS.Show();
            Close();
        }

        public void chargerNiveau()
        {
            //Requête BD aller chercher le niveauMax atteint
            /* for(int i=0;i<=niveauMax;i+=)
             * {
             *      btnNiveaui.isEnabled = false;
             * }
			 if(niveauMax != 10)
			 {
				btnNiveauMax+1.isEnabled = false;
			 }
             */
        }
    }
}
