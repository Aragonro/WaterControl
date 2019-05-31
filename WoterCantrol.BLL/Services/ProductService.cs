using System;
using WoterCantrol.BLL.DTO;
using WoterCantrol.DAL.Entities;
using WoterCantrol.DAL.Interfaces;
using WoterCantrol.BLL.Infrastructure;
using WoterCantrol.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;

namespace WoterCantrol.BLL.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork Database { get; set; }

        public ProductService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateProduct(ProductDTO productDTO)
        {
            var emptyProduct = Database.Products.Find(i => i.Name == productDTO.Name).FirstOrDefault();
            if (emptyProduct != null)
            {
                throw new ValidationException("Product is exist with this name", "");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            Product product = mapper.Map<ProductDTO, Product>(productDTO);
            Database.Products.Create(product);
            Database.Save();
        }

        public ProductDTO GetProduct(string name)
        {
            var product = Database.Products.Find(i => i.Name == name).FirstOrDefault();
            if (product == null)
                throw new ValidationException("Product isn`t exist with this name", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<Product, ProductDTO>(product);
        }

        public IEnumerable<ProductDTO> GetProducts()
        { 
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
        }

        public void UpdateProduct(ProductDTO productDTO)
        {
            var oldProduct = Database.Products.Get(productDTO.Id);
            oldProduct.Count = productDTO.Count;
            Database.Products.Update(oldProduct);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
