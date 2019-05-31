using System;
using WoterCantrol.BLL.DTO;
using WoterCantrol.DAL.Entities;
using WoterCantrol.DAL.Interfaces;
using WoterCantrol.BLL.Infrastructure;
using WoterCantrol.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using WoterCantrol.BLL.Constant;

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
            orderDTO.UseNewOrder = true;
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

        public OrderDTO GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderCourierDTO> GetOrdersByCourier(int id)
        {
            var orders = Database.Orders.Find(i => i.UserId == id && (i.Status == StatusesEnum.Assigne || i.Status == StatusesEnum.InProgress));
            var result = new List<OrderCourierDTO>();
            foreach(var order in orders)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IEnumerable<Order>, OrderCourierDTO>()).CreateMapper();
                var orderCourierDTO = mapper.Map<Order, OrderCourierDTO>(order);
                if (order.UseNewOrder)
                {
                    orderCourierDTO.Email = order.NewOrder.User.Email;
                }
                else
                {
                    orderCourierDTO.Email = order.Sensor.User.Email;
                }
                result.Add(orderCourierDTO);
            }
            return result;
        }

        public IEnumerable<OrderObserverDTO> GetOrdersByObserve(int id)
        {

            var orders = Database.Orders.Find(i => !(i.Sensor is null) && i.Sensor.Monitoring.UserId == id && (i.Status == StatusesEnum.Open || i.Status == StatusesEnum.Assigne || i.Status == StatusesEnum.InProgress));
            var result = new List<OrderObserverDTO>();
            foreach (var order in orders)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IEnumerable<Order>, OrderObserverDTO>()).CreateMapper();
                var orderObserverDTO = mapper.Map<Order, OrderObserverDTO>(order);
                orderObserverDTO.Email = order.Sensor.User.Email;
                result.Add(orderObserverDTO);
            }
            return result;
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

        public void UpdateOrderStatus(OrderDTO orderDTO)
        {
            var order = Database.Orders.Get(orderDTO.Id);
            order.Status = orderDTO.Status;
            order.UserId = orderDTO.UserId;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
