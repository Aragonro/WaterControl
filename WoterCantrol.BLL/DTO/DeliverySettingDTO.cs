using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoterCantrol.BLL.DTO
{
    public class DeliverySettingDTO
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public DateTime? TimeDeliveryFrom { get; set; }
        public DateTime? TimeDeliveryTo { get; set; }
        public int SensorId { get; set; }
    }
}
