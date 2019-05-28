using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoterCantrol.BLL.DTO;
namespace WoterCantrol.BLL.Interfaces
{
    public interface ISensorService
    {
        void CreateUser(SensorDTO sensorDTO);
        SensorDTO GetSensor(int id);
        IEnumerable<SensorDTO> GetSensorsByEmail(string email);
        void Dispose();
    }
}
