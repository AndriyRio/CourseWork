using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository.Impl
{
    class EmployeeRepositoryImpl : IEmployeeRepository
    {
        public ShopOfJoinerArticlesDBEntities db { get; set; }

        public EmployeeRepositoryImpl(ShopOfJoinerArticlesDBEntities db)
        {
            this.db = db;
        }
        //Додавання нового користувача
        public Employee Add(Employee employee)
        {
            Employee savedEmployee;
            savedEmployee = db.Employees.Add(employee);
            db.SaveChanges();
            return savedEmployee;
        }

        //Видалення користувача
        public void Delete(Employee employee)
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        //Вибірка всіх працівників
        public List<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        //Редагуваня працівника
        public void Edit(Employee employee, string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string addres, DateTime hireDate, Rank rank)
        {
            employee.firstName = firstName;
            employee.lastName = lastName;
            employee.dataOfBirth = dateOfBirth;
            employee.phoneNumber = phoneNumber;
            employee.address = addres;
            employee.hireDate = hireDate;
            employee.Rank = rank;
            employee.rankID = rank.rankID;

            db.SaveChanges();
        }
    }
}
