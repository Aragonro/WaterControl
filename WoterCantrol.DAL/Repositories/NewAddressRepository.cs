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
    public class NewAddressRepository : IRepository<NewAddress>
    {
        private WaterControlContext db;

        public NewAddressRepository(WaterControlContext context)
        {
            this.db = context;
        }

        public IEnumerable<NewAddress> GetAll()
        {
            return db.NewAddresses;
        }

        public NewAddress Get(int id)
        {
            return db.NewAddresses.Find(id);
        }

        public void Create(NewAddress newAddress)
        {
            db.NewAddresses.Add(newAddress);
        }

        public void Update(NewAddress newAddress)
        {
            db.Entry(newAddress).State = EntityState.Modified;
        }

        public IEnumerable<NewAddress> Find(Func<NewAddress, Boolean> predicate)
        {
            return db.NewAddresses.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            NewAddress newAddress = db.NewAddresses.Find(id);
            if (newAddress != null)
                db.NewAddresses.Remove(newAddress);
        }
    }
}
