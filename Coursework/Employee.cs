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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int employeeID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public System.DateTime dataOfBirth { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public System.DateTime hireDate { get; set; }
        public int rankID { get; set; }
    
        public virtual Rank Rank { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
