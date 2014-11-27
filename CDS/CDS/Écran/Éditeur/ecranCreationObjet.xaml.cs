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
            String req2 = "SELECT image FROM Apparences WHERE image LIKE '/image/Objets/%'";
            List<string>[] listeApparence;
            int col2 = 0;

            String nomTemp1;

            listeApparence = Globale.bdCDS.selection(req2, 1, ref col2);

            for (int i = 0; i < listeApparence.Length; i++)
            {
                nomTemp1 = listeApparence[i][0].Substring(14);
                nomTemp1 = Retourner(nomTemp1);
                nomTemp1 = nomTemp1.Substring(4);
                nomTemp1 = Retourner(nomTemp1);

                cboApparence.Items.Add(nomTemp1);
            }

            cboApparence.SelectedIndex = 0;
            imgObjet.Source = new BitmapImage(new Uri("pack://application:,,,/image/Objets/" + cboApparence.SelectedItem.ToString() + ".png", UriKind.RelativeOrAbsolute));
        }

        private void btnAjoutEffets_Click(object sender, RoutedEventArgs e)
        {
            if(cboEffets.SelectedItem != null)
            { 
                if(listeEffets.Count <1)
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
                nom.FontSize = 26;

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
                
                imgObjet.Source = new BitmapImage(new Uri("pack://application:,,,/image/Objets/" + cboApparence.SelectedItem.ToString() + ".png", UriKind.RelativeOrAbsolute));
            }
        }

        public static string Retourner(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private void btnCreation_Click(object sender, RoutedEventArgs e)
        {
            int nbRangee =0;
            bool validation = true;

            string req = "SELECT nom FROM Objets;";
            List<string>[] listeObjet = Globale.bdCDS.selection(req,1,ref nbRangee);
            for (int i=0; i < listeObjet.Length;i++)
            { 
                if(listeObjet[i][0].ToString() == txtObjet.Text)
                {
                 validation = false;
                }            
            }

            if(validation == true)
            {
               string reqObjet = "INSERT INTO Objets(idUtilisateur,idApparence,nom)"+
               "VALUES (((SELECT idUtilisateur FROM Utilisateurs WHERE nom = '"+Globale.j1.getNom()+"')"+
                ",(SELECT idApparence FROM apparences WHERE image = '/image/Objets/"+cboApparence.SelectedItem.ToString()+".png')"+
                ",'"+txtObjet.Text+"');";
                Globale.bdCDS.Insertion(reqObjet);
                MessageBox.Show(reqObjet);

                string reqObjet2 = "INSERT INTO ObjetsEffets(idObjet,idEffet)"+
                "VALUES((SELECT idObjet FROM Objets WHERE nom ='"+txtObjet.Text+"')"+
                ",(SELECT idEffet FROM Effets WHERE nom = '"+listeEffets[0][0].ToString()+"'));";
                Globale.bdCDS.Insertion(reqObjet2);
            }
        }


    }
}
