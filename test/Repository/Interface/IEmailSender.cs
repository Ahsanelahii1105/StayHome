

namespace test.Repository.Interface
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(string email, string subject, string message);

        Task<string> CreateEmailTemplate(string email);
    }
}
