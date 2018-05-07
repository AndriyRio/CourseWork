using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order Add(Order order);
        void Delete(Order order);
        void SaveChanges();
        void Edit(Order order, DateTime? orderDate, 
            DateTime? payDate, Decimal discount, Сlient сlient, 
            String paymentStatus, String deliveredStatus);
    }
}
