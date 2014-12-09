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
    /// Logique d'interaction pour ecranSupressionEffet.xaml
    /// </summary>
    public partial class ecranSupressionEffet : UserControl
    {
        public ecranSupressionEffet()
        {
            InitializeComponent();
        }

        private void btnAide_Click(object sender, RoutedEventArgs e)
        {
            Globale.titrePMsg = "Aide";
            Globale.titreMsg = "Écran supression";
            Globale.contenuMsg = "Voici l'écran de supression d'un effet. \n\nIci, vous pouver supprimer vos créations et seulement les votres. \n\nChoisisez, entrez votre mot de passe et valider, c'est tout";

            msg popup = new msg();
            popup.ShowDialog();
        }
    }
}
