namespace O2NextGen.SmartSubscriber.Domain.Data;

public interface IQueryHandler<in TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
{
    Task<TQueryResult> HandleAsync(TQuery query, CancellationToken ct);
}