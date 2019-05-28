using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoterCantrol.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal  Price { get; set; }
        public int Weight { get; set; }
        public int Count { get; set; }
        public ICollection<Sensor> Sensors { get; set; }
        public ICollection<NewOrder> NewOrders { get; set; }
    }
}
