using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoterCantrol.DAL.Entities
{
    public class Sensor
    {
        public int Id { get; set; }
        public bool IsWorking { get; set; }
        public bool IsProduct { get; set; }
        public int CountProduct { get; set; }
        public int CurrentCountProduct { get; set; }
        public string DelivaryAddress { get; set; }
        public bool UseAutomaticDelivery { get; set; }
        public int Weight { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int MonitoringId { get; set; }
        public Monitoring Monitoring { get; set; }
        public ICollection<DeliverySetting> DeliverySettings { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Statistic> Statistics { get; set; }
    }
}
