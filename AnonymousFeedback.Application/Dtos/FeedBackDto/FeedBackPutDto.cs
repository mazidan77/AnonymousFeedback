using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFeedback.Application.Dtos.FeedBackDto
{
    public class FeedBackPutDto : FeedBackBaseDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
    }
}
