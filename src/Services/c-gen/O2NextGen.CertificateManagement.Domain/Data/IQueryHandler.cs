using System.Threading;
using System.Threading.Tasks;

namespace O2NextGen.CertificateManagement.Domain.Data
{
    public interface IQueryHandler<in TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
    {
        Task<TQueryResult> HandleAsync(TQuery query, CancellationToken ct);
    }
}

