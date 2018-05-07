using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository.Impl
{
    class PaymentModeRepositoryImpl : IPaymentModeRepositoy
    {

        private ShopOfJoinerArticlesDBEntities db;

        public PaymentModeRepositoryImpl(ShopOfJoinerArticlesDBEntities db)
        {
            this.db = db;
        }

        public Payment Add(Payment payment)
        {
            Payment savedPayment = db.Payments.Add(payment);
            db.SaveChanges();
            return savedPayment;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PaymentMode> GetAll()
        {
            return db.PaymentModes.ToList();
        }
    }
}
