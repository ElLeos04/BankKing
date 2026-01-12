namespace BankKingData;

public interface IDataIO<T>
{
    T Get();

    void Save(T data);

    void Rename(T data, string newName);

    void Delete(T data);
}
