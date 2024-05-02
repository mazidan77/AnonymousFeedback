using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFeedback.Application.Dtos.FeedBackDto
{
    public class FeedBackBaseDto
    {
        public string Content { get; set; }

        public bool IsAnonymous { get; set; }
        public bool IsRead { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }
    }
}
