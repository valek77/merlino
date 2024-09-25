using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merlino
{
    public class Preferences
    {
        public string OllamaUrl { get; set; }
        public string BpgUrl { get; set; }
        public string BpgUsername { get; set; }
        public string BpgPassword { get; set; }



        public static void SavePreferences(Preferences preferences)
        {
            // Converti l'oggetto preferences in JSON
            string json = JsonConvert.SerializeObject(preferences, Formatting.Indented);

            // Ottieni un riferimento all'archiviazione isolata per l'utente corrente
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly();

            // Scrivi il JSON su un file in Isolated Storage
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("preferences.json", FileMode.Create, isoStore))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(json);
            }
        }

        public static Preferences LoadPreferences()
        {
            // Ottieni un riferimento all'archiviazione isolata
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly();

            Preferences preferences = new Preferences();

            if (isoStore.FileExists("preferences.json"))
            {
                // Leggi il JSON dal file
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("preferences.json", FileMode.Open, isoStore))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    preferences = JsonConvert.DeserializeObject<Preferences>(json);
                }
            }

            return preferences;
        }
    }
}
