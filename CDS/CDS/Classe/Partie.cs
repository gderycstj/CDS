using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CDS
{
    public class Partie
    {
        GrilleDeJeu grille { get;set;}
        int score { get;set;}
        Vie vie { get; set; }
        Objectif objectif { get;set;}
        int qtyObjetsMax;
        public List<Poursuivant> PoursuivantDispoPourLaPartie { get; set; }
        public List<Poursuivant> PoursuivantDansLaPartie{ get; set; }
        List<Objet> objetDansLaPartie;

        List<Entite> listeEntite;

        public Partie()
        {   
            score = 0;
            PoursuivantDansLaPartie = new List<Poursuivant>();
            PoursuivantDispoPourLaPartie = new List<Poursuivant>();
            objetDansLaPartie = new List<Objet>();
        }

        /*public Partie(Vie viedepart, Objectif objParti,int maxobjets, List<Objet> objetDepart)
        {
            vie=viedepart;
            objectif=objParti;
            qtyObjetsMax=maxobjets;
            objetDepart.CopyTo(objets);
        }*/

        /// <summary>
        /// initialisation des param de base de la partie
        /// (transfèr de donné BD dans des classes)
        /// Est lancer dès le départ de jouer
        /// </summary>
        /// <returns>Si tout fonctione et que l'on peu faire une partie</returns>
        public bool initialiser()
        {
            //Requête BD
            //-------------------------------------------------------------------------------------------------------------
            chargerEnnemi(0);
            débutDePartieGenPoursuivant();
            //-------------------------------------------------------------------------------------------------------------

            //Traitement Requête (Création d'objet)

            //-------------------------------------------------------------------------------------------------------------
            return true;
        }
        /// <summary>
        /// Va charger tous les poursuivants dans la liste
        /// </summary>
        /// <param name="numNiveau">niveau présentement 0 pour normal</param>
		public void chargerEnnemi(int numNiveau)
        {

            int nbRange = 0;

            //requête qui sélectionne toutes les infos d'un poursuivant et son apparence
            string req = "SELECT nom,valeur,rareté,valeurPoint,listeCMD,image FROM Niveaux as n " +
                         "INNER JOIN NiveauxPoursuivants as np ON np.idNiveau = n.idNiveau " + 
                         "INNER JOIN Poursuivants as p ON np.idPoursuivant = p.idPoursuivant "+
                         "INNER JOIN Apparences a ON a.idApparence = p.idApparence " +
                         "WHERE n.idModeDeJeu = " +
                         "(SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = '" + Globale.mode + "' AND numNiveau = " + numNiveau + ");";

            List<string>[] unNiveau;

            unNiveau = Globale.bdCDS.selection(req,6,ref nbRange);

            //chargement de la liste de poursuivant
            for(int i = 0;i<unNiveau.Length;i++)
            {
                PoursuivantDispoPourLaPartie.Add(new Poursuivant(Convert.ToInt32(unNiveau[i][1]), Convert.ToInt32(unNiveau[i][2]), unNiveau[i][4], unNiveau[i][5]));
            }
        
         }

         /// <summary>
         /// Va charger tous les objets pour un niveau
         /// </summary>
         /// <param name="numNiveau"></param>
        public void chargerObjet(int numNiveau) 
        {
        int nbRange = 0;

        //requête qui sélectionne toutes les infos d'un objet et son apparence
        string req =    "SELECT o.nom,valeur,rarete,listeCMD,image FROM Niveaux as n " +
                        "INNER JOIN NiveauxObjets as no ON no.idNiveau = n.idNiveau " +
                        "INNER JOIN Objets as o ON no.idObjet = o.idObjet " +
                        "INNER JOIN ObjetsEffets as nf ON nf.idObjet = o.idObjet " +
                        "INNER JOIN Effets as e ON e.idEffet = nf.idEffet " +
                        "INNER JOIN Apparences a ON a.idApparence = o.idApparence " +
                        "WHERE n.idModeDeJeu = " +
                        "(SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = '" + Globale.mode + "' AND numNiveau = " + numNiveau + ");";

                          List<string>[] unNiveau = Globale.bdCDS.selection(req,5,ref nbRange);
         }


        private void action()
        {
            foreach(Entite E in listeEntite)
            {
                E.action();
            }
        }

        private bool finDeTour()
        {
            foreach (Entite E in listeEntite)
            {
                E.finDetour();
            }

            bool validation = true;
            if(!grille.finDeTour())
            {
                validation = false;
            }
            if(!vie.finDeTour())
            {
                validation = false;
            }
            if(objectif.finDeTour())
            {
                validation = false;
            }

            if(!validation)
            {return false;}

            else { return true;}
        }

        public void validationObjectifPartieNormal()
        {
            if(!finDeTour())
            {
                //Appel de l'écran de fin de partie
            }

        }

        public int GetScore(){
            int nouvScore;
            nouvScore = score;
            return nouvScore;
        }

        public void débutDePartieGenPoursuivant()
        {
            int nbPoursuivant;
            int nbPoursuivantDispoDansLaListe;
            int PoursuivantChoisi;

            Random iPoursuivant = new Random();
            nbPoursuivant = iPoursuivant.Next(1,4);
            nbPoursuivantDispoDansLaListe = PoursuivantDispoPourLaPartie.Count();

            for(int i = 0;i<nbPoursuivant+1;i++)
            {
                PoursuivantChoisi = iPoursuivant.Next(1, nbPoursuivantDispoDansLaListe+1);
                PoursuivantChoisi = PoursuivantChoisi-1;

                PoursuivantDansLaPartie.Add(new Poursuivant(PoursuivantDispoPourLaPartie[PoursuivantChoisi].getValeur(),PoursuivantDispoPourLaPartie[PoursuivantChoisi].getRarete(), PoursuivantDispoPourLaPartie[PoursuivantChoisi].getListeCMD(), PoursuivantDispoPourLaPartie[PoursuivantChoisi].getUrlImage()));
                if(i != nbPoursuivant)
                {
                    System.Threading.Thread.Sleep(150);
                }
            }
        }

        public void generationPoursuivantTour(int tour)
        {

            foreach (Poursuivant p in PoursuivantDispoPourLaPartie)
            {
                int rarete = p.getRarete();
                int valeur = p.getValeur();
                int nbPoursuivant = 0;

                foreach( Poursuivant pi in PoursuivantDansLaPartie)
                {
                    //Si on tente d'ajouter un carrer, on regarde si les 2 couleurs de carré ne dépasse pas la valeur maximale
                    if (p.getUrlImage() == "/image/carreVert.png" || p.getUrlImage() == "/image/carreBleu.png")
                    {
                        if(pi.getUrlImage() == "/image/carreVert.png" || pi.getUrlImage() == "/image/carreBleu.png")
                        {
                            nbPoursuivant += 1;
                        }
                    }
                    //Si on tente d'ajouter un losange, on regarde si les 2 couleurs de losange ne dépasse pas la valeur maximale
                    if (p.getUrlImage() == "/image/LosangeJaune.png" || p.getUrlImage() == "/image/LosangeMauve.png")
                    {
                        if (pi.getUrlImage() == "/image/LosangeJaune.png" || pi.getUrlImage() == "/image/LosangeMauve.png")
                        {
                            nbPoursuivant += 1;
                        }
                    }
                    //Tout les autres
                    if (p.getUrlImage() != "/image/LosangeJaune.png" && p.getUrlImage() != "/image/LosangeMauve.png" && p.getUrlImage() == "/image/carreVert.png" && p.getUrlImage() == "/image/carreBleu.png")
                    {
                        if (p.getUrlImage() == pi.getUrlImage())
                        {
                            nbPoursuivant += 1;
                        }
                    }
                }

                if (valeur != nbPoursuivant)
                {
                    //Rareté Spawn par tour
                    if (tour % rarete == 0)
                    {
                        PoursuivantDansLaPartie.Add(new Poursuivant(p.getValeur(), p.getRarete(), p.getListeCMD(), p.getUrlImage()));
                        System.Threading.Thread.Sleep(150);
                    }
                }
            }
        }
    }
}
