using AnonymousFeedback.Application.Dtos.IdentityDto;
using AnonymousFeedback.Domian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFeedback.Domian.IManagers
{
    public interface IIdentityManager:IBaseManager<User>
    {
        Task<User> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto dto);

    }
}
