using BankKing.Data.Account;
using System.IO;
using System.Xml.Serialization;

namespace BankKing.Data
{
    public class XMLAccountSaver : IAccountIO
    {
        private const string FOLDER_PATH = "/Data/Accounts/";

        public void SaveAccount(BankAccount account)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BankAccount));
            string filePath = FOLDER_PATH + account.Name + ".xml";

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, account);
            }
        }
    }
}
