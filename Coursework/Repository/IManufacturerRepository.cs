using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository
{
    public interface IManufacturerRepository
    {
        List<Manufacturer> GetAll();
        Manufacturer Add(Manufacturer manufacturer);
        void Delete(Manufacturer manufacturer);
        void Edit(Manufacturer manufacturer, String name, String email, String phoneNumber);
    }
}
