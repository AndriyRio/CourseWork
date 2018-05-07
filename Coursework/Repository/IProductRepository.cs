using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Add(Product product);
        void Delete(Product product);
        void Edit(Product product, String name, Categorie categorie, 
            DateTime? manufaturedDate, DateTime? importDate, int price, Manufacturer manufacturer);
    }
}