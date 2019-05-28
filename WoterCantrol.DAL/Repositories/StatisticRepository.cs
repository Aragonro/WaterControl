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
    public class StatisticRepository : IRepository<Statistic>
    {
        private WaterControlContext db;

        public StatisticRepository(WaterControlContext context)
        {
            this.db = context;
        }

        public IEnumerable<Statistic> GetAll()
        {
            return db.Statistics;
        }

        public Statistic Get(int id)
        {
            return db.Statistics.Find(id);
        }

        public void Create(Statistic statistic)
        {
            db.Statistics.Add(statistic);
        }

        public void Update(Statistic statistic)
        {
            db.Entry(statistic).State = EntityState.Modified;
        }

        public IEnumerable<Statistic> Find(Func<Statistic, Boolean> predicate)
        {
            return db.Statistics.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Statistic statistic = db.Statistics.Find(id);
            if (statistic != null)
                db.Statistics.Remove(statistic);
        }
    }
}
