using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository.Impl
{
    class PaymentRepositoryImpl : IPaymentRepository
    {
        private ShopOfJoinerArticlesDBEntities db;

        public PaymentRepositoryImpl(ShopOfJoinerArticlesDBEntities db)
        {
            this.db = db;
        }
        public Payment Add(Payment payment)
        {
            Payment savedPayment = db.Payments.Add(payment);
            db.SaveChanges();
            return savedPayment;
        }

        public void Delete(Payment payment)
        {
            db.Payments.Remove(payment);
            db.SaveChanges();
        }

        public List<Payment> GetAll()
        {
            return db.Payments.ToList();
        }
    }
}
