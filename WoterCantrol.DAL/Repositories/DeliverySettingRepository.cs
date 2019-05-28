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
    public class DeliverySettingRepository : IRepository<DeliverySetting>
    {
        private WaterControlContext db;

        public DeliverySettingRepository(WaterControlContext context)
        {
            this.db = context;
        }

        public IEnumerable<DeliverySetting> GetAll()
        {
            return db.DeliverySettings;
        }

        public DeliverySetting Get(int id)
        {
            return db.DeliverySettings.Find(id);
        }

        public void Create(DeliverySetting deliverySetting)
        {
            db.DeliverySettings.Add(deliverySetting);
        }

        public void Update(DeliverySetting deliverySetting)
        {
            db.Entry(deliverySetting).State = EntityState.Modified;
        }

        public IEnumerable<DeliverySetting> Find(Func<DeliverySetting, Boolean> predicate)
        {
            return db.DeliverySettings.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            DeliverySetting deliverySetting = db.DeliverySettings.Find(id);
            if (deliverySetting != null)
                db.DeliverySettings.Remove(deliverySetting);
        }
    }
}
