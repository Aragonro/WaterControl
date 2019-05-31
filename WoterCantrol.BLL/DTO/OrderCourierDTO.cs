using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoterCantrol.BLL.DTO
{
    public class OrderCourierDTO
    {
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal PriceSum { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public int IdAdmin { get; set; }
        public int SensorId { get; set; }
    }
}
