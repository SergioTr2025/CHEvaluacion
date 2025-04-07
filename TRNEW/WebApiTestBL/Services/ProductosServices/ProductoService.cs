using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApiTestBL.Models.Dto.Productos;
using WebApiTestBL.Interfaces.ProductoInterfaces;
using System.Text;

namespace WebApiTestBL.Services.ProductosServices
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _httpClient;

        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductoDto>> GetProductosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://api.restful-api.dev/objects");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al obtener los productos. StatusCode: {response.StatusCode}");
                }

                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                //var productos = JsonSerializer.Deserialize<List<ProductoDto>>(responseBody, options);
                var productos = JsonSerializer.Deserialize<List<ProductoDto>>(responseBody);

                if (productos == null)
                {
                    throw new Exception("Error al deserializar respuesta de la API.");
                }

                return productos;
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception("Error al conectar con la API externa.", httpEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la respuesta de la API.", ex);
            }
        }
    
        
        public async Task<DetalleProductoDto> GetDetalleProductoByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception($"Error, eL Id no es valido");
                }

                var response = await _httpClient.GetAsync("https://api.restful-api.dev/objects/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al obtener los productos. StatusCode: {response.StatusCode}");
                }

                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                //var productos = JsonSerializer.Deserialize<List<ProductoDto>>(responseBody, options);
                var productos = JsonSerializer.Deserialize<DetalleProductoDto>(responseBody);

                if (productos == null)
                {
                    throw new Exception("Error al deserializar respuesta de la API.");
                }

                return productos;
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception("Error al conectar con la API externa.", httpEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la respuesta de la API.", ex);
            }
        }

        public async Task<DetalleProductoDto> CrearNuevoProductoAsync(CrearProductoDto producto)
        {
            try
            {
                if (string.IsNullOrEmpty(producto.Name))
                {
                    throw new Exception("Nombre Invalido");
                }
                if (producto.Data == null)
                {
                    producto.Data = new Dictionary<string, object>();
                }
                var json = JsonSerializer.Serialize(producto, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase, 
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull 
                });

                var response = await _httpClient.PostAsync("https://api.restful-api.dev/objects",
                    new StringContent(json, Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al crear producto. StatusCode: {response.StatusCode}");
                }

                var responseBody = await response.Content.ReadAsStringAsync();

                var productoCreado = JsonSerializer.Deserialize<DetalleProductoDto>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (productoCreado == null)
                {
                    throw new Exception("Error al deserializar");
                }

                return productoCreado;
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception("Error", httpEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear producto.", ex);
            }
        }



    }
}

