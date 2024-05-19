using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFeedback.Application.Dtos.FeedBackDto
{
    public class FeedBackGetDto : FeedBackBaseDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderUserName { get; set; }

        public string ReceiverUserName { get; set; }

        public bool IsRepalied { get; set; }
        public string Replay { get; set; }
    }
}
