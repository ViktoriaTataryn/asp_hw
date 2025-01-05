using ht3.Models;
namespace ht3.Data
{
    public interface IDatabase<T>
    {
        IEnumerable<T> Get();
        void Add(T item);
        void Update(T oldbook, T book);
        void Delete(T book);
    }
}
