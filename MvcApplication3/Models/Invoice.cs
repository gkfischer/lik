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
    
    public partial class Invoice
    {
        public int Id { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> DateInvoice { get; set; }
        public Nullable<System.DateTime> DateSent { get; set; }
        public Nullable<System.DateTime> DatePaid { get; set; }
        public Nullable<System.DateTime> DateCancellation { get; set; }
        public string Type { get; set; }
        public int RegistrationId { get; set; }
        public Nullable<int> Number { get; set; }
    
        public virtual Registration Registration { get; set; }
    }
}
