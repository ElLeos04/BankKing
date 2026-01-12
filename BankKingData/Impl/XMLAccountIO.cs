using BankKingData.Account;

namespace BankKingData.Impl;

public class XMLAccountIO : AXmlSerializer<BankAccountData>, IAccountIO
{
    private const string FOLDER_PATH = "./Data/Accounts/";

    public XMLAccountIO() : base(FOLDER_PATH) { }

    public void SaveAccount(BankAccountData account)
    {
        string fileName = account.Name + ".xml";
        Serialize(fileName, account);
    }

    public List<BankAccountData> GetAccounts()
    {
        List<BankAccountData> accounts = [];

        CheckFolder();

        string[] files = Directory.GetFiles(FOLDER_PATH, "*.xml");
        foreach (string file in files)
        {
            accounts.Add(Deserialize(file));
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

    public override BankAccountData Get()
    {
        throw new NotImplementedException();
    }

    public override void Save(BankAccountData data)
    {
        throw new NotImplementedException();
    }

    public override void Rename(BankAccountData data, string newName)
    {
        throw new NotImplementedException();
    }

    public override void Delete(BankAccountData data)
    {
        throw new NotImplementedException();
    }
}
