using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication3.Models;

namespace MvcApplication3.ViewModels
{
    public class HomePage
    {
        public IList<Registration> NewRegistrations { get; set; }
        public IList<Course> CoursesToBill { get; set; }
        public IList<Invoice> OverdueInvoices { get; set; }
    }
}