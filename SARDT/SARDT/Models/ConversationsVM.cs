﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class ConversationsVM
    {
        public List<Member> Members { get; set; }
        public Member SelectedMember { get; set; }
    }
}