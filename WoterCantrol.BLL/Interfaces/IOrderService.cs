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
        void CreateOrder(OrderDTO orderDTO, int productId, int count);
        void UpdateOrder(OrderDTO orderDTO);
        void UpdateOrderStatus(OrderDTO orderDTO);
        OrderDTO GetOrder(int id);
        IEnumerable<OrderDTO> GetOrdersByStatus(string status);
        IEnumerable<OrderCourierDTO> GetOrdersByCourier(int id);
        IEnumerable<OrderDTO> GetOrdersByUser(int id);
        IEnumerable<OrderObserverDTO> GetOrdersByObserve(int id);
        void Dispose();
    }
}
