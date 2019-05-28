using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoterCantrol.BLL.DTO;

namespace WoterCantrol.BLL.Interfaces
{
    public interface IMonitoringService
    {
        void CreateMonitoring(MonitoringDTO monitoringDTO);
        MonitoringDTO GetMonitoring(int id);
        MonitoringDTO GetMonitoringBySensor(int id);
        IEnumerable<MonitoringDTO> GetMonitoringsByOwner(int id);
        IEnumerable<MonitoringDTO> GetMonitoringsByObserve(int id);
        void Dispose();
    }
}
