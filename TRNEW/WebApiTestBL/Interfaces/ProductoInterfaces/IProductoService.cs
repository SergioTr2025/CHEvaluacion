using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTestBL.Models.Dto.Productos;

namespace WebApiTestBL.Interfaces.ProductoInterfaces
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> GetProductosAsync();
        Task<DetalleProductoDto> GetDetalleProductoByIdAsync(int id);
        Task<DetalleProductoDto> CrearNuevoProductoAsync(CrearProductoDto producto);
    }
}
