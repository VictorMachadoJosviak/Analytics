using Analytics.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Core.Interfaces.Services
{
    public interface IApplicationUserService : IServiceBase ,IDisposable
    {
        ApplicationUserDTO AuthenticateUser(ApplicationUserDTO dto);
    }
}
