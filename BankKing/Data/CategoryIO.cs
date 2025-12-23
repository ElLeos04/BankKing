using BankKing.Data.Account;
using BankKing.Data.Entry;
using System.IO;
using System.Security.Principal;
using System.Xml.Serialization;

namespace BankKing.Data;

public class CategoryIO : ICategoryIO
{
    private const string FOLDER_PATH = "./Data/";

    public List<EntryCategory> GetCategories()
    {
        CheckFolder();

        string[] files = Directory.GetFiles(FOLDER_PATH, "Categories.xml");

        if (files.Length == 0)
        {
            return [];
        }

        XmlSerializer serializer = new(typeof(List<EntryCategory>));

        using FileStream fileStream = new(files.First(), FileMode.Open);
        if (serializer.Deserialize(fileStream) is List<EntryCategory> categories)
        {
            return categories;
        }

        return [];
    }

    public void SaveCategories(List<EntryCategory> categories)
    {
        CheckFolder();

        XmlSerializer serializer = new XmlSerializer(typeof(List<EntryCategory>));
        string filePath = FOLDER_PATH + "Categories.xml";


        using FileStream fileStream = new FileStream(filePath, FileMode.Create);
        serializer.Serialize(fileStream, categories);
    }

    private static void CheckFolder()
    {
        if (!Directory.Exists(FOLDER_PATH))
        {
            Directory.CreateDirectory(FOLDER_PATH);
        }
    }
}
