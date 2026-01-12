using System.Xml.Serialization;

namespace BankKingData.Impl;

public abstract class AXmlSerializer<T> : IDataIO<T>
{
    private readonly string folderPath;

    internal AXmlSerializer(string folderPath)
    {
        this.folderPath = folderPath;
    }

    protected void Serialize(string fileName, T data)
    {
        CheckFolder();

        XmlSerializer serializer = new(typeof(T));
        using FileStream fileStream = new(folderPath + fileName, FileMode.Create);
        serializer.Serialize(fileStream, data);
    }

    protected T Deserialize(string fileName)
    {
        CheckFolder();

        XmlSerializer serializer = new(typeof(T));
        using FileStream fileStream = new(fileName, FileMode.Open);
        if (serializer.Deserialize(fileStream) is T data)
        {
            return data;
        }

        return default!;
    }

    private void CheckFolder()
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }

    public abstract T Get();
    public abstract void Save(T data);
    public abstract void Rename(T data, string newName);
    public abstract void Delete(T data);
}
