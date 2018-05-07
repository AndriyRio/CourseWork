using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee Add(Employee employee);
        void Delete(Employee employee);
        void Edit(Employee employee, String firstName, String lastName, DateTime dateOfBirth,
            String phoneNumber, String addres, DateTime hireDate, Rank rank);
        //void SaveChanges();
    }
}
