using LiteObject.App.Library.Comm.Courier;
using System.ComponentModel;
using System.Net.Mail;

namespace LiteObject.App.Library.Comm
{
    public class LiteMail : ICommunication
    {
        private readonly ILogger<CourierEmail> _logger;
        private readonly string? MailserverLogin;
        private readonly string? MailServerPassword;
        private const string SmtpServer = "smtp.gmail.com";
        private const string MailUserName = "Lite Object App";

        private const string FromEmailAddress = "lite.object@gmail.com";
        private const string ToEmailAddress = "tuniis@live.com";

        public LiteMail(ILogger<CourierEmail> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            MailserverLogin = Environment.GetEnvironmentVariable("MAIL_SERVER_LOGIN");
            MailServerPassword = Environment.GetEnvironmentVariable("MAIL_SERVER_PASSWORD");
        }

        public bool MailSent { get; private set; } = false;

        /*public static void SendEmail()
        {
            // SmtpClient
            var client = new SmtpClient(SmtpServer)
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential(MailserverLogin, MailServerPassword),
                EnableSsl = true
            };

            // Specify the email sender.
            var from = new MailAddress(MailserverLogin, MailUserName, System.Text.Encoding.UTF8);

            // Set destinations for the email message.
            var to = new MailAddress("xxxxx@daimto.com");

            // Specify the message content.
            var message = new MailMessage(@from, to)
            {
                Body = "This is a test email message sent by an application. ",
                Subject = "Customer support Daimto."
            };

            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

            // The userState can be any object that allows your callback
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            var userState = "test message1";
            client.SendAsync(message, userState);

            while (!mailSent)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }

            //clean up.
            message.Dispose();
            client.Dispose();
        }*/

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            var token = e.UserState?.ToString();

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }

            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }

            MailSent = true;
        }

        /// <summary>
        /// Original Source:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient.sendasync?view=net-6.0
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(string to, string from, string subject, string message)
        {
            // SmtpClient
            using var client = new SmtpClient(SmtpServer)
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential(MailserverLogin, MailServerPassword),
                EnableSsl = true
            };

            // Specify the email sender.
            // Create a mailing address that includes a UTF8 character in the display name.
            MailAddress fromMailAddress = new MailAddress(FromEmailAddress, "LiteObject " + (char)0xD8 + " App", System.Text.Encoding.UTF8);

            MailAddress toMailAddress = new MailAddress(ToEmailAddress);

            MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress)
            {
                Body = message
            };

            // Include some non-ASCII characters in body and subject.
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            mailMessage.Body += Environment.NewLine + someArrows;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.Subject = $"{subject} {someArrows}";
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            // Set the method that is called back when the send operation ends.
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

            /* 
             * The userState can be any object that allows your callback method to identify this send operation.
             * For this example, the userToken is a string constant.
             * 
             * string userState = $"UserState {DateTime.UtcNow}"; 
             * client.SendAsync(mailMessage, userState); 
             */

            try
            {
                await client.SendMailAsync(mailMessage);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }

        public async Task SendEmailAsync(string subject, string message)
        {
            await SendEmailAsync(ToEmailAddress, FromEmailAddress, subject, message);
        }
    }
}
