using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class RoleRepository : BaseRepository, IRepository<Role>, IRoleRepository
    {
        public IEnumerable<Role> GetAll()
        {
            return Model.Role.ToList();
        }

        public Role GetById(int id)
        {
            return Model.Role.FirstOrDefault(x => x.Id == id);
        }

        public int GetCountByName(string name)
        {
            return Model.Role.Count(x => x.Name == name);
        }

        public bool Insert(Role entity)
        {
            Model.Role.Add(entity);
            Model.SaveChanges();
            return true;
        }

        public bool Remove(Role entity)
        {
            Model.Role.Remove(entity);
            Model.SaveChanges();
            return true;
        }

        public bool Update(Role entity)
        {
            Model.SaveChanges();
            return true;
        }
    }
}
