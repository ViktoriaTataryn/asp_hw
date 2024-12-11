using Microsoft.AspNetCore.Identity;
using ht2.Models;

namespace ht2.Data
{
    public class ManagerDatabase : IDatabase<Manager>
    {
        private readonly List<Manager> _managers;
        public ManagerDatabase()
        {
            _managers = new List<Manager>();
        }
        public void Add(Manager item)
        {
            _managers.Add(item);
        }

        public IEnumerable<Manager> Get()
        {
           return _managers;
        }
    }
}
