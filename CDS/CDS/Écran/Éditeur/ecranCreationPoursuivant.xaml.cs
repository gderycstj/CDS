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


        public ecranCreationPoursuivant()
        {
            InitializeComponent();


        }





        /// <summary>
        /// Ajoute un block de text a la liste !!!!WIP!!!!!
        /// </summary>
        /// <param name="text">le text à ajouter</param>
        /// <param name="signeDePlus">si on veut ajouter le + après</param>
        private void txtAdd(string text, bool signeDePlus)
        {
            txtCMD.Text += text;

            if(signeDePlus)
            {
                txtCMD.Text+= "+";
            }
        }

        /// <summary>
        /// efface la dernière comande ajouter !!!!WIP!!!!!
        /// </summary>
        /// <param name="deleteUnSeul"> true pour un backspace/ false pour delete un temps complèt</param>
        /// <returns>si effacer est un succès</returns>
        private bool txtRmv(bool deleteUnSeul)
        {

            return true;
        }



        private void btnHaut_Click(object sender, RoutedEventArgs e)
        {
            listeCMD[tempsActif] += "Mh";
            txtAdd("Haut", true);
            
        }

        private void btnDroit_Click(object sender, RoutedEventArgs e)
        {
            listeCMD[tempsActif] += "Md";
            txtAdd("Droite",true);
        }

        private void btnGauche_Click(object sender, RoutedEventArgs e)
        {
            listeCMD[tempsActif] += "Mg";
            txtAdd("Gauche", true);
        }

        private void btnBas_Click(object sender, RoutedEventArgs e)
        {
            listeCMD[tempsActif] += "Mb";
            txtAdd("Bas", true);
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            listeCMD[tempsActif] += "C";
            txtAdd("Attack", true);
        }

        private void btnTourAjout_Click(object sender, RoutedEventArgs e)
        {
            qtyTemps++;
            txtAdd("/", false);
        }

        private void btnTourRetrait_Click(object sender, RoutedEventArgs e)
        {
            if(qtyTemps>1)
            {
                //!__! delete du temps de trop

                qtyTemps--;
                txtRmv(false);
            }
        }

        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            int qtyADel= 0;
            int iMemoire;
            char lettre = 'A';

            // Les commande commence TOUTES par une lettre majuscule et le reste est des minuscules et des chiffres
            //MAIS il faut faire attention au if et random et ne pas delete leurs {}

            //on test si la dernière commende n'est pas un If ou Random
            if(listeCMD[tempsActif][listeCMD.Length-1]!='}')
            {

                    while(lettre!='Z'+1)//on veut tester toutes les lettres maj (même Z donc on arrête après (+1))
                    {
                        iMemoire = listeCMD[tempsActif].Length - listeCMD[tempsActif].LastIndexOf(lettre);

                        if (iMemoire != 0 && iMemoire < qtyADel)
                        { 
                            qtyADel=iMemoire;
                        }

                        lettre++;//on avance dans les lettres EX: A+1 = B 
                    }
            }
            else
            {

            }

            if(qtyADel!=null)
            {
                listeCMD[tempsActif].Remove(listeCMD.Length - qtyADel, qtyADel);
            }

            txtRmv(true);
        }


    }
}
