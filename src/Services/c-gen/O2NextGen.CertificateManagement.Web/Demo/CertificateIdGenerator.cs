namespace O2NextGen.CertificateManagement.Web.Demo
{
    public class CertificateIdGenerator : ICertificateIdGenerator
    {
        private long _currentId = 1;

        public long Next()
        {
            return ++_currentId;
        }
    }
}