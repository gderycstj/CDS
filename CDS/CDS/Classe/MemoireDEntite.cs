using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS
{
    class MemoireDEntite
    {   
        public class MObjet
        {
            Objet objet;
            int valeur{get;set;}
            int rareté{get;set;}
        }

        public class MPoursuivant
        {
            Poursuivant poursuivant;
            int valeur { get;set;}
            int rareté { get;set;}
        }

        List<Effet> MEffet { get;set;}
        List<MObjet> objetDansLaPartie { get;set;}
        List<MPoursuivant> PoursuivantDansLaPartie { get;set;}


    }
}
