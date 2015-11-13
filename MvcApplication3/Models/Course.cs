//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        public Course()
        {
            this.Registrations = new HashSet<Registration>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Venue { get; set; }
        public string Year { get; set; }
        public Nullable<decimal> AmountDeposit { get; set; }
        public Nullable<decimal> AmountInvoice1 { get; set; }
        public Nullable<decimal> AmountInvoice2 { get; set; }
        public Nullable<short> DepositDueTimeframe { get; set; }
        public Nullable<short> Invoice1DueTimeframe { get; set; }
        public Nullable<short> Invoice2DueTimeframe { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> DateInvoice1 { get; set; }
        public Nullable<System.DateTime> DateInvoice2 { get; set; }
    
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
