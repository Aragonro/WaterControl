using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoterCantrol.DAL.Entities
{
    public class Monitoring
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}
