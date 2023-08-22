using Newtonsoft.Json;

namespace SmartEdu.Models
{
    public class Error
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
