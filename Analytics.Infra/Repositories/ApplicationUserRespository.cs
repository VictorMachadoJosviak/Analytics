using Analytics.Core.Interfaces.Repositories;
using Analytics.Core.Models;
using Analytics.Infra.Persistence;
using Analytics.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Infra.Repositories
{
    public class ApplicationUserRespository : RepositoryBase<ApplicationUser, Guid>, IApplicationUserRepository
    {
        private readonly DataContext db;

        public ApplicationUserRespository(DataContext _db) :base(_db)
        {
            db = _db;
        }
    }
}
