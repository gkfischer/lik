using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{

    [MetadataType(typeof(RegistrationMetaData))]
    public partial class Registration
    {
        [DisplayName("Anzahlung")]
        public Invoice DepositBill
        {
            get
            {
                return Invoices.FirstOrDefault<Invoice>(i => i.Type == "DepositBill");
            }
        }

        [DisplayName("Rechnung 1")]
        public Invoice Invoice1Bill
        {
            get
            {
                return Invoices.FirstOrDefault<Invoice>(i => i.Type == "Invoice1Bill");
            }
        }

        [DisplayName("Rechnung 2")]
        public Invoice Invoice2Bill
        {
            get
            {
                return Invoices.FirstOrDefault<Invoice>(i => i.Type == "Invoice2Bill");
            }
        }

        public Boolean HasDepositBill
        {
            get { return DepositBill != null; }
        }

        public Boolean HasInvoice1Bill
        {
            get { return Invoice1Bill != null; }
        }

        public Boolean HasInvoice2Bill
        {
            get { return Invoice2Bill != null; }
        }

    }

    public class RegistrationMetaData
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Datum der Anmeldung")]
        public Nullable<DateTime> Date { get; set; }

        [DisplayName("Anmerkungen")]
        public string Remarks { get; set; }

        [DisplayName("Kurs")]
        public virtual Course Course { get; set; }

        [DisplayName("Teilnehmer")]
        public virtual Person Person { get; set; }
    }
}