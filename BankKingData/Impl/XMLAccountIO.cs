using BankKingData.Account;
using System.Xml.Serialization;

namespace BankKingData.Impl;

public class XMLAccountIO : IAccountIO
{
    private const string FOLDER_PATH = "./Data/Accounts/";

    public void SaveAccount(BankAccountData account)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(BankAccountData));
        string filePath = FOLDER_PATH + account.Name + ".xml";

        CheckFolder();

        using FileStream fileStream = new FileStream(filePath, FileMode.Create);
        serializer.Serialize(fileStream, account);
    }

    public List<BankAccountData> GetAccounts()
    {
        List<BankAccountData> accounts = [];

        CheckFolder();

        string[] files = Directory.GetFiles(FOLDER_PATH, "*.xml");
        foreach (string file in files)
        {
            XmlSerializer serializer = new(typeof(BankAccountData));

            using FileStream fileStream = new(file, FileMode.Open);
            if (serializer.Deserialize(fileStream) is BankAccountData account)
            {
                accounts.Add(account);
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
