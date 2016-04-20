using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class Event
    {
        public int EventID { get; set; }

        public string Type { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Start Time is required")]
        [RegularExpression(@"^\d{4}$", 
            ErrorMessage = "Must be in 24 hour time format 1200")]
        public string StartTime { get; set; }

        [Required(ErrorMessage = "End Time is required")]
        [RegularExpression(@"^\d{4}$",
            ErrorMessage = "Must be in 24 hour time format 1200")]
        public string EndTime { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string EventTitle { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastChangedOn { get; set; }
        public string LastChangeBy { get; set; }
    }
}