namespace LiteObject.App.Library.Comm
{
    public interface ICommunication
    {
        Task SendEmailAsync(string to, string from, string subject, string message);
        Task SendEmailAsync(string subject, string message);
    }
}
