using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SARDT.Models
{
    public class MessagesVM
    {
        List<bool> selectedMembers = new List<bool>();
        public List<Member> Members { get; set; }

        public List<bool> SelectedMembers
        {
            get
            {
                return selectedMembers;
            }
            set
            {
                selectedMembers = value;
            }
        }
        public Message Message { get; set; }
    }
}