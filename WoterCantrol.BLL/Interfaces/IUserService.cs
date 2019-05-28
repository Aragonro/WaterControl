using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoterCantrol.BLL.DTO;

namespace WoterCantrol.BLL.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserDTO userDTO);
        UserDTO GetUser(string email);
        IEnumerable<UserDTO> GetСouriers();
        void Dispose();
    }
}
