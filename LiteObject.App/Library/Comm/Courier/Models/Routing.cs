namespace LiteObject.App.Library.Comm.Courier.Models
{
    public class Routing
    {
        public string Method { get; set; } = RoutingMethod.Single;
        public List<string> Channels { get; set; } = new();
    }

    public static class RoutingMethod
    {
        public const string Single = "single";
        public const string All = "all";
    }

    public static class RoutingChannel
    {
        public const string Email = "email";
        public const string Push = "push";
        public const string Sms = "sms";
    }
}