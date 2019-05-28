using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoterCantrol.BLL.DTO;
namespace WoterCantrol.BLL.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(OrderDTO orderDTO);
        void UpdateOrder(OrderDTO orderDTO);
        OrderDTO GetOrder(int id);
        IEnumerable<OrderDTO> GetOrdersByStatus(string status);
        IEnumerable<OrderDTO> GetOrdersByCourier(int id);
        IEnumerable<OrderDTO> GetOrdersByUser(int id);
        IEnumerable<OrderDTO> GetOrdersByObserve(int id);
        void Dispose();
    }
}
