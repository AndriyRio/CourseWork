using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository
{
    public interface ICategorieRepository
    {
        List<Categorie> GetAll();
        Categorie Add(Categorie categorie);
        void Delete(Categorie categorie);
    }
}
