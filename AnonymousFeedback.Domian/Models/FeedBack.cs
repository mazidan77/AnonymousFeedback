﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFeedback.Domian.Models
{
    public class FeedBack
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsAnonymous { get; set; }
         public bool IsRead { get; set; }

        public string SenderUserName { get; set; }

        public virtual User Sender { get; set; }

        public string ReceiverUserName { get; set; }
        public virtual User Receiver { get; set; }


    }
}
