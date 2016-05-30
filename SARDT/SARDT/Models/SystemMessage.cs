using System;
using System.Collections.Generic;
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
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}