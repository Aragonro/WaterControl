using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoterCantrol.DAL.EF;
using WoterCantrol.DAL.Entities;
using WoterCantrol.DAL.Interfaces;

namespace WoterCantrol.DAL.Repositories
{
    public class SensorRepository : IRepository<Sensor>
    {
        private WaterControlContext db;

        public SensorRepository(WaterControlContext context)
        {
            this.db = context;
        }

        public IEnumerable<Sensor> GetAll()
        {
            return db.Sensors;
        }

        public Sensor Get(int id)
        {
            return db.Sensors.Find(id);
        }

        public void Create(Sensor sensor)
        {
            db.Sensors.Add(sensor);
        }

        public void Update(Sensor sensor)
        {
            db.Entry(sensor).State = EntityState.Modified;
        }

        public IEnumerable<Sensor> Find(Func<Sensor, Boolean> predicate)
        {
            return db.Sensors.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Sensor sensor = db.Sensors.Find(id);
            if (sensor != null)
                db.Sensors.Remove(sensor);
        }
    }
}
