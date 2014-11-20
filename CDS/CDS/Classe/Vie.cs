using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    public class Vie
    {
        public int nbVieActu { get;set;}
        public int nbVieMax { get;set;}
        public int nbArmureMax { get;set;}
        public int nbArmure { get;set;}

        public int toursImmunite { get;set;}


        public Vie()
        {
            nbVieMax=3;
            nbVieActu=nbVieMax;
            nbArmureMax = 12;
            nbArmure=0;
            toursImmunite=0;
        }

        public Vie(int vieDepart, int vieMax, int armureDepart, int toursImmuniterAuDepart,int nbArmureMaxa)
        {
            nbVieActu=vieDepart;
            nbVieMax=vieMax;
            nbArmure=armureDepart;
            toursImmunite=toursImmuniterAuDepart;
            nbArmureMax = nbArmureMaxa;
        }

        //retourne si oui ou non et a été blessé
        public void degat()
        {
            if (toursImmunite < 1)
            {
                if (nbArmure > 0)
                {
                    nbArmure -= 1;
                    toursImmunite +=1;
                }
                else
                {
                    nbVieActu -= 1;
                    toursImmunite +=1;
                }
                Globale.j1.toucher= true;
             }
            else
            {
                
            }

        }

        //retourne si oui ou non le joueur a été soigné
        public bool soin(int puissance)
        {
            //Si le joueur n'est pas plein de vie
            if(nbVieActu<nbVieMax)
            {
                nbVieActu+=puissance;

                //Si le joueur a été trop soigné
                if(nbVieActu>nbVieMax)
                nbVieActu=nbVieMax;

                //le joueur a été soigné
                return true;
            }
            //le joueur n'a pas été soigné
            return false;
        }


        //fonction utiliser à chaque fin de tours
        //retourne si le joueur est en vie
        public bool finDeTour()
        {
            if(nbVieActu<=0)           
                return false;


            if(toursImmunite>0)
                toursImmunite-=1;

            return true;
        }

        public void setVie()
        {
            nbVieMax=3;
            nbVieActu=nbVieMax;
            nbArmure=0;
            toursImmunite=0;
        }
    }
}
