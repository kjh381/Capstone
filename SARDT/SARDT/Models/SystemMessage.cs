using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class SystemMessage
    {
        private List<Member> to = new List<Member>();
    
        public int ID { get; set; }
        public Member From { get; set; }
        public List<Member> To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
            }
        }
        [Required(ErrorMessage = "Subject is Required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Subject is Required")]
        public string Body { get; set; }
    }
}