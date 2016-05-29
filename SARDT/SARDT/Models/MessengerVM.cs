using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class MessengerVM
    {
        private Conversation conversation = new Conversation();
        private Member currentMember = new Member();
        private Member secondMember = new Member();
        public string CurrentMessage { get; set; }

        public Member CurrentMember
        {
            get
            {
                return currentMember;
            }
            set
            {
                currentMember = value;
            }
        }
        public Member SecondMember
        {
            get
            {
                return secondMember;
            }
            set
            {
                secondMember = value;
            }
        }

        public Conversation Conversation
        {
            get
            {
                return conversation;
            }
            set
            {
                conversation = value;
            }
        }
    }
}