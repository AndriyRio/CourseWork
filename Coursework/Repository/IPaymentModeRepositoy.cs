using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Repository
{
    public interface IPaymentModeRepositoy
    {
        List<PaymentMode> GetAll();
        Payment Add(Payment payment);
        void Delete(int id);
    }
}
