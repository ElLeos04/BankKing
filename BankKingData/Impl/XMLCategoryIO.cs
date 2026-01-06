using BankKingData.Entry;
using System.Xml.Serialization;

namespace BankKingData.Impl;

public class XMLCategoryIO : AXmlSerializer<List<EntryCategoryData>>, ICategoryIO
{
    private const string FOLDER_PATH = "./Data/";

    private const string FILE_NAME = "Categories.xml";

    public XMLCategoryIO() : base(FOLDER_PATH)
    {
    }
    public void SaveCategories(List<EntryCategoryData> categories)
    {
        Serialize(FILE_NAME, categories);
    }

    public List<EntryCategoryData> GetCategories()
    {
        CheckFolder();

        string[] files = Directory.GetFiles(FOLDER_PATH, FILE_NAME);

        if (files.Length == 0)
        {
            return [];
        }

        return Deserialize(files.First());
    }

    private static void CheckFolder()
    {
        if (!Directory.Exists(FOLDER_PATH))
        {
            Directory.CreateDirectory(FOLDER_PATH);
        }
    }
}
