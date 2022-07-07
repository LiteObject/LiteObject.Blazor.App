using System.Text.Json.Serialization;

namespace LiteObject.App.Library.Comm.Courier.Models
{
    public class To
    {
        /// <summary>
        /// Gets or sets email.
        /// A unique email address associated to the recipient of message.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets phone number.
        /// A unique phone number associated to the recipient of message.
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets data (json).
        /// An object that includes any data you want to pass to the message. 
        /// The data will populate the corresponding template or elemental variables.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets preferences (json).
        /// An object that includes any preferences for the recipient.
        /// </summary>
        public string Preferences { get; set; }

    }
}
