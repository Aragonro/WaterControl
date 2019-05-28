using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoterCantrol.BLL.DTO;

namespace WoterCantrol.BLL.Interfaces
{
    public interface IStatisticService
    {
        void CreateStatistic(StatisticDTO statisticDTO);
        void UpdateStatistic(StatisticDTO statisticDTO);
        int GetCountDrinkWaterNextDay(SensorDTO sensorDTO);
        void Dispose();
    }
}
