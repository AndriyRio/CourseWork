//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Coursework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int paymentID { get; set; }
        public int pmodeID { get; set; }
        public int orderID { get; set; }
        public decimal amountPaid { get; set; }
        public Nullable<System.DateTime> chequeDate { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual PaymentMode PaymentMode { get; set; }
    }
}
