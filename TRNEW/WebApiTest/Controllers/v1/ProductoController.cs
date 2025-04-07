using Microsoft.AspNetCore.Mvc;
using WebApiTestBL.Interfaces.ProductoInterfaces;
using WebApiTestBL.Models.Dto.Productos;

namespace WebApiTest.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoBL _productoBL;

        public ProductoController(IProductoBL productoBL)
        {
            _productoBL = productoBL;
        }

        [HttpGet]
        [Route("/api/dispositivos/")]
        public async Task<ActionResult<IEnumerable<ListaProductosDto>>> GetProductosAsync()
        {
            try
            {
                var productos = await _productoBL.GetProductosAsync();

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener la lista de productos.", error = ex.Message });
            }
        }

        [HttpGet]
        [Route("/api/dispositivos/{id}")]
        public async Task<ActionResult<DetalleProductoDto>> GetDetalleProductoByIdAsync(int id)
        {
            try
            {
                var producto = await _productoBL.GetDetalleProductoByIdAsync(id);

                if (producto == null) 
                {
                     return NotFound(new { mensaje = "No se encontro producto" });
                }

                return Ok(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener el producto", error = ex.Message });
            }
        }

        [HttpPost]
        [Route("/api/dispositivos/")]
        public async Task<ActionResult> CrearNuevoProductoAsync([FromBody] CrearProductoDto productoDto)
        {
            try
            {
                if (string.IsNullOrEmpty(productoDto.Name))
                {
                    return BadRequest(new { mensaje = "El nombre es requerido." });
                }
                var productoCreado = await _productoBL.CrearNuevoProductoAsync(productoDto);

                return Ok(new { message = "Dispositivo creado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al crear el dispositivo.", error = ex.Message });
            }
        }

    }
}
