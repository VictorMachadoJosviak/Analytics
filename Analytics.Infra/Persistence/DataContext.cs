using Analytics.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Infra.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<ApplicationUser> Jogadores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Seta o Schema default
            //modelBuilder.HasDefaultSchema("Apoio");

            //Remove a pluralização dos nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Remove exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Setar para usar varchar ou invés de nvarchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Caso eu esqueça de informar o tamanho do campo ele irá colocar varchar de 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //Mapeia as entidades
            //modelBuilder.Configurations.Add(new JogadorMap());
            //modelBuilder.Configurations.Add(new PlataformaMap());

            #region Adiciona entidades mapeadas - Automaticamente via Assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(DataContext).Assembly);
            #endregion

            #region Adiciona entidades mapeadas - Automaticamente via NameSpace
            //Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => type.Namespace == "AlertaBrasil.Domain.Entities.DomainViagem")
            //    .ToList()
            //    .ForEach(type =>
            //    {
            //        dynamic instance = Activator.CreateInstance(type);
            //        modelBuilder.Configurations.Add(instance);
            //    });
            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
