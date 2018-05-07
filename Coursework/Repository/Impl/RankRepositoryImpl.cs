using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository.Impl
{
    class RankRepositoryImpl : IRankRepository
    {
        private ShopOfJoinerArticlesDBEntities db;

        public RankRepositoryImpl(ShopOfJoinerArticlesDBEntities db) {
            this.db = db;
        }
        public Rank Add(Rank rank)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Rank> GetAll()
        {
            return db.Ranks.ToList();
        }
    }
}
