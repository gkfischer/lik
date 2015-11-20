using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication3.ViewModels
{
    public class CourseStatistics
    {
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public string Venue { get; set; }
        public string Year { get; set; }
        public int NumberOfStudents { get; set; }
    }
}