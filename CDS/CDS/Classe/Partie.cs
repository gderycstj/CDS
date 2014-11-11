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
        public int score { get;set;}
        public Objectif objectif { get;set;}
        public List<Poursuivant> PoursuivantDispoPourLaPartie { get; set; }
        public List<Poursuivant> PoursuivantDansLaPartie{ get; set; }
        public List<Objet> objetDansLaPartie{get; set;}
        public List<Objet> objetDispoPourLaPartie { get;set;}
        public Objet obj1{get;set;}
        public Objet obj2{get;set;}
        public int numNiveaux {get;set;}
        public Partie()
        {   
            score = 0;
            PoursuivantDansLaPartie = new List<Poursuivant>();
            Globale.vie.setVie();
            PoursuivantDispoPourLaPartie = new List<Poursuivant>();
            objetDansLaPartie = new List<Objet>();
            objetDispoPourLaPartie = new List<Objet>();
            Globale.j1.pathImage = "/image/bonhommeMod.png";
            numNiveaux = 0;
            objectif = new Objectif("Survie",3);
        }
        
  
        public void setPartie(string nObjectif,int ScoreObjectif,int numNiveau)
        {
            numNiveaux = numNiveau;
            objectif = new Objectif(nObjectif,ScoreObjectif);
        }
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
            chargerEnnemi(numNiveaux);
            chargerObjet(numNiveaux);
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
                PoursuivantDispoPourLaPartie.Add(new Poursuivant(Convert.ToInt32(unNiveau[i][1]), Convert.ToInt32(unNiveau[i][2]), unNiveau[i][4], unNiveau[i][5],Convert.ToInt32(unNiveau[i][3])));
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
            string req = "SELECT o.nom,valeur,rarete,listeCMD,image FROM Niveaux as n " +
                            "INNER JOIN NiveauxObjets as no ON no.idNiveau = n.idNiveau " +
                            "INNER JOIN Objets as o ON no.idObjet = o.idObjet " +
                            "INNER JOIN ObjetsEffets as nf ON nf.idObjet = o.idObjet " +
                            "INNER JOIN Effets as e ON e.idEffet = nf.idEffet " +
                            "INNER JOIN Apparences a ON a.idApparence = o.idApparence " +
                            "WHERE n.idModeDeJeu = " +
                            "(SELECT idModeDeJeu FROM ModesDeJeu WHERE nom = '" + Globale.mode + "' AND numNiveau = " + numNiveau + ");";

            List<string>[] unNiveau = Globale.bdCDS.selection(req, 5, ref nbRange);

            for (int i = 0; i < unNiveau.Length; i++)
            {
                Effet e = new Effet(unNiveau[i][3], unNiveau[i][4]);

                objetDispoPourLaPartie.Add(new Objet(e, Convert.ToInt32(unNiveau[i][1]), Convert.ToInt32(unNiveau[i][2]), unNiveau[i][3], unNiveau[i][4]));

            }
         }

        public void finDeTour()
        {
            foreach (Objet o in objetDansLaPartie)
            {
                o.age += 1;
            }

            foreach(Poursuivant p in PoursuivantDansLaPartie)
            {
                p.age += 1;
            }
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

                PoursuivantDansLaPartie.Add(new Poursuivant(PoursuivantDispoPourLaPartie[PoursuivantChoisi].valeur,PoursuivantDispoPourLaPartie[PoursuivantChoisi].rareté, PoursuivantDispoPourLaPartie[PoursuivantChoisi].getListeCMD(), PoursuivantDispoPourLaPartie[PoursuivantChoisi].getUrlImage(),PoursuivantDispoPourLaPartie[PoursuivantChoisi].valeurScore));
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
                int rarete = p.rareté;
                int valeur = p.valeur;
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
                        PoursuivantDansLaPartie.Add(new Poursuivant(p.valeur, p.rareté, p.getListeCMD(), p.getUrlImage(),p.valeurScore));
                        System.Threading.Thread.Sleep(150);
                    }
                }
            }
        }

        public void validationPoursuivant(bool validationInBoundary)
        {
            for (int i = PoursuivantDansLaPartie.Count - 1; i >= 0; i--)
            {
                bool validation = false;
                if (PoursuivantDansLaPartie[i].verification())
                {
                    //Enlever une vie au personnage
                    Globale.vie.degat();
                    //Supprimer le poursuivant de la liste
                    PoursuivantDansLaPartie.RemoveAt(i);
                    validation = true;
                }
                if(validationInBoundary == true)
                {
                    if (validation == false && PoursuivantDansLaPartie[i].inBoundary())
                    {
                        //Prendre le score
                        score += PoursuivantDansLaPartie[i].valeurScore;
                        //Supprimer le poursuivant de la liste
                        PoursuivantDansLaPartie.RemoveAt(i);
                    }
                }
            }
        }

        public void validationObjet()
        {
            bool validation = true;

            for (int i = objetDansLaPartie.Count - 1; i >= 0; i--)
            {
                validation = true;
                if(objetDansLaPartie[i].age > 15)
                {
                    objetDansLaPartie.RemoveAt(i);
                    validation = false;
                }
                if (validation!= false && objetDansLaPartie[i].verification())
                {
                    //Enlever une vie au personnage
                    if (obj1 == null)
                    {
                        //va rentrer l'objet dans la variable dans bouton
                        obj1 = objetDansLaPartie[i];
                    }
                    else if (obj2 == null) 
                    {
                        obj2 = objetDansLaPartie[i];
                    }
                    else 
                    {
                        objetDansLaPartie[i].unEffet.action();
                    }
                    objetDansLaPartie.RemoveAt(i);
                }
            }
        }

        public void GenerationObjet(int tour)
        {
            int nbObjetDispo = objetDispoPourLaPartie.Count;
            int objetChoisi;
            string listeCMDEffet;
            string urlImageEffet;

            Random rnd = new Random();
            if(tour%7 == 0)
            {
               objetChoisi = rnd.Next(1,nbObjetDispo+1);
               objetChoisi -= 1;
               listeCMDEffet = objetDispoPourLaPartie[objetChoisi].unEffet.getListeCMD();
               urlImageEffet = objetDispoPourLaPartie[objetChoisi].unEffet.getUrlImage();
               Effet e = new Effet(listeCMDEffet,urlImageEffet);
               objetDansLaPartie.Add(new Objet(e,
               objetDispoPourLaPartie[objetChoisi].valeur,
               objetDispoPourLaPartie[objetChoisi].rareté,
               objetDispoPourLaPartie[objetChoisi].getListeCMD(),
               objetDispoPourLaPartie[objetChoisi].getUrlImage()));
            }
        }


    }
}
