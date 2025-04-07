using WebApiTestBL.Interfaces.ProductoInterfaces;
using WebApiTestBL.Models.Dto.Productos;
using System.Collections.Generic;

namespace WebApiTest.Business
{
    public class ProductoBL : IProductoBL
    {
        private readonly IProductoService _productoService;

        public ProductoBL(IProductoService productoService)
        {
            _productoService = productoService;
        }

        public async Task<List<ListaProductosDto>> GetProductosAsync()
        {
            try
            {
                var productos = await _productoService.GetProductosAsync();

                return productos.Select(p => new ListaProductosDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Data = p.Data != null ? ConvertToDictionary(p.Data) : null
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos.", ex);
            }
        }

        private Dictionary<string, object> ConvertToDictionary(ProductoDataDto data)
        {
            var dictionary = new Dictionary<string, object>();

            if (data.Color != null) dictionary.Add("Color", data.Color);

            if (!string.IsNullOrEmpty(data.Capacity)) dictionary.Add("Capacity", data.Capacity);
            else if (!string.IsNullOrEmpty(data.CapacityAlt)) dictionary.Add("Capacity", data.CapacityAlt);

            if (data.Price.HasValue) dictionary.Add("Price", data.Price.Value);
            if (data.Generation != null) dictionary.Add("Generation", data.Generation);
            if (data.CPUModel != null) dictionary.Add("CPUModel", data.CPUModel);
            if (data.HardDiskSize != null) dictionary.Add("HardDiskSize", data.HardDiskSize);
            if (data.StrapColor != null) dictionary.Add("StrapColor", data.StrapColor);
            if (data.CaseSize != null) dictionary.Add("CaseSize", data.CaseSize);
            if (data.Description != null) dictionary.Add("Description", data.Description);
            if (data.ScreenSize.HasValue) dictionary.Add("ScreenSize", data.ScreenSize.Value);
            if (data.Year.HasValue) dictionary.Add("Year", data.Year.Value);

            return dictionary;
        }

        public async Task<DetalleProductoDto> GetDetalleProductoByIdAsync(int id)
        {
            try
            {
                var productos = await _productoService.GetDetalleProductoByIdAsync(id);

                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos.", ex);
            }
        }

        public async Task<DetalleProductoDto> CrearNuevoProductoAsync(CrearProductoDto producto)
        {
            try
            {
                var response = await _productoService.CrearNuevoProductoAsync(producto);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear producto.", ex);
            }
        }
    }
}


