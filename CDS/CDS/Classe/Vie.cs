using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    class Vie
    {
        int nbVieActu { get;set;}
        int nbVieMax { get;set;}

        int nbArmure { get;set;}

        int toursImmunite { get;set;}


        Vie()
        {
            nbVieMax=3;
            nbVieActu=nbVieMax;
            nbArmure=0;
            toursImmunite=1;
        }

        Vie(int vieDepart, int vieMax, int armureDepart, int toursImmuniterAuDepart)
        {
            nbVieActu=vieDepart;
            nbVieMax=vieMax;
            nbArmure=armureDepart;
            toursImmunite=toursImmuniterAuDepart;
        }

        //retourne si oui ou non et a été blessé
        bool degat()
        {
            if(toursImmunite<1)
            {
                if(nbArmure>0)
                {
                    nbArmure-=1;
                }
                else
                {
                    nbVieActu-=1;
                }
                return true;
            }
            else
            return false;

        }

        //retourne si oui ou non le joueur a été soigné
        bool soin(int puissance)
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
    }
}
