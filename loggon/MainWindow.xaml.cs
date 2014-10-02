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

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            BdService bdCDS = new BdService();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            List<string>[] listeJoueur;

           string req = "SELECT * FROM Utilisateurs WHERE nom = '" + txtNomUsager.Text + "' AND motDePasse = '" + txtMotDePasse.Password + "'";

           int nombreRange = 0;
           
           //va sélectionner l'identifiant  qui c'est connecté
          listeJoueur = bdCDS.selection(req, 4, ref nombreRange);
           

           //si le nombre de rangé = 0, ça veut dire que la requête n'a rien retourné, donc que l'utilisateur existe pas
           if(nombreRange == 0)
           {
                MessageBox.Show("Votre nom d'utilisateur ou votre mot de passe sont incorrects ");
                txtNomUsager.Clear();
                txtMotDePasse.Clear();
           }
           else
           {
                MessageBox.Show("L''identifiant est bon");

                foreach (string test in listeJoueur[0]) 
                {
                     
                
                
                 }
           }



        }
        
    
    }
}
