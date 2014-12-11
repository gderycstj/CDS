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
    /// Logique d'interaction pour menuInscription.xaml
    /// </summary>
    public partial class menuInscription : Window
    {
        public menuInscription()
        {
            InitializeComponent();
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            menuJouer menuJ = new menuJouer();
            menuJ.Show();
            Close();
        }

        private void btnCreation_Click(object sender, RoutedEventArgs e)
        {
            bool estValide = true;

            if (txtUtilisateur.Text.Length < 3 || txtUtilisateur.Text.Length > 20)
            {
                txtErreurNom.Text = "Votre nom doit avoir entre 3 et 20 caractères";
                txtUtilisateur.Clear();
                estValide = false;
            }
            if (txtMotDePasse.Password.Length < 3 || txtMotDePasse.Password.Length > 20)
            {
                txtErreurMDP.Text = "Votre mot de passe doit avoir entre 3 et 20 caractères";
                txtMotDePasse.Clear();
                txtConfirmMotPasse.Clear();
                estValide = false;

            }
            if (txtMotDePasse.Password != txtConfirmMotPasse.Password)
            {
                txtErreurConfirm.Text = "Les 2 mots de passe ne sont pas identiques";
                txtMotDePasse.Clear();
                txtConfirmMotPasse.Clear();
                estValide = false;
            }
            if (estValide == true)
            {

                string Req = "INSERT INTO Utilisateurs(idApparence,nom,motDePasse)VALUES ((SELECT idApparence FROM Apparences WHERE image = '/image/bonhommeMod.png'),'" + txtUtilisateur.Text + "','" + txtMotDePasse.Password + "');";
                int id = Globale.bdCDS.Insertion(Req);
                if (id == 0) 
                {
                    txtUtilisateur.Clear();
                    txtMotDePasse.Clear();
                    txtConfirmMotPasse.Clear();;
                }

                 else
                { 
                    Globale.bdCDS.Insertion("COMMIT;");
                    Globale.j1.setJoueur(txtUtilisateur.Text, id, "/image/bonhommeMod.png", true);
                    menuJouer mj = new menuJouer();
                    mj.Show();
                    Close();
                }
            }
        }

        private void btnAide_Click(object sender, RoutedEventArgs e)
        {
            Globale.titrePMsg = "Aide";
            Globale.titreMsg = "Inscription";
            Globale.contenuMsg = "Voici l'écran d'inscription. \n\nIci, vous pouvez vous créer un compte pour pourvoir enregistrer vos score, utiliser l'éditeur et progresser dans le mode niveau. \n\nLe nom doit avoir entre 3 et 20 caraactère. \nLe mot de passe doit avoir entre 3 et 20 caractère et doit être réécrit dans le champs de confirmation de mot de passe.";

            msg popup = new msg();
            popup.ShowDialog();
        }
    }
}
