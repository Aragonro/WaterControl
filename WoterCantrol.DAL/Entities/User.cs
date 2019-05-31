using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoterCantrol.DAL.Entities
{
    public class User
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Passport { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Monitoring> Monitorings { get; set; }
        public ICollection<Sensor> Sensors { get; set; }
        public ICollection<NewOrder> NewOrders { get; set; }
    }
}
