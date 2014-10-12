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
        BdService bdCDS = new BdService();

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
                estValide = false;
            }
            if (txtMotDePasse.Password.Length < 3 || txtMotDePasse.Password.Length > 30)
            {
                txtErreurMDP.Text = "Votre mot de passe doit avoir entre 3 et 20 caractères";
                estValide = false;

            }
            if (txtMotDePasse.Password != txtConfirmMotPasse.Password)
            {
                txtErreurConfirm.Text = "Les 2 mots de passe que vous avez écrit ne sont pas identique";
                estValide = false;
            }
            if (estValide == true)
            {

                string Req = "INSERT INTO Utilisateurs(idApparence,nom,motDePasse)VALUES ((SELECT idApparence FROM Apparences WHERE image = 'test.pnj'),'" + txtUtilisateur.Text + "','" + txtMotDePasse.Password + "');";
                int id = bdCDS.Insertion(Req);
                bdCDS.Insertion("COMMIT;");
                Globale.j1.setJoueur(txtUtilisateur.Text, id, "test.png", true);
                menuJouer mj = new menuJouer();
                mj.Show();
                Close();
            }
        }
    }
}
