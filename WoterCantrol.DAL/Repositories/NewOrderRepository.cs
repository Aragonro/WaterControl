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
    public class NewOrderRepository : IRepository<NewOrder>
    {
        private WaterControlContext db;

        public NewOrderRepository(WaterControlContext context)
        {
            this.db = context;
        }

        public IEnumerable<NewOrder> GetAll()
        {
            return db.NewOrders;
        }

        public NewOrder Get(int id)
        {
            return db.NewOrders.Find(id);
        }

        public void Create(NewOrder newOrder)
        {
            db.NewOrders.Add(newOrder);
        }

        public void Update(NewOrder newOrder)
        {
            db.Entry(newOrder).State = EntityState.Modified;
        }

        public IEnumerable<NewOrder> Find(Func<NewOrder, Boolean> predicate)
        {
            return db.NewOrders.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            NewOrder newOrder = db.NewOrders.Find(id);
            if (newOrder != null)
                db.NewOrders.Remove(newOrder);
        }
    }
}
