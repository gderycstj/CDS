using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CDS
{
    public class Objet:Entite
    {
        public int valeur { get; set; }
        public int rareté { get; set; }
        public Effet unEffet {get;set;}

		/// <summary>
        /// Constructeur d'un objet
        /// </summary>
        /// <param name="listeE">Liste d'effet qu'un objet peut avoir</param>
        /// <param name="listC">liste de commande de l'objet</param>
        /// <param name="url">url de l'image</param>
        /// <param name="Pvaleur">Puissance de l'objet</param>
        /// <param name="Prareté">Rareté de l'objet(selon sa puissance)</param>
        public Objet(Effet E,int Pvaleur,int Prareté,string listC,string url):base(listC,url)
        {
            unEffet = E;
            valeur = Pvaleur;
            rareté = Prareté;

            //Position Random
            positionEntite = new Position();
            Random randomPosition = new Random();
            positionEntite.posX = randomPosition.Next(1,10);
            positionEntite.posY = randomPosition.Next(1,10);

        }
		
        //lire la liste CMD et agire
        public override bool action()
        {
            // pas d'action
            return true;
        }
        //Vérification et action effectuer à chaque fin de tour
        public override bool finDetour()
        {
            age++;
            return true;
        }
        //Get nécéssaire
        public string getUrlImage()
        {
            return urlImage;
        }
        public string getListeCMD()
        {
            return listeCMD;
        }

        public Image obtenirImage()
        {
            Image img = new Image();
            BitmapImage bImg = new BitmapImage();

            bImg.BeginInit();
            bImg.UriSource = new Uri(urlImage, UriKind.RelativeOrAbsolute);
            bImg.DecodePixelWidth = 60;
            bImg.EndInit();

            img.Source = bImg;

            return img;

        }

        /// <summary>
        /// Verifier si sur la cas du jouer, sur un effet.
        /// </summary>
        /// <returns></returns>
        public override bool verification()
        {
            if (positionEntite.posX == Globale.j1.positionJoueur.posX && positionEntite.posY == Globale.j1.positionJoueur.posY)
            {
                return true;
            }
            return false;
        }
      
    }
}
