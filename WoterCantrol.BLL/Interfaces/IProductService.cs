using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoterCantrol.BLL.DTO;
namespace WoterCantrol.BLL.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(ProductDTO productDTO);
        ProductDTO GetProduct(string name);
        void UpdateProduct(ProductDTO productDTO);
        void Dispose();
    }
}
