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
    /// Logique d'interaction pour ecranCreationObjet.xaml
    /// </summary>
    public partial class ecranCreationObjet : UserControl
    {
        List<String> listeEffets = new List<String>();
        public ecranCreationObjet()
        {
            InitializeComponent();

            //Liste d'effet
            String req = "SELECT nom FROM Effets";
            List<string>[] listeEffet;
            int col = 0;
            listeEffet = Globale.bdCDS.selection(req, 1, ref col);

            for (int i = 0; i < listeEffet.Length; i++)
            {
                cboEffets.Items.Add(listeEffet[i][0]);
            }

            cboEffets.SelectedIndex = 0;

            //Liste d'apparence
            String req2 = "SELECT image FROM Apparences";
            List<string>[] listeApparence;
            int col2 = 0;

            String nomTemp1;

            listeApparence = Globale.bdCDS.selection(req2, 1, ref col2);

            for (int i = 0; i < listeApparence.Length; i++)
            {
                nomTemp1 = listeApparence[i][0].Substring(7);
                nomTemp1 = Retourner(nomTemp1);
                nomTemp1 = nomTemp1.Substring(4);
                nomTemp1 = Retourner(nomTemp1);

                cboApparence.Items.Add(nomTemp1);
            }

            cboApparence.SelectedIndex = 0;
        }

        private void btnAjoutEffets_Click(object sender, RoutedEventArgs e)
        {
            if(cboEffets.SelectedItem != null)
            { 
                if(listeEffets.Count <6)
                {
                    listeEffets.Add(cboEffets.SelectedItem.ToString());
                    AfficherElementGrilleEffet();
                }
                else
                {
                    MessageBox.Show("Vous avez atteint le maximum d'effet possibles pour un objet");
                }
            }
        }

        public void AfficherElementGrilleEffet()
        {
            int rangee = 1;
            int colonneNom = 0;
            int colonneSupprim = 1;

            foreach (string e in listeEffets)
            {
                TextBlock nom = new TextBlock();
                Button s = new Button();
                s.Content = "Supprimer";
                //s.Click += Supprimer;

                nom.Text = e;
                nom.SetValue(Grid.RowProperty, rangee);
                nom.SetValue(Grid.ColumnProperty, colonneNom);
                nom.TextAlignment = TextAlignment.Center;
                nom.FontFamily = new FontFamily("Agency FB");
                nom.FontSize = 20;

                s.SetValue(Grid.RowProperty, rangee);
                s.SetValue(Grid.ColumnProperty, colonneSupprim);

                Grille_Effet.Children.Add(nom);
                Grille_Effet.Children.Add(s);

                rangee++;

                if(cboEffets.SelectedItem.ToString() == nom.Text)
                {
                    cboEffets.Items.RemoveAt(cboEffets.SelectedIndex);
                    cboEffets.SelectedIndex=0;
                }
            }
             
        }

        private void cboApparence_DropDownClosed(object sender, EventArgs e)
        {
            if(cboApparence.SelectedItem != null)
            {
                
                imgObjet.Source = new BitmapImage(new Uri("pack://application:,,,/image/" + cboApparence.SelectedItem.ToString() + ".png", UriKind.RelativeOrAbsolute));
            }
        }

        public static string Retourner(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


    }
}
