using Ninject.Modules;
using WoterCantrol.DAL.Interfaces;
using WoterCantrol.DAL.Repositories;

namespace WoterCantrol.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
