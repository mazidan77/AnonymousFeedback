using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFeedback.Domian.Models
{
    public class User
    {
      
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int MobileNumber {  get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsVerified { get; set; }

        public virtual List<FeedBack> SentFeedbacks { get; set; }
        public virtual List<FeedBack> ReceivedFeedbacks { get; set; }


    }
}
