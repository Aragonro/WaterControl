using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoterCantrol.DAL.Entities;

namespace WoterCantrol.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Sensor> Sensors { get; }
        IRepository<Product> Products { get; }
        IRepository<Order> Orders { get; }
        IRepository<NewOrder> NewOrders { get; }
        IRepository<NewAddress> NewAddresses { get; }
        IRepository<Monitoring> Monitorings { get; }
        IRepository<DeliverySetting> DeliverySettings { get; }
        IRepository<Statistic> Statistics { get; }
        void Save();
    }
}
