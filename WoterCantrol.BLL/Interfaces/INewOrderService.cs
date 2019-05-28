using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoterCantrol.BLL.DTO;

namespace WoterCantrol.BLL.Interfaces
{
    public interface INewOrderService
    {
        void CreateNewOrder(NewOrderDTO newOrderDTO);
        NewOrderDTO GetNewOrder(int id);
        void Dispose();
    }
}
