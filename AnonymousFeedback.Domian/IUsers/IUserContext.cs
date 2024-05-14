using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFeedback.Domian.IUsers
{
    public interface IUserContext
    {
        int GetCurrentUserId();
    }
}
