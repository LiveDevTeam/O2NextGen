using System;
using System.Text.RegularExpressions;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Domain.Data.Queries
{
    public class CertificateQuery: IQuery<CertificateEntity>
    {

        public CertificateQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}

