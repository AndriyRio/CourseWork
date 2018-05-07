using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository.Impl
{
    class ProductRepositoryImpl : IProductRepository
    {
        private ShopOfJoinerArticlesDBEntities db;

        public ProductRepositoryImpl(ShopOfJoinerArticlesDBEntities db)
        {
            this.db = db;
        }
        //Додавання нового продукту
        public Product Add(Product product)
        {
            Product savedProduct = db.Products.Add(product);
            db.SaveChanges();
            return savedProduct;
        }
        //Видалення товару
        public void Delete(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        //Редагування продукту
        public void Edit(Product product, string name, Categorie categorie, DateTime? manufaturedDate, DateTime? importDate, int price, Manufacturer manufacturer)
        {
            product.name = name;
            product.Categorie = categorie;
            product.categoryID = categorie.categoryID;
            product.manufacturedDate = manufaturedDate;
            product.importDate = importDate;
            product.price = price;
            product.Manufacturer = manufacturer;
            product.manufaturerID = manufacturer.manufactureID;

            db.SaveChanges();
        }

        //Вибірка всіх 
        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }
    }
}
