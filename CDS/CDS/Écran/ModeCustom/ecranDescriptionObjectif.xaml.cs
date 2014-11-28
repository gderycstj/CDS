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
    /// Logique d'interaction pour ecranDescriptionObjectif.xaml
    /// </summary>
    public partial class ecranDescriptionObjectif : Window
    {
        public ecranDescriptionObjectif(string nom,int valeur)
        {
            InitializeComponent();
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

                case "Survivre":
                txtObjectif.Text = "Le but de ce mode est de survivre le plus de tours possibles et de faire le meilleur score";
                break;
            }
        }

        private void btnCommencer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
