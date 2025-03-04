using test.Repository.Interface;
using System.Net.Mail;
using System.Net;
using System.Text;
using test.Models;

namespace test.Repository.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmailSender(IConfiguration configuration, IWebHostEnvironment _webHostEnvironment)
        {
            this._configuration = configuration;
            this._webHostEnvironment = _webHostEnvironment;
        }



        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            bool result = false;

            try
            {
                GetEmail getEmail = new GetEmail()
                {
                    EnableSSl = _configuration.GetValue<bool>("AppSettings:EmailSettings:EnableSSL"),
                    SecretKey = _configuration.GetValue<string>("AppSettings:SecretKey"),
                    Port = _configuration.GetValue<int>("AppSettings:EmailSettings:Port"),
                    From = _configuration.GetValue<string>("AppSettings:EmailSettings:From"),
                    SmtpServer = _configuration.GetValue<string>("AppSettings:EmailSettings:SmtpServer"),



                };


                MailMessage mailMessage = new MailMessage()
                {

                    From = new MailAddress(getEmail.From),
                    Subject = subject,
                    Body = message,
                    BodyEncoding = Encoding.UTF8,
                    IsBodyHtml = true




                };

                mailMessage.To.Add(email);



                SmtpClient smtpClient = new SmtpClient(getEmail.SmtpServer)
                {

                    Credentials = new NetworkCredential(getEmail.From, getEmail.SecretKey),
                    EnableSsl = getEmail.EnableSSl,
                    Port = getEmail.Port,


                };


                smtpClient.SendMailAsync(mailMessage);


                result = true;

            }
            catch (Exception)
            {
                return result;
            }

            return result;

        }


        public async Task<string> CreateEmailTemplate(string email)
        {
            GetEmail getEmail = new GetEmail()
            {
                Url = _configuration.GetValue<string>("AppSettings:EmailSettings:Url:ConfirmEmail"),
            };

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "Template/Email.cshtml");
            var htmlreadfile = System.IO.File.ReadAllText(path);

            htmlreadfile = htmlreadfile.Replace("{{Email}}", email);
            htmlreadfile = htmlreadfile.Replace("{{Url}}", getEmail.Url);



            return htmlreadfile;




        }
    }
}
