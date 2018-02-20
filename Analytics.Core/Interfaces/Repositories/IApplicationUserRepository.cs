using Analytics.Core.Interfaces.Repositories.Base;
using Analytics.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Core.Interfaces.Repositories
{
    public interface IApplicationUserRepository : IRepositoryBase<ApplicationUser, Guid>
    {

    }
}
