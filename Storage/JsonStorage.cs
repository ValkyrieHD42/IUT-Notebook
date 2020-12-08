using Logic;
using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Storage
{
    /// <summary>
    /// Type de IStorage pour sauvegarder les données sous forme de json
    /// </summary>
    public class JsonStorage : Logic.IStorage
    {

        /// <summary>
        /// Charge un notebook à partir d'un fichier .json
        /// </summary>
        /// <returns>Renvoi le notebook lu ou créé si il n'existe pas</returns>
        public NoteBook Load()
        {
            NoteBook n;
            try
            {
                string chemin = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "data.json";
                using (FileStream flux = new FileStream(chemin, FileMode.Open))
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Logic.NoteBook));
                    n = ser.ReadObject(flux) as Logic.NoteBook;
                }
            }
            catch
            {
                n = new Logic.NoteBook();
            }
            return n;
        }

        /// <summary>
        /// Enregistre les données dans un .json
        /// </summary>
        /// <param name="n">Prends le notebook actuel</param>
        public void Save(NoteBook n)
        {
            string chemin = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "data.json";
            using (FileStream flux = new FileStream(chemin, FileMode.Create))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Logic.NoteBook));
                ser.WriteObject(flux, n);
            }
        }
    }
}
