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
    
    public partial class Registration
    {
        public Registration()
        {
            this.Invoices = new HashSet<Invoice>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Anmerkung { get; set; }
        public int CourseId { get; set; }
        public int PersonId { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual Person Person { get; set; }
    }
}
