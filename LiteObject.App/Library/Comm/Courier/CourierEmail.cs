using LiteObject.App.Library.Comm.Courier.Models;
using System.Text;

namespace LiteObject.App.Library.Comm.Courier
{
    public class CourierEmail : ICommunication
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CourierEmail> _logger;

        public CourierEmail(ILogger<CourierEmail> logger, HttpClient httpClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("https://api.courier.com/send");
        }

        public async Task SendEmailAsync(string to, string from, string subject, string message)
        {
            var token = "Bearer ...";

            // attach the Auth Token
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

            // construct the JSON Payload to send to the API
            // string payload = "{ \"message\": { \"routing\": {\"method\": \"single\",\"channels\": []},\"channels\": {},\"providers\": {},\"metadata\": {\"tags\": [],\"utm\": {}     }, \"to\": {\"data\": {},\"preferences\": {},\"email\": \"YOUR-EMAIL-ADDRESS\"},\"template\": \"YOUR-TEMPLATE-NOTIFICATION-ID\"}}";

            var payload = new Payload();
            payload.Message.Routing.Method = RoutingMethod.Single;
            payload.Message.Routing.Channels.Add(RoutingChannel.Email);


            // construct the JSON Post
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            var httpResponseMessage = await _httpClient.PostAsync("/", content);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.LogInformation("");
            }
            else
            {
                _logger.LogError($"StatusCode: {httpResponseMessage.StatusCode}");
            }
        }

        public Task SendEmailAsync(string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}
