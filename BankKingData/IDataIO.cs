namespace BankKingData;

public interface IDataIO
{
    object Get();

    void Save(object data);

    void Rename(object data, string newName);

    void Delete(object data);
}

public interface IDataIO<T> : IDataIO
{
    new T Get();

    void Save(T data);

    void Rename(T data, string newName);

    void Delete(T data);
}
