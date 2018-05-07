using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository
{
    public interface IUserRepository
    {
        User FindByLoginAndPassword(String login, String password);
        User Add(User user);
        void Delete(User user);
        void Edit(User user, String login, String password, Role role);
        List<User> GetAll();
    }
}
