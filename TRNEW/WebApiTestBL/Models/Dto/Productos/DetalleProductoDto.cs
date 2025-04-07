using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApiTestBL.Models.Dto.Productos
{
    public class DetalleProductoDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("data")]
        public Dictionary<string, object> Data { get; set; }
    }
}
