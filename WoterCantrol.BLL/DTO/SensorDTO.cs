using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoterCantrol.BLL.DTO
{
    public class SensorDTO
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
        public int ProductId { get; set; }
        public int MonitoringId { get; set; }
    }
}
