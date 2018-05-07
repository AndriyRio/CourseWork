using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository.Impl
{
    class UserRepositoryImpl : IUserRepository
    {
        private ShopOfJoinerArticlesDBEntities db;

        public UserRepositoryImpl(ShopOfJoinerArticlesDBEntities db)
        {
            this.db = db;
        }

        //Додавання нового юзера
        public User Add(User user)
        {
            User savedUser = db.Users.Add(user);
            db.SaveChanges();
            return user;
        }
        //Видалення юзера
        public void Delete(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }


        //Редагування користуача
        public void Edit(User user, string login, string password, Role role)
        {
            user.login = login;
            user.password = password;
            user.Role = role;
            user.roleId = role.roleId;

            db.SaveChanges();
        }

        public User FindByLoginAndPassword(String login, String password)
        {
            User user = null;
            user = db.Users.Where(o => o.login == login && o.password == password).First();

            return user;
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }
    }
}
