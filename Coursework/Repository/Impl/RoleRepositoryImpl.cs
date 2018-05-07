using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository.Impl
{
    class RoleRepositoryImpl : IRoleRepository
    {
        private ShopOfJoinerArticlesDBEntities db;

        public RoleRepositoryImpl(ShopOfJoinerArticlesDBEntities db)
        {
            this.db = db;
        }

        public Role Add(Role role)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAll()
        {
            return db.Roles.ToList();
        }
    }
}
