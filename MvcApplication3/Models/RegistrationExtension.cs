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
         
    }
    public class RegistrationMetaData
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Datum der Anmeldung")]
        public Nullable<DateTime> Date { get; set; }


    }
}