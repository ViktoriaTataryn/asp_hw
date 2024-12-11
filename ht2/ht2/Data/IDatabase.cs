
namespace ht2.Data
{
    public interface IDatabase<T>
    {
        IEnumerable<T> Get();
        void Add(T item);
    }
}
