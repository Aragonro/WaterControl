using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoterCantrol.DAL.EF;
using WoterCantrol.DAL.Entities;
using WoterCantrol.DAL.Interfaces;

namespace WoterCantrol.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private WaterControlContext db;
        private UserRepository userRepository;
        private SensorRepository sensorRepository;
        private ProductRepository productRepository;
        private OrderRepository orderRepository;
        private NewOrderRepository newOrderRepository;
        private MonitoringRepository monitoringRepository;
        private DeliverySettingRepository deliverySettingRepository;
        private StatisticRepository statisticRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new WaterControlContext(connectionString);
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public IRepository<Sensor> Sensors
        {
            get
            {
                if (sensorRepository == null)
                    sensorRepository = new SensorRepository(db);
                return sensorRepository;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public IRepository<NewOrder> NewOrders
        {
            get
            {
                if (newOrderRepository == null)
                    newOrderRepository = new NewOrderRepository(db);
                return newOrderRepository;
            }
        }

        public IRepository<Monitoring> Monitorings
        {
            get
            {
                if (monitoringRepository == null)
                    monitoringRepository = new MonitoringRepository(db);
                return monitoringRepository;
            }
        }
        public IRepository<DeliverySetting> DeliverySettings
        {
            get
            {
                if (deliverySettingRepository == null)
                    deliverySettingRepository = new DeliverySettingRepository(db);
                return deliverySettingRepository;
            }
        }
        public IRepository<Statistic> Statistics
        {
            get
            {
                if (statisticRepository == null)
                    statisticRepository = new StatisticRepository(db);
                return statisticRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
