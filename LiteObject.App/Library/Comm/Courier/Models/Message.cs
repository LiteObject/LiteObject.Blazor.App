namespace LiteObject.App.Library.Comm.Courier.Models
{
    public class Message
    {
        public Routing Routing { get; set; }
        public Channel[] Channels { get; set; }
        public Provider[] Providers { get; set; }
        public Metadata Metadata { get; set; }
        public To To { get; set; }
        public string Template { get; set; }
    }
}
