using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository.Impl
{
    class OrderRepositoryImpl : IOrderRepository
    {
        private ShopOfJoinerArticlesDBEntities db;

        public OrderRepositoryImpl(ShopOfJoinerArticlesDBEntities db)
        {
            this.db = db;
        }

        //Додавання нового замовлення
        public Order Add(Order order)
        {
            Order savedOrder = db.Orders.Add(order);
            db.SaveChanges();
            return savedOrder;
        }

        //Видалення замовлення
        public void Delete(Order order)
        {
            db.Orders.Remove(order);
            db.SaveChanges();
        }

        //Редагування замовлення
        public void Edit(Order order, DateTime? orderDate, DateTime? payDate, decimal discount, Сlient сlient, string paymentStatus, string deliveredStatus)
        {
            order.orderDate = orderDate;
            order.payDate = payDate;
            order.discount = discount;
            order.Сlient = сlient;
            order.clientID = сlient.clientID;
            order.paymentStatus = paymentStatus;
            order.deliveredStatus = deliveredStatus;

            db.SaveChanges();
        }

        //Вибірка всіх замовлень
        public List<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
