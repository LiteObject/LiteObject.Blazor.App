namespace LiteObject.App.Library.Comm.Courier.Models
{
    public class Metadata
    {
        /// <summary>
        /// Gets or sets tags (array).
        /// An array of up to 9 tags you wish to associate with this request (and corresponding 
        /// messages) for later analysis. Individual tags cannot be more than 30 characters in length.
        /// </summary>
        public List<string> Tags { get; set; } = new();

        /// <summary>
        /// Gets or sets event.
        /// An arbitrary string to tracks the event that generated this request (e.g. 'signup').
        /// </summary>
        public string Event { get; set; }

        public Utm Utm { get; set; }
    }
}