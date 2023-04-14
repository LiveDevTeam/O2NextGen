namespace O2NextGen.ESender.Data.Entities
{
    public interface ISmtpSetting
    {
        string OverrideEmail { get; set; }

        string EnvironmentName { get; set; }

        string Server { get; set; }

        int Port { get; set; }

        string Email { get; set; }

        string Password { get; set; }

        bool UseSSL { get; set; }
    }
    
    public class SmtpSetting : ISmtpSetting
    {
        public string OverrideEmail { get; set; }

        public string EnvironmentName { get; set; }

        public string Server { get; set; }

        public int Port { get; set; }

        public string Email { get; set; }

        public string EmailName { get; set; }

        public string Password { get; set; }

        public bool UseSSL { get; set; }
    }
}