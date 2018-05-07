using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository.Impl
{
    class ManufacturerRepositoryImpl : IManufacturerRepository
    {
        private ShopOfJoinerArticlesDBEntities db;

        public ManufacturerRepositoryImpl(ShopOfJoinerArticlesDBEntities db)
        {
            this.db = db;
        }
        //Додавання нового виробника
        public Manufacturer Add(Manufacturer manufacturer)
        {
            Manufacturer savedManufacturer = db.Manufacturers.Add(manufacturer);
            db.SaveChanges();
            return savedManufacturer;
        }
        //Видалення виробника
        public void Delete(Manufacturer manufacturer)
        {
            db.Manufacturers.Remove(manufacturer);
            db.SaveChanges();
        }

        //Редагування виробника
        public void Edit(Manufacturer manufacturer, string name, string email, string phoneNumber)
        {
            manufacturer.name = name;
            manufacturer.e_mail = email;
            manufacturer.phoneNumber = phoneNumber;

            db.SaveChanges();
        }

        public List<Manufacturer> GetAll()
        {
            return db.Manufacturers.ToList();
        }
    }
}
