using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class Conversation
    {
        private List<Message> messages = new List<Message>();
        public int ID { get; set; }
        public string FirstMemberID { get; set; }
        public string SecondMemberID { get; set; }
        public List<Message> UserMessages
        {
            get
            {
                return messages;
            }
            set
            {
                messages = value;
            }
        }
    }
}