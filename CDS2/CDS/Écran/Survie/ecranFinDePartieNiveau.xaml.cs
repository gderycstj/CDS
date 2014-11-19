using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CDS
{
    /// <summary>
    /// Logique d'interaction pour menuFinDePartieNiveau.xaml
    /// </summary>
    public partial class menuFinDePartieNiveau : Window
    {
        Timer timerFin = new Timer();
        public menuFinDePartieNiveau()
        {
            InitializeComponent();
            timerFin.Interval = 100;
            timerFin.Tick += new EventHandler(OnTimedEvent);
            if(Globale.j1.estConnecte == false)
            {
                btnNiveauSuivant.IsEnabled = false;
                txtPub.Text = "Créer vous un compte pour pouvoir accéder aux prochains niveaux disponibles";
            }
            else if(Globale.j1.estConnecte == true)
            {
                if (Globale.iNumeroDuNiveauAJouer < 10)
                {
                    txtPub.Text = "Vous avez survécu au niveau "+ Globale.iNumeroDuNiveauAJouer+" , mais il reste toujours les niveaux supérieur à surpasser.";
                    Globale.iNumeroDuNiveauAJouer += 1;
                    sauvegarder();
                }
                else
                {
                    txtPub.Text = "Félicitation, vous êtes parvenu à survivre aux dix niveaux de la chambre de survie";
                    btnNiveauSuivant.IsEnabled = false;
                }
            }

        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            menuSurvie menuS = new menuSurvie();
            menuS.Show();
            Close();
        }

        private void btnSelectionNiveau_Click(object sender, RoutedEventArgs e)
        {
            menuSelectionNiveau menuSelec = new menuSelectionNiveau();
            menuSelec.Show();
            Close();
        }

        private void btnNiveauSuivant_Click(object sender, RoutedEventArgs e)
        {
            timerFin.Start();
            jeuNiveau jeu = new jeuNiveau();
            jeu.Show();
        }

        private void sauvegarder() 
        {

                    List<string>[] lstSauvegarde;
                    int col = 0;
                    string req = "SELECT idProgression,niveauAtteint,niveauAtteintMax FROM Progressions p INNER JOIN Utilisateurs u on p.idUtilisateur = u.idUtilisateur INNER JOIN ModesDeJeu m ON m.idModeDeJeu = p.idModeDeJeu WHERE u.nom = '" + Globale.j1.getNom() + "' AND m.nom = '" + Globale.mode + "';";
                    lstSauvegarde = Globale.bdCDS.selection(req,3,ref col);

                    if (col == 0) 
                    {
                        string req2 = "INSERT INTO Progressions(idUtilisateur,idModeDeJeu,niveauAtteint,niveauAtteintMax) VALUES((SELECT idUtilisateur FROM Utilisateurs WHERE nom = '" + Globale.j1.getNom() + "'),(SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = '" + Globale.mode + "')," + Globale.iNumeroDuNiveauAJouer + "," + Globale.iNumeroDuNiveauAJouer + ");";

                        Globale.bdCDS.Insertion(req2);
                        lstSauvegarde = Globale.bdCDS.selection(req, 3, ref col);
                    }

                    if (Convert.ToInt32(lstSauvegarde[0][2]) > Globale.iNumeroDuNiveauAJouer)
                    {
                        req = "UPDATE Progressions SET niveauAtteint = " + Globale.iNumeroDuNiveauAJouer + " WHERE idProgression = " + lstSauvegarde[0][0] + ";";
                    }
                    else 
                    {
                        req = "UPDATE Progressions SET niveauAtteint = " + Globale.iNumeroDuNiveauAJouer + " ,niveauAtteintMax = " + Globale.iNumeroDuNiveauAJouer + " WHERE idProgression = " + lstSauvegarde[0][0] + ";";                   
                    }

                    Globale.bdCDS.modification(req);
        
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            timerFin.Stop();
            Close();
        }
        
    }

}
