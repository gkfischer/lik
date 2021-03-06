﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Html;

namespace MvcApplication3.Models
{
    [MetadataType(typeof(CourseMetaData))]
    public partial class Course
    {
        public string Description
        {
            get { return Date.Value.ToShortDateString() + ", " + Name + ", Jahrgang: " + Year + ", " + Venue; }
        }

        public bool HasDeposit
        {
            get
            {
                return AmountDeposit > 0;
            }
        }

        public bool HasInvoice1
        {
            get
            {
                return AmountInvoice1 > 0;
            }
        }

        public bool HasInvoice2
        {
            get
            {
                return AmountInvoice2 > 0;
            }
        }

        public string BillDue
        {
            get
            {
                if (DateInvoice1 <= DateTime.Today && Registrations.Any() && !Registrations.Any(r => r.HasInvoice1Bill))
                {
                    return "Rechnung 1";
                }

                if (DateInvoice2 <= DateTime.Today && Registrations.Any() && !Registrations.Any(r => r.HasInvoice2Bill))
                {
                    return "Rechnung 2";
                }
                return string.Empty;
            }
        }

    }

    public class CourseMetaData
    {
        [Required(ErrorMessage = "Name muss eingegeben werden")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Beginndatum muss eingegeben werden")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Beginndatum")]
        public Nullable<System.DateTime> Date { get; set; }

        [Required(ErrorMessage = "Ort muss eingegeben werden")]
        [DisplayName("Ort")]
        public string Venue { get; set; }

        [Required(ErrorMessage = "Jahrgang muss eingegeben werden")]
        [DisplayName("Jahrgang")]
        public string Year { get; set; }

        [DisplayName("Betrag Anzahlung")]
        public Nullable<decimal> AmountDeposit { get; set; }

        [Required(ErrorMessage = "Betrag muss eingegeben werden")]
        [DisplayName("Betrag 1. Rechnung")]
        public Nullable<decimal> AmountInvoice1 { get; set; }

        [Required(ErrorMessage = "Beginndatum muss eingegeben werden")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Datum Versand 1. Rechnung")]
        public Nullable<System.DateTime> DateInvoice1 { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Datum Versand 2. Rechnung")]
        public Nullable<System.DateTime> DateInvoice2 { get; set; }

        [DisplayName("Betrag 2. Rechnung")]
        public Nullable<decimal> AmountInvoice2 { get; set; }

        [DisplayName("Anzahlung fällig in Tagen")]
        public Nullable<short> DepositDueTimeframe { get; set; }

        [Required(ErrorMessage = "Fälligkeit muss eingegeben werden")]
        [DisplayName("1. Rechnung fällig in Tagen")]
        public Nullable<short> Invoice1DueTimeframe { get; set; }

        [DisplayName("2. Rechnung fällig in Tagen")]
        public Nullable<short> Invoice2DueTimeframe { get; set; }

    }
}