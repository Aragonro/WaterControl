using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoterCantrol.BLL.DTO
{
    public class NewAddressDTO
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int OrderId { get; set; }
    }
}
