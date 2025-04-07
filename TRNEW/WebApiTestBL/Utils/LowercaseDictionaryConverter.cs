using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApiTest.Utils
{
    public class LowercaseJsonConverter<T> : JsonConverter<T> where T : class
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
                {
                    var rootElement = doc.RootElement;
                    var dict = new Dictionary<string, JsonElement>();

                    foreach (var property in rootElement.EnumerateObject())
                    {
                        dict.Add(property.Name.ToLower(), property.Value);
                    }

                    var newJson = JsonSerializer.Serialize(dict);
                    return JsonSerializer.Deserialize<T>(newJson, options);
                }
            }

            throw new JsonException("Exception LowercaseJsonConverter");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
