using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    [MetadataType(typeof(PersonMetaData))]
    public partial class Person
    {
        public DateTime? LastCourseDate
        {
            get
            {
                return Registrations.Max(reg => reg.Date);
            } 
            
        }

        public string Description
        {
            get { return FirstName + " " + LastName + ", " + EMail + ", " + Phone; }
        }
    }

    public class PersonMetaData
    {
        [Required(ErrorMessage = "Vorname muss eingegeben werden")]
        [DisplayName("Vorname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Familienname muss eingegeben werden")]
        [DisplayName("Familienname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-Mail Adresse muss eingegeben werden")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-Mail Adresse")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Telefonnummer muss eingegeben werden")]
        [DisplayName("Telefonnummer")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Geschlecht muss ausgewählt werden")]
        [DisplayName("Geschlecht")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Adresse muss eingegeben werden")]
        [DisplayName("Adresse")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Postleitzahl muss eingegeben werden")]
        [DisplayName("Postleitzahl")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Ort muss eingegeben werden")]
        [DisplayName("Ort")]
        public string City { get; set; }
    }

    public enum Sex
    {
        M,
        W
    }
}