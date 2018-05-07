using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository.Impl
{
    class CategoyRepositoryImpl : ICategorieRepository
    {
        private ShopOfJoinerArticlesDBEntities db;

        public CategoyRepositoryImpl(ShopOfJoinerArticlesDBEntities db)
        {
            this.db = db;
        }
        //Додавання нової категорії
        public Categorie Add(Categorie categorie)
        {
            Categorie savedCategorie = db.Categories.Add(categorie);
            db.SaveChanges();
            return savedCategorie;
        }
        //Видалення категорії
        public void Delete(Categorie categorie)
        {
            db.Categories.Remove(categorie);
            db.SaveChanges();
        }

        public List<Categorie> GetAll()
        {
            return db.Categories.ToList();
        }
    }
}
