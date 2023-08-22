using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SmartEdu.Models
{
    public class ServerResponse<T> where T : class
    {
        public bool Succeeded { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
    }
}
