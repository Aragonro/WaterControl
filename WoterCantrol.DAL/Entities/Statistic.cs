using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoterCantrol.DAL.Entities
{
    public class Statistic
    {
        public int Id { get; set; }
        public DateTime MeasurementDate { get; set; }
        public int Weight { get; set; }
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}
