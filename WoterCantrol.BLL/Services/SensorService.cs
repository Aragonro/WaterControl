using System;
using WoterCantrol.BLL.DTO;
using WoterCantrol.DAL.Entities;
using WoterCantrol.DAL.Interfaces;
using WoterCantrol.BLL.Infrastructure;
using WoterCantrol.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace WoterCantrol.BLL.Services
{
    public class SensorService : ISensorService
    {
        IUnitOfWork Database { get; set; }

        public SensorService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void CreateSensor(SensorDTO sensorDTO, string email)
        {
            var user = Database.Users.Find(i => i.Email == email).GetEnumerator().Current;
            sensorDTO.Id = user.Id;
            sensorDTO.IsProduct = false;
            sensorDTO.IsWorking = false;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SensorDTO, Sensor>()).CreateMapper();
            Sensor sensor = mapper.Map<SensorDTO, Sensor>(sensorDTO);
            Database.Sensors.Create(sensor);
            Database.Save();
        }

        public SensorDTO GetSensor(int id)
        {
            var sensor = Database.Sensors.Get(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Sensor, SensorDTO>()).CreateMapper();
            return mapper.Map<Sensor, SensorDTO>(sensor);
        }

        public IEnumerable<SensorDTO> GetSensorsByEmail(string email)
        {
            var user = new UserService(Database).GetUser(email);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Sensor, SensorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Sensor>, List<SensorDTO>>(Database.Sensors.Find(s => s.UserId == user.Id));
        }

        public void UpdateSensor(SensorDTO sensorDTO)
        {
            var oldSensor = Database.Sensors.Get(sensorDTO.Id);
            oldSensor.CountProduct = sensorDTO.CountProduct;
            oldSensor.CurrentCountProduct = sensorDTO.CurrentCountProduct;
            oldSensor.DelivaryAddress = sensorDTO.DelivaryAddress;
            oldSensor.IsProduct = sensorDTO.IsProduct;
            oldSensor.IsWorking = sensorDTO.IsWorking;
            oldSensor.MonitoringId = sensorDTO.MonitoringId;
            oldSensor.ProductId = sensorDTO.ProductId;
            oldSensor.Weight = sensorDTO.Weight;
            oldSensor.UseAutomaticDelivery = sensorDTO.UseAutomaticDelivery;
            Database.Sensors.Update(oldSensor);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
