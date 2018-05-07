using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository.Impl
{
    class ClientRepositoryImpl : IClientRepository
    {
        private ShopOfJoinerArticlesDBEntities db;

        public ClientRepositoryImpl(ShopOfJoinerArticlesDBEntities db)
        {
            this.db = db;
        }
        //Додавання нового клієнта
        public Сlient Add(Сlient client)
        {
            Сlient savedClient = db.Сlient.Add(client);
            db.SaveChanges();
            return savedClient;
        }
        //Видалення клієнта
        public void Delete(Сlient client)
        {
            db.Сlient.Remove(client);
            db.SaveChanges();
        }

        //Редагування клієнта
        public void Edit(Сlient сlient, string firstName, string lastName, DateTime? dateOfBirth, string phoneNumber, string addres, string email)
        {
            сlient.firstName = firstName;
            сlient.lastName = lastName;
            сlient.dateOfBirth = dateOfBirth;
            сlient.phoneNumber = phoneNumber;
            сlient.address = addres;
            сlient.e_mail = email;

            db.SaveChanges();
        }

        //Вибірка всіх клієнтів
        public List<Сlient> GetAll()
        {
            return db.Сlient.ToList();
        }
    }
}
