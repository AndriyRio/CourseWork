using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository
{
    public interface IClientRepository
    {
        List<Сlient> GetAll();
        Сlient Add(Сlient client);
        void Delete(Сlient client);
        void Edit(Сlient сlient, String firstName, String lastName, DateTime? dateOfBirth, String phoneNumber, String addres, String email);
    }
}
