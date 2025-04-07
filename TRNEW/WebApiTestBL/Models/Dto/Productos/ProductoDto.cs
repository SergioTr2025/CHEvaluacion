using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApiTest.Utils;

namespace WebApiTestBL.Models.Dto.Productos
{
    public class ProductoDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("data")]
       // [JsonConverter(typeof(LowercaseJsonConverter<ProductoDataDto>))]
        public ProductoDataDto? Data { get; set; }
    }

    public class ProductoDataDto
    {

        [JsonPropertyName("color")]
        public string? Color { get; set; }

        [JsonPropertyName("capacity")]
        public string? Capacity { get; set; }

        [JsonPropertyName("Capacity")]
        public string? CapacityAlt { get; set; }

        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        [JsonPropertyName("generation")]
        public string? Generation { get; set; }

        [JsonPropertyName("CPU model")]
        public string? CPUModel { get; set; }

        [JsonPropertyName("Hard disk size")]
        public string? HardDiskSize { get; set; }

        [JsonPropertyName("Strap Colour")]
        public string? StrapColor { get; set; }

        [JsonPropertyName("Case Size")]
        public string? CaseSize { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("Screen size")]
        public double? ScreenSize { get; set; }

        [JsonPropertyName("year")]
        public int? Year { get; set; }

    }
}
