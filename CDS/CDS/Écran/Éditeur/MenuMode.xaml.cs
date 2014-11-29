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
    /// Logique d'interaction pour menuMode.xaml
    /// </summary>
    public partial class menuMode : UserControl
    {
        private class PoursuivantNiveau
        {
            public string nom{get;set;}
            public string valeur{get;set;}
            public string rarete{get;set;}

            public PoursuivantNiveau(string n, string v, string r) 
            {
                rarete = r;
                valeur = v;
                nom = n;
            }

        }

        private class ObjetNiveau
        {
            public string nom { get; set; }

            public ObjetNiveau(string n)
            {
                nom = n;
            }

        }

        List<PoursuivantNiveau> lstPoursuivant = new List<PoursuivantNiveau>();
        List<ObjetNiveau> lstObjet = new List<ObjetNiveau>();

        public menuMode()
        {
            InitializeComponent();

            //Sélection liste poursuivant
            String req = "SELECT nom FROM Poursuivants WHERE idUtilisateur = (SELECT idUtilisateur FROM Utilisateurs WHERE nom = '" + Globale.j1.getNom() + "') OR (SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin');";
            List<string>[] listePoursuivant;
            int col = 0;
            listePoursuivant = Globale.bdCDS.selection(req, 1, ref col);

            for (int i = 0; i < listePoursuivant.Length; i++)
            {
                cboPoursuivant.Items.Add(listePoursuivant[i][0]);
            }

            cboPoursuivant.SelectedIndex = 0;

            //Sélection liste objet
            String req2 = "SELECT nom FROM Objets WHERE idUtilisateur = (SELECT idUtilisateur FROM Utilisateurs WHERE nom = '" + Globale.j1.getNom() + "')  OR (SELECT idUtilisateur FROM Utilisateurs WHERE nom = 'Admin');";
            List<string>[] listeObjet;
            listeObjet = Globale.bdCDS.selection(req2, 1, ref col);

            for (int i = 0; i < listeObjet.Length; i++)
            {
                cboObjet.Items.Add(listeObjet[i][0]);
            }
            cboObjet.SelectedIndex = 0;


            //sélection liste objectif
            String req3 = "SELECT nom FROM Objectifs GROUP BY nom;";
            List<string>[] listeObjectif;
            listeObjectif = Globale.bdCDS.selection(req3, 1, ref col);

            for (int i = 0; i < listeObjectif.Length; i++)
            {
                cboObjectif.Items.Add(listeObjectif[i][0]);
            }
            cboObjectif.SelectedIndex = 0;

        }

        /// <summary>
        /// ajout d'un poursuivant dans la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPoursuivants_Click(object sender, RoutedEventArgs e) 
        {
            if (txtRarete.Text == "" || txtValeur.Text == "")
            {
                MessageBox.Show("Vous devez rentrer une valeur et une rareté");

            }
            else
            {
                if (lstPoursuivant.Count <= 7)
                {
                    PoursuivantNiveau poursuivant = new PoursuivantNiveau(cboPoursuivant.SelectedItem.ToString(), txtValeur.Text, txtRarete.Text);
                    lstPoursuivant.Add(poursuivant);
                    AfficherElementGrillePoursuivant();

                    txtRarete.Clear();
                    txtValeur.Clear();

                }
                else
                {
                    MessageBox.Show("Vous avez atteint le maximum de poursuivants possibles");
                }
                if (cboPoursuivant.Items.Count == 0)
                {
                    btnAjoutPoursuivant.IsEnabled = false;
                }

            }
         }

         /// <summary>
         /// supression d'un poursuivant dans la liste
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         public void Supprimer(object sender, RoutedEventArgs e) 
        {
            //    Label label = sender as Label;
           
              //  int rangee = (int)label.GetValue(Grid.RowProperty);

                //lstPoursuivant.RemoveAt(rangee);
                //AfficherElementGrillePoursuivant();
       }



       /// <summary>
       /// va afficher les éléments de la grille de poursuivant
       /// </summary>
        public void AfficherElementGrillePoursuivant() 
        {
            int rangee = 1;
            int colonneNom = 0;
            int colonneValeur = 1;
            int colonneRarete = 2;
            int colonneSupprim = 3;

            foreach (PoursuivantNiveau p in lstPoursuivant)
            {
                TextBlock nom = new TextBlock();
                TextBlock valeur = new TextBlock();
                TextBlock rarete = new TextBlock();
                Button s = new Button();
                s.Content = "Supprimer";
                s.Click += Supprimer;

                nom.Text = p.nom;
                nom.SetValue(Grid.RowProperty, rangee);
                nom.SetValue(Grid.ColumnProperty, colonneNom);
                nom.TextAlignment = TextAlignment.Center;

                valeur.Text = p.valeur;
                valeur.SetValue(Grid.RowProperty, rangee);
                valeur.SetValue(Grid.ColumnProperty, colonneValeur);
                valeur.TextAlignment = TextAlignment.Center;

                rarete.Text = p.rarete;
                rarete.SetValue(Grid.RowProperty, rangee);
                rarete.SetValue(Grid.ColumnProperty, colonneRarete);
                rarete.TextAlignment = TextAlignment.Center;

                s.SetValue(Grid.RowProperty, rangee);
                s.SetValue(Grid.ColumnProperty, colonneSupprim);

                grille_poursuivants.Children.Add(nom);
                grille_poursuivants.Children.Add(valeur);
                grille_poursuivants.Children.Add(rarete);
                grille_poursuivants.Children.Add(s);

                rangee++;
            }


            cboPoursuivant.Items.RemoveAt(cboPoursuivant.SelectedIndex);
            cboPoursuivant.SelectedIndex = 0;
        }
        /// <summary>
        /// va afficher les éléments dans la liste d'objet
        /// </summary>
        void AfficherElementGrilleObjet() 
        {
            int rangee = 1;
            int colonneNom = 0;
            int colonneSupprim = 1;

            foreach (ObjetNiveau o in lstObjet)
            {
                TextBlock nom = new TextBlock();
                Button s = new Button();
                s.Content = "Supprimer";
                s.Click += Supprimer;

                nom.Text = o.nom;
                nom.SetValue(Grid.RowProperty, rangee);
                nom.SetValue(Grid.ColumnProperty, colonneNom);
                nom.TextAlignment = TextAlignment.Center;

                s.SetValue(Grid.RowProperty, rangee);
                s.SetValue(Grid.ColumnProperty, colonneSupprim);

                grille_Objet.Children.Add(nom);
                grille_Objet.Children.Add(s);

                rangee++;
            }

            cboObjet.Items.RemoveAt(cboObjet.SelectedIndex);
            cboObjet.SelectedIndex = 0;
         }

         /// <summary>
         /// Va insérer un objet dans liste d'objet
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void btnObjet_Click(object sender, RoutedEventArgs e)
        {
            if (lstObjet.Count <= 7)
            {
                ObjetNiveau objet = new ObjetNiveau(cboObjet.SelectedItem.ToString());
                lstObjet.Add(objet);
                AfficherElementGrilleObjet();

            }
            else
            {
                MessageBox.Show("Vous avez atteint le maximum d'objets possibles");
            }

            if (cboObjet.Items.Count == 0) 
            {
                btnObjet.IsEnabled = false;
            }

        }

        /// <summary>
        /// va ajouter un mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterMode_Click(object sender, RoutedEventArgs e)
        {
            bool validation = true;

            //validation du nom
            if (txtNom.Text == "" || txtNom.Text.Length > 30) 
            {
                MessageBox.Show("Vous devez rentrer un nom à votre mode et il doit contenir moins que 30 caractères");
                validation = false;
           }

           //validation de la liste objet et poursuivant
            if (lstPoursuivant.Count == 0)
            {
                MessageBox.Show("Vous devez avoir au moins un poursuivant pour créer un nouveau mode");
                validation = false;

            }

            //Doit avoir une valeur pour l'objectif
            if (txtValeurObjectif.Text == "" && cboObjectif.SelectedItem.ToString() != "Survivre") 
            {
                MessageBox.Show("Vous devez rentrer une valeur pour votre objectif");
                validation = false;    
            
            }

        //    if (cboObjectif.SelectedItem.ToString() == "Armure" && Convert.ToInt32(txtValeurObjectif.Text) < 0 || Convert.ToInt32(txtValeurObjectif.Text) > 12)
          //  {
            //    MessageBox.Show("Votre nombre d'armure doit être entre 0 et 12");

            //}


            //si tout est validé, le mode sera inséré
            if (validation == true) 
            {
                int id;
                int idNiveau;

                //insertion du Mode de jeu
                string req = "INSERT INTO ModesDeJeu(idUtilisateur,nom)VALUES((SELECT idUtilisateur FROM Utilisateurs WHERE nom ='" + Globale.j1.getNom() + "'),'" + txtNom.Text + "');";
                id = Globale.bdCDS.Insertion(req);

                if (cboObjectif.SelectedItem.ToString() != "Survivre")
                {
                    //validation de l'objectif pour voir s'il est déjâ présent
                    req = "SELECT nom FROM Objectifs WHERE nom = '" + cboObjectif.SelectedItem.ToString() + "' AND valeurObjectif = " + txtValeurObjectif.Text + ";";

                    List<string>[] listeObjectif;
                    int col = 0;


                    listeObjectif = Globale.bdCDS.selection(req, 1, ref col);

                    //si l'objectif existe pas, un nouveau sera crée
                    if (col == 0) 
                    {
                        req = "INSERT INTO Objectifs(nom,valeurObjectif)VALUES('" +  cboObjectif.SelectedItem.ToString() + "', " + txtValeurObjectif.Text + ");" ;
                        Globale.bdCDS.Insertion(req);
                    }

     
                    //insertion du niveau du mode de jeu avec son objectif
                    req = "INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,idObjectif,numNiveau)VALUES(" +
                           id + ",(SELECT idUtilisateur FROM Utilisateurs WHERE nom = '" + Globale.j1.getNom() +
                           "'), (SELECT idObjectif FROM Objectifs WHERE nom = '" + cboObjectif.SelectedItem.ToString() +
                           "' AND valeurObjectif = " + txtValeurObjectif.Text + "),0);";
                }
                else 
                {
                       req = "INSERT INTO Niveaux(idModeDeJeu,idUtilisateur,idObjectif,numNiveau)VALUES(" +
                         id + ",(SELECT idUtilisateur FROM Utilisateurs WHERE nom = '" + Globale.j1.getNom() +
                         "'), (SELECT idObjectif FROM Objectifs WHERE nom ='Survivre'),0);";

                }

              idNiveau = Globale.bdCDS.Insertion(req);

              foreach (PoursuivantNiveau p in lstPoursuivant) 
              {
                    req = "INSERT INTO NiveauxPoursuivants(idNiveau,idPoursuivant,valeur,rarete)VALUES(" + idNiveau + ",(SELECT idPoursuivant FROM Poursuivants WHERE nom ='" + p.nom + "')," + p.valeur + "," + p.rarete + ");"; 
                    Globale.bdCDS.Insertion(req);

              }

              foreach (ObjetNiveau o in lstObjet) 
              {
                  req = "INSERT INTO NiveauxObjets(idNiveau,idObjet,valeur,rarete)VALUES(" + idNiveau + ",(SELECT idObjet FROM Objets WHERE nom ='" + o.nom + "'),0,0);";
                  Globale.bdCDS.Insertion(req);
               }

              MessageBox.Show("Votre nouveau mode a bien été ajouté");
            }
        }

        private void ActionObjectif(object sender, EventArgs e)
        {
            if (cboObjectif.SelectedItem.ToString() == "Survivre")
            {
                txtValeurObjectif.Clear();
                txtValeurObjectif.IsEnabled = false;

            }
            else 
            {
                txtValeurObjectif.IsEnabled = true;
            }
        }

    }
}
