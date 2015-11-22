using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication3.Models
{
    public partial class Invoice
    {
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
                    case "Deposit":
                        daysToPay = Registration.Course.DepositDueTimeframe.Value;
                        break;
                    case "Invoice1":
                        daysToPay = Registration.Course.Invoice1DueTimeframe.Value;
                        break;
                    case "Invoice2":
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