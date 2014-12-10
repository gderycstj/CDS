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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CDS
{
    /// <summary>
    /// Logique d'interaction pour ecranSupressionObjet.xaml
    /// </summary>
    public partial class ecranSupressionObjet : UserControl
    {
        public ecranSupressionObjet()
        {
            InitializeComponent();
        }

        private void btnAide_Click(object sender, RoutedEventArgs e)
        {
            Globale.titrePMsg = "Aide";
            Globale.titreMsg = "Écran suppression";
            Globale.contenuMsg = "Voici l'écran de suppression d'un objet. \n\nIci, vous pouvez supprimer vos créations et seulement les votres. \n\nsélectionner, entrez votre mot de passe et valider, c'est tout";

            msg popup = new msg();
            popup.ShowDialog();
        }
    }
}
