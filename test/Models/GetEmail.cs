namespace test.Models
{
    public class GetEmail
    {
        public string SecretKey { get; set; }
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public bool EnableSSl { get; set; }
        public int Port { get; set; }
        public string Url { get; set; }
    }
}
