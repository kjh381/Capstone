using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class Message
    {
    
        public int ID { get; set; }
        public Member From { get; set; }
        public List<Member> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool Recurring { get; set; }
    }
}