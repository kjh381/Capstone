using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class Message
    {
        public int ID { get; set; }
        public int ConversationID { get; set; }
        public DateTime Date { get; set; }
        public string AuthorID { get; set; }
        public string Body { get; set; }
        public bool Unread { get; set; }
    }
}