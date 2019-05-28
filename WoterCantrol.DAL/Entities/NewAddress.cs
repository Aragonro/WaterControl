using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoterCantrol.DAL.Entities
{
    public class NewAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public ICollection<NewOrder> NewOrders { get; set; }
    }
}
