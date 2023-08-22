using Twilio.Clients;
using Twilio.Http;

namespace SmartEdu.Services.SmsService
{
    public class TwilioClient : ITwilioRestClient
    {
        private readonly ITwilioRestClient _innerClient;

        public TwilioClient(IConfiguration config, System.Net.Http.HttpClient httpClient)
        {
            // customize the underlying httpclient
            httpClient.DefaultRequestHeaders.Add("X-Custom-Header", "CustomTwilioRestClient-Demo");

            var accountSid = Environment.GetEnvironmentVariable("PHA_TW_S");
            var authToken = Environment.GetEnvironmentVariable("PHA_TW_T");

            _innerClient = new TwilioRestClient(
                "ACc7ab0d765b646e824d6c77158dbadd53",
                "1c7d043f9b4b9de076908e00f71db679",
                httpClient: new SystemNetHttpClient(httpClient));
        }

        public string AccountSid => _innerClient.AccountSid;

        public string Region => _innerClient.Region;

        public Twilio.Http.HttpClient HttpClient => _innerClient.HttpClient;

        public Response Request(Request request) => _innerClient.Request(request);

        public Task<Response> RequestAsync(Request request) => _innerClient.RequestAsync(request);
    }
}
