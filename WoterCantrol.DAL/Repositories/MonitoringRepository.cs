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
    public class MonitoringRepository : IRepository<Monitoring>
    {
        private WaterControlContext db;

        public MonitoringRepository(WaterControlContext context)
        {
            this.db = context;
        }

        public IEnumerable<Monitoring> GetAll()
        {
            return db.Monitorings;
        }

        public Monitoring Get(int id)
        {
            return db.Monitorings.Find(id);
        }

        public void Create(Monitoring monitoring)
        {
            db.Monitorings.Add(monitoring);
        }

        public void Update(Monitoring monitoring)
        {
            db.Entry(monitoring).State = EntityState.Modified;
        }

        public IEnumerable<Monitoring> Find(Func<Monitoring, Boolean> predicate)
        {
            return db.Monitorings.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Monitoring monitoring = db.Monitorings.Find(id);
            if (monitoring != null)
                db.Monitorings.Remove(monitoring);
        }
    }
}
