using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository
{
    public interface IRoleRepository
    {
        List<Role> GetAll();
        Role Add(Role role);
        void Delete(int id);
    }
}
