﻿using System;
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
    public class ProductRepository : IRepository<Product>
    {
        private WaterControlContext db;

        public ProductRepository(WaterControlContext context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public void Create(Product product)
        {
            db.Products.Add(product);
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public IEnumerable<Product> Find(Func<Product, Boolean> predicate)
        {
            return db.Products.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
                db.Products.Remove(product);
        }
    }
}
