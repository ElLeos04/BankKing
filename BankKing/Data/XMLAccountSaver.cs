using BankKing.Data.Account;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace BankKing.Data
{
    public class XMLAccountSaver : IAccountIO
    {
        private const string FOLDER_PATH = "./Data/Accounts/";

        public void SaveAccount(BankAccount account)
        {
            Trace.WriteLine("Début de l'écriture");

            XmlSerializer serializer = new XmlSerializer(typeof(BankAccount));
            string filePath = FOLDER_PATH + account.Name + ".xml";

            if (!Directory.Exists(FOLDER_PATH))
            {
                Trace.WriteLine("Dossier manquant...");
                Directory.CreateDirectory(FOLDER_PATH);
                Trace.WriteLine("Dossier crée");
            }

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, account);
            }

            Trace.WriteLine("Fin de l'écriture");
        }
    }
}
