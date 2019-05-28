using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoterCantrol.BLL.DTO;

namespace WoterCantrol.BLL.Interfaces
{
    public interface IDeliverySettingService
    {
        void CreateDeliverySetting(DeliverySettingDTO deliverySettingDTO);
        DeliverySettingDTO GetDeliverySettingBySensor(int id);
        void UpdateDeliverySettingBySensor(int id, DeliverySettingDTO deliverySettingDTO);
        void Dispose();
    }
}
