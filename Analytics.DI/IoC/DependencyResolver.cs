using Analytics.Core.Interfaces.Repositories;
using Analytics.Core.Interfaces.Repositories.Base;
using Analytics.Core.Interfaces.Services;
using Analytics.Core.Sevices;
using Analytics.Infra.Persistence;
using Analytics.Infra.Repositories;
using Analytics.Infra.Repositories.Base;
using Analytics.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Analytics.DI.IoC
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {

            container.RegisterType<DbContext, DataContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
          //  container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            //container.RegisterType(typeof(IServiceBase<,>), typeof(ServiceBase<,>));

            container.RegisterType<IApplicationUserService, ApplicationUserService>(new HierarchicalLifetimeManager());
            
            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            container.RegisterType<IApplicationUserRepository, ApplicationUserRespository>(new HierarchicalLifetimeManager());
           



        }
    }
}
