using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository
{
    public interface IPaymentRepository
    {
        List<Payment> GetAll();
        Payment Add(Payment payment);
        void Delete(Payment payment);
    }
}
