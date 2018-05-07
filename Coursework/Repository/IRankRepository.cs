using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository
{
    public interface IRankRepository
    {
        List<Rank> GetAll();
        Rank Add(Rank rank);
        void Delete(int id);
    }
}
