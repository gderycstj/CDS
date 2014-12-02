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
    /// Logique d'interaction pour ecranCreationPoursuivant.xaml
    /// </summary>
    public partial class ecranCreationPoursuivant : UserControl
    {
        string[] listeCMD={""};

        int qtyTemps=1; // on commence avec un seul tour
        int tempsActif=1; //on commence en modifiant le tour 1 (selui que l'on commence avec)
        int nbEvenement = 0;

        public ecranCreationPoursuivant()
        {
            InitializeComponent();
            activerBtnBack();
            //Liste d'apparence
            String req2 = "SELECT image FROM Apparences WHERE image LIKE '/image/Poursuivants/%'";
            List<string>[] listeApparence;
            int col2 = 0;

            String nomTemp1;

            listeApparence = Globale.bdCDS.selection(req2, 1, ref col2);

            for (int i = 0; i < listeApparence.Length; i++)
            {
                nomTemp1 = listeApparence[i][0].Substring(20);
                nomTemp1 = Retourner(nomTemp1);
                nomTemp1 = nomTemp1.Substring(4);
                nomTemp1 = Retourner(nomTemp1);

                cboApparence.Items.Add(nomTemp1);
            }

            cboApparence.SelectedIndex = 0;
            imagePoursuivant.Source = new BitmapImage(new Uri("pack://application:,,,/image/Poursuivants/" + cboApparence.SelectedItem.ToString() + ".png", UriKind.RelativeOrAbsolute));

        }





        
        private void txtUpdate()
        {
            txtCMD.Text = "";

            foreach( string s in listeCMD)
            {
                txtCMD.Text += s + "/";
            }
            //on enlève le dernier / qui est de trop
            txtCMD.Text= txtCMD.Text.Remove(txtCMD.Text.Length-1);

        }




        private void btnHaut_Click(object sender, RoutedEventArgs e)
        {
            listeCMD[tempsActif - 1] += "Mh";
            nbEvenement++;
            activerBtnBack();
            txtUpdate();
            
        }

        private void btnDroit_Click(object sender, RoutedEventArgs e)
        {
            listeCMD[tempsActif-1] += "Md";
            nbEvenement++;
            activerBtnBack();
            txtUpdate();
        }

        private void btnGauche_Click(object sender, RoutedEventArgs e)
        {
            listeCMD[tempsActif-1] += "Mg";
            nbEvenement++;
            activerBtnBack();
            txtUpdate();
        }

        private void btnBas_Click(object sender, RoutedEventArgs e)
        {
            listeCMD[tempsActif-1] += "Mb";
            nbEvenement++;
            txtUpdate();
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            listeCMD[tempsActif-1] += "C";
            txtUpdate();
        }

        private void btnTourAjout_Click(object sender, RoutedEventArgs e)
        {
            int cmptr=0;
            string[] sTemp = listeCMD;

            listeCMD = new string[qtyTemps+1];

            foreach(string S in sTemp)
            {
                listeCMD[cmptr]= S;
                cmptr++;
            }

            qtyTemps++;
            txtTourMax.Text = qtyTemps.ToString() + "Tour";
            //on ajoute le s s'il y a plusieur tours
            if (qtyTemps > 1)
                txtTourMax.Text = txtTourMax.Text + "s";

            tempsActif= qtyTemps;
            txtTourselectionne.Text = tempsActif.ToString();
            txtUpdate();
        }

        private void btnTourRetrait_Click(object sender, RoutedEventArgs e)
        {
            if(qtyTemps>1)
            {
                int cmptr = 0;
                string[] sTemp = listeCMD;

                //
                listeCMD = new string[qtyTemps-1];

                foreach (string S in sTemp)
                {
                    if(cmptr<qtyTemps-1) { listeCMD[cmptr] = S; }


                    cmptr++;
                }

                //"delete" du temps de trop
                // moins 1 car le temps 1 est [0], 2 est [1], etc.

                qtyTemps--;
                txtTourMax.Text= qtyTemps.ToString() + "Tour";
                //on ajoute le s s'il y a plusieur tours
                if(qtyTemps>1)
                    txtTourMax.Text=txtTourMax.Text +"s";

                tempsActif= qtyTemps;
                txtTourselectionne.Text = tempsActif.ToString();
                txtUpdate();
            }
        }

        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            int qtyADel= 0;
            char[] lettre = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};

            // Les commande commence TOUTES par une lettre majuscule et le reste est des minuscules et des chiffres
            //MAIS il faut faire attention au if et random et ne pas delete leurs {}

            //on test si la dernière commende n'est pas un If ou Random
            if( listeCMD[tempsActif-1]!="" && (listeCMD[tempsActif-1][listeCMD[tempsActif-1].Length-1]!='}'))
            {

                        qtyADel = listeCMD[tempsActif-1].Length - listeCMD[tempsActif-1].LastIndexOfAny(lettre);


            }
            else
            {
                //on cherche le caractère qui représente le début du If ou Random
            }

            //s'il avait rien
            if(qtyADel != -1)
            {
                listeCMD[tempsActif-1]= listeCMD[tempsActif-1].Remove(listeCMD[tempsActif-1].Length - qtyADel, qtyADel);
            }

            txtUpdate();
        }

        private void btnTourSuivant_Click(object sender, RoutedEventArgs e)
        {
            if(tempsActif<qtyTemps)
            {
                tempsActif++;
                txtTourselectionne.Text= tempsActif.ToString();
            }
        }

        private void btnTourPrecedent_Click(object sender, RoutedEventArgs e)
        {
            if (tempsActif > 1)
            {
                tempsActif--;
                txtTourselectionne.Text = tempsActif.ToString();
            }
        }

        private void cboApparence_DropDownClosed(object sender, EventArgs e)
        {
            if (cboApparence.SelectedItem != null)
            {
                imagePoursuivant.Source = new BitmapImage(new Uri("pack://application:,,,/image/Poursuivants/" + cboApparence.SelectedItem.ToString() + ".png", UriKind.RelativeOrAbsolute));
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
            int nbRangee = 0;
            bool validation = true;

            string req = "SELECT nom FROM Poursuivants;";
            List<string>[] listePoursuivant = Globale.bdCDS.selection(req, 1, ref nbRangee);
            for (int i = 0; i < listePoursuivant.Length; i++)
            {
                if (listePoursuivant[i][0].ToString() == txtNomPoursuivant.Text)
                {
                    validation = false;
                }
            }
            if(validation == true)
            {
              string reqPoursuivant;
              StringBuilder sBldr = new StringBuilder();
              
              for(int i=1;i<=qtyTemps ; i++)
              {
                  sBldr.Append(listeCMD[i-1]);
              }

             reqPoursuivant = "INSERT INTO Poursuivants(nom,idUtilisateur,idApparence,valeurPoint,listeCMD)"+
             "VALUES('"+txtNomPoursuivant.Text+"',(SELECT idUtilisateur FROM Utilisateurs WHERE nom='" + Globale.j1.getNom() + "')"+
             ",(SELECT idApparence FROM apparences WHERE image = '/image/Poursuivants/" + cboApparence.SelectedItem.ToString() + ".png')"+
             ","+txtPoint.Text+",'" + sBldr.ToString() + "');";
              Globale.bdCDS.Insertion(reqPoursuivant);

              MessageBox.Show("Votre nouveau poursuivant a bien été ajouté");
           }
        }

        public void activerBtnBack()
        { 
            if(nbEvenement > 2)
            {
                btnBas.IsEnabled = true;
            }
            else
            {
                btnBas.IsEnabled = false;
            }
        }

    }
}
