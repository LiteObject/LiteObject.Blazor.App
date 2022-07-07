namespace LiteObject.App.Library.Comm.Courier.Models
{
    /// <summary>
    /// Identify the campaign that refers traffic to a specific website, 
    /// and attributes the browser's website session.
    /// </summary>
    public class Utm
    {
        public string Campaign { get; set; }

        public string Content { get; set; }

        public string Medium { get; set; }

        public string Source { get; set; }

        public string Term { get; set; }
    }
}
