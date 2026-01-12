using BankKingData.Entry;

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

    public override List<EntryCategoryData> Get()
    {
        throw new NotImplementedException();
    }

    public override void Save(List<EntryCategoryData> data)
    {
        throw new NotImplementedException();
    }

    public override void Rename(List<EntryCategoryData> data, string newName)
    {
        throw new NotImplementedException();
    }

    public override void Delete(List<EntryCategoryData> data)
    {
        throw new NotImplementedException();
    }
}
