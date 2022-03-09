using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using O2NextGen.ESender.Business.Models;
using O2NextGen.ESender.Business.Services;

namespace O2NextGen.ESender.Impl.Services
{

    public class InMemoryEmailSenderService : IEmailSenderService
    {
        #region Fields

        private static readonly List<EmailRequestModel> Certificates = new List<EmailRequestModel>()
        {
            new EmailRequestModel()
            {
                Id = 1, From = "from@eexample.com", To = "example@eexample.com", Subject = "theme",
                Body = "<h1>last</h1>"
            }
        };

        private long _currentId;

        #endregion

        #region Ctors

        public InMemoryEmailSenderService()
        {
            _currentId = Certificates.Count();
        }

        #endregion

        #region Methods

        public async Task<IReadOnlyCollection<EmailRequestModel>> GetAllAsync(CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult<IReadOnlyCollection<EmailRequestModel>>(Certificates.AsReadOnly());
        }

        public async Task<EmailRequestModel> GetByIdAsync(long id, CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult(Certificates.SingleOrDefault(g => g.Id == id));
        }

        public async Task<EmailRequestModel> UpdateAsync(EmailRequestModel certificate, CancellationToken ct)
        {
            await Task.Delay(5000, ct);
            var toUpdate = Certificates.SingleOrDefault(g => g.Id == certificate.Id);
            if (toUpdate == null)
                return null;

            toUpdate.From = certificate.From;
            toUpdate.To = certificate.To;
            toUpdate.Subject = certificate.Subject;
            toUpdate.Body = certificate.Body;

            return await Task.FromResult(toUpdate);
        }

        public async Task<EmailRequestModel> AddAsync(EmailRequestModel certificate, CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            certificate.Id = ++_currentId;
            Certificates.Add(certificate);
            return await Task.FromResult(certificate);
        }

        public Task RemoveAsync(long id, CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}