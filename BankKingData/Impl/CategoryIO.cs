using BankKingData.Entry;
using System.Xml.Serialization;

namespace BankKingData.Impl;

public class CategoryIO : ICategoryIO
{
    private const string FOLDER_PATH = "./Data/";

    public List<EntryCategoryData> GetCategories()
    {
        CheckFolder();

        string[] files = Directory.GetFiles(FOLDER_PATH, "Categories.xml");

        if (files.Length == 0)
        {
            return [];
        }

        XmlSerializer serializer = new(typeof(List<EntryCategoryData>));

        using FileStream fileStream = new(files.First(), FileMode.Open);
        if (serializer.Deserialize(fileStream) is List<EntryCategoryData> categories)
        {
            return categories;
        }

        return [];
    }

    public void SaveCategories(List<EntryCategoryData> categories)
    {
        CheckFolder();

        XmlSerializer serializer = new XmlSerializer(typeof(List<EntryCategoryData>));
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
