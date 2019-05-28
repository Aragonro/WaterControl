using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoterCantrol.BLL.DTO;

namespace WoterCantrol.BLL.Interfaces
{
    public interface INewAddressService
    {
        void CreateNewAddress(NewAddressDTO newAddressDTO);
        NewAddressDTO GetNewAddress(int id);
        void Dispose();
    }
}
