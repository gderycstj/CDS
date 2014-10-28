using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CDS
{
    public class Joueur
    {
        string nom {get;set;}
        private int idJoueur {get;set;}
        public string pathImage {get;set;}
        public bool estConnecte;
        public Position positionJoueur{get;set;}

        public Joueur()
        {
            nom="visiteur";
            idJoueur=-1;
            pathImage = "/image/perso.png";
            estConnecte = false;
            positionJoueur = new Position(5,5);
        }

        public Joueur(string nomJ, int id, string pathIm)
        {
            nom=nomJ;
            idJoueur=id;
            pathImage=pathIm;
            estConnecte = true;
            positionJoueur = new Position(6, 6);
        }

        public string getNom()
        {
            return nom;
        }
        /// <summary>
        /// fonction qui va permettre d'obtenir une image du joueur
        /// </summary>
        /// <returns>va retourner l'image du joueur</returns>
        public Image obtenirImage() 
        {
            Image img = new Image();
            BitmapImage bImg = new BitmapImage();

            bImg.BeginInit();
            bImg.UriSource = new Uri(pathImage, UriKind.RelativeOrAbsolute);
            bImg.DecodePixelWidth = 60;
            bImg.EndInit();

            img.Source = bImg;

            return img;
        
        }
        /// <summary>
        /// Va mettre les infos du joueur connecté à la place de visiteur
        /// </summary>
        /// <param name="n">nom du joueur</param>
        /// <param name="id">id du joueur</param>
        /// <param name="pathIm">emplacement de l'image du joeur</param>
        /// <param name="connexion">vrai si est connecté</param>
        public void setJoueur(string n, int id, string pathIm,bool connexion)
        {
            nom = n;
            idJoueur = id;
            pathImage = pathIm;
            estConnecte = connexion;
        
        }

    }
}
