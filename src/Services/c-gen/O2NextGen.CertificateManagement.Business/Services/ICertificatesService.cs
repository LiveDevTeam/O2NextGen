﻿using O2NextGen.CertificateManagement.Business.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace O2NextGen.CertificateManagement.Business.Services
{
    public interface ICertificatesService
    {
        Task<IReadOnlyCollection<Certificate>> GetAllAsync(CancellationToken ct);

        Task<Certificate> GetByIdAsync(long id, CancellationToken ct);

        Task<Certificate> UpdateAsync(Certificate certificate, CancellationToken ct);

        Task<Certificate> AddAsync(Certificate certificate, CancellationToken ct);

        Task RemoveAsync(long id, CancellationToken ct);
    }
}