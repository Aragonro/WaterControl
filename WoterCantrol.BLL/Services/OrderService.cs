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
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateOrder(OrderDTO orderDTO, int productId, int count)
        {
            var product = Database.Products.Get(productId);
            if(product.Count < count)
            {
                throw new ValidationException("Don't have this count of product", "");
            }
            product.Count -= count;
            Database.Products.Update(product);
            Database.Save();
            orderDTO.Status = "open";
            orderDTO.UseNewAddress = true;
            orderDTO.PriceSum = product.Price * count;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            var order = mapper.Map< OrderDTO, Order> (orderDTO);
            Database.Orders.Create(order);
            Database.Save();
            order = Database.Orders.GetAll().Last();
            NewOrder newOrder = new NewOrder() { Count = count, OrderId = order.Id, ProductId = productId, UserId = orderDTO.UserId };
            Database.NewOrders.Create(newOrder);
            Database.Save();


        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public OrderDTO GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetOrdersByCourier(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetOrdersByObserve(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetOrdersByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetOrdersByUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(OrderDTO orderDTO)
        {
            throw new NotImplementedException();
        }
    }
}
