using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication3.Models
{
    [MetadataType(typeof(InvoiceMetaData))]
    public partial class Invoice
    {
        private const int DespositDueTimeFrame = 7;

        [UIHint("InvoiceState")]
        public InvoiceState State
        {
            get
            {
                if (DateSent == null)
                {
                    return InvoiceState.Erstellt;
                }
                if (DateCancellation != null)
                {
                    return InvoiceState.Storniert;
                }
                if (DatePaid != null)
                {
                    return InvoiceState.Bezahlt;
                }
                var daysToPay = 0;
                switch (Type)
                {
                    case "DepositBill":
                        daysToPay = Registration.Course.DepositDueTimeframe.Value;
                        break;
                    case "Invoice1Bill":
                        daysToPay = Registration.Course.Invoice1DueTimeframe.Value;
                        break;
                    case "Invoice2Bill":
                        daysToPay = Registration.Course.Invoice2DueTimeframe.Value;
                        break;
                }
                if (DateSent != null && (DateInvoice.Value.AddDays(daysToPay) - DateTime.Now).Days >= 0)
                {
                    return InvoiceState.Versandt;
                }

                if (DateSent != null && (DateInvoice.Value.AddDays(daysToPay) - DateTime.Now).Days < 0)
                {
                    return InvoiceState.Offen;
                }

                return InvoiceState.Unbekannt;
            }
        }

        public int DaysOverdue
        {
            get
            {
                var difference = DateDue - DateTime.Now;
                return difference.Days < 0 ? -difference.Days : 0;
            }
        }

        public DateTime DateDue
        {
            get
            {
                var timeFrameDue = DespositDueTimeFrame;
                switch (Type)
                {
                    case "1. Rechnung":
                        timeFrameDue = Registration.Course.Invoice1DueTimeframe.Value;
                        break;
                    case "2. Rechnung":
                        timeFrameDue = Registration.Course.Invoice2DueTimeframe.Value;
                        break;
                }
                return DateInvoice.Value.AddDays(timeFrameDue);
            }
        }

    }

    public class InvoiceMetaData
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Rechnungsdatum")]
        public Nullable<DateTime> DateInvoice { get; set; }
    }

    public enum InvoiceState
    {
        Erstellt,
        Versandt,
        Offen,
        Bezahlt,
        Storniert,
        Unbekannt
    }

}