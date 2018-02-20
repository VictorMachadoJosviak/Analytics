using Analytics.Core.DTOs;
using Analytics.Core.Interfaces.Repositories;
using Analytics.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Core.Sevices
{
    public class ApplicationUserService : IApplicationUserService ,IDisposable
    {
        private readonly IApplicationUserRepository appliationUserRepository;

        public ApplicationUserService(IApplicationUserRepository _appliationUserRepository)
        {
            appliationUserRepository = _appliationUserRepository;
        }

        public ApplicationUserDTO AuthenticateUser(ApplicationUserDTO dto)
        {
            return null;
        }

        public void Dispose()
        {
            
        }
    }
}
