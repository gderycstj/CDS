using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace CDS
{
    /// <summary>
    /// Classe qui va permettre d'accéder à la bd(insertion,modif,supression)
    /// </summary>
    public class BdService
    {
        private MySqlConnection connexion;

        public BdService()
        {
            try
            {
                string sConnection = ConfigurationManager.ConnectionStrings["MySqlConnexion"].ConnectionString;
                connexion = new MySqlConnection(sConnection);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur de la string de connexion");
            }

        }

        /// <summary>
        /// Permet l'ouverture de la bd
        /// </summary>
        /// <returns></returns>
        private bool Ouvrir()
        {
            try
            {
                connexion.Open();
                return true;
            }
            catch 
            {
                 MessageBox.Show("Erreur d'ouverture de connexion");
                return false;
            }
        }
        /// <summary>
        /// Permet de fermer la bd
        /// </summary>
        /// <returns></returns>
        private bool Fermer()
        {
            try
            {
                connexion.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("Erreur de fermeture de connexion");
                return false;
            }
        }
        /// <summary>
        /// Insertion d'un enregistrement dans la bd
        /// </summary>
        /// <param name="ins">Requête d'insertion de bd</param>
        public int Insertion(string ins)
        {
            try
            {
                if(Ouvrir())
                {
                    MySqlCommand cmd = new MySqlCommand(ins,connexion);
                    cmd.ExecuteNonQuery();
                    Fermer();
                    return (int)cmd.LastInsertedId;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Votre identifiant existe déjà, veuillez en choisir un nouveau");
            }
            return 0;
        }

        /// <summary>
        /// Supression d'un enregistrement dans la bd
        /// </summary>
        /// <param name="ins">Requête de supression de la bd</param>
        public void supression(string ins)
        {
            try
            {
                if (Ouvrir())
                {
                    MySqlCommand cmd = new MySqlCommand(ins, connexion);
                    cmd.ExecuteNonQuery();
                    Fermer();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur lors de la supression");
            }
        }

        /// <summary>
        /// modification d'un enregistrement dans la bd
        /// </summary>
        /// <param name="ins">Requête de modification de la bd</param>
        public void modification(string ins)
        {
            try
            {
                if (Ouvrir())
                {
                    MySqlCommand cmd = new MySqlCommand(ins, connexion);
                    cmd.ExecuteNonQuery();
                    Fermer();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur lors de la modification");
            }
        }

        /// <summary>
        /// Permet la sélection de champs dans la bd
        /// </summary>
        /// <param name="sel">Requête de sélection dans la bd</param>
        /// <param name="nbChamp">Nombre de champs que la requête va retourner</param>
        /// <param name="nbRange">Nombre de rangé que la requête va retourner</param>
        /// <returns>une liste qui contient le résultat de la requête</returns>
        public List<string>[] selection(string sel, int nbChamp, ref int nbRange)
        {
            List<string> infoBrute = new List<string>();
            nbRange = 0;

            try
            {
                if(Ouvrir())
                {
                    MySqlCommand cmd = new MySqlCommand(sel,connexion);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while(dataReader.Read())
                    {
                        for (int i = 0; i < nbChamp; i++)
                        {
                            infoBrute.Add(dataReader[i].ToString());
                        }

                        nbRange++;
                    }

                    dataReader.Close();
                    Fermer();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur dans le select");
            }

            List<string>[] listeRetour;

            if(nbRange == 0)
            {
                listeRetour = new List<string>[1];
                listeRetour[0] = new List<string>();
                listeRetour[0].Add("");
            }
            else
            {
                listeRetour = new List<string>[nbRange];

                for (int i = 0; i < nbRange; i++)
                {
                    listeRetour[i] = new List<string>();

                    for (int x = 0; x < nbChamp; x++)
                    {
                        int indice = x + (i * nbChamp);
                        listeRetour[i].Add(infoBrute[indice]);
                    }
                }
            }
            return listeRetour;
        }

    }
}
