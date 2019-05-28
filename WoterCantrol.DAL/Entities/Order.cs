using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoterCantrol.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal PriceSum { get; set; }
        public string Status { get; set; }
        public bool UseNewAddress { get; set; }
        public int IdAdmin { get; set; }
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int NewOrderId { get; set; }
        public NewOrder NewOrder { get; set; }
    }
}
