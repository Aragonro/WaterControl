using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoterCantrol.Models
{
    public class MonitoringViewModel
    {
        public int Id { get; set; }
        public bool IsWorking { get; set; }
        public bool IsProduct { get; set; }
        public int CountProduct { get; set; }
        public string DeliveryAddress { get; set; }
        public bool AutoDelivery { get; set; }
        public string ProductName { get; set; }
        public string ObserverEmail { get; set; }
    }
}