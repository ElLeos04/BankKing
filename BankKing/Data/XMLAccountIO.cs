using BankKing.Data.Account;
using System.IO;
using System.Xml.Serialization;

namespace BankKing.Data
{
    public class XMLAccountIO : IAccountIO
    {
        private const string FOLDER_PATH = "./Data/Accounts/";

        public void SaveAccount(BankAccount account)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BankAccount));
            string filePath = FOLDER_PATH + account.Name + ".xml";

            CheckFolder();

            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            serializer.Serialize(fileStream, account);
        }

        public List<BankAccount> GetAccounts()
        {
            List<BankAccount> accounts = [];

            CheckFolder();

            string[] files = Directory.GetFiles(FOLDER_PATH, "*.xml");
            foreach (string file in files)
            {
                XmlSerializer serializer = new(typeof(BankAccount));

                using FileStream fileStream = new(file, FileMode.Open);
                if (serializer.Deserialize(fileStream) is BankAccount account)
                {
                    accounts.Add(account);
                    account.Entries.Sort((a, b) => b.Date.CompareTo(a.Date));
                }

            }

            return accounts;
        }

        private static void CheckFolder()
        {
            if (!Directory.Exists(FOLDER_PATH))
            {
                Directory.CreateDirectory(FOLDER_PATH);
            }
        }
    }
}
