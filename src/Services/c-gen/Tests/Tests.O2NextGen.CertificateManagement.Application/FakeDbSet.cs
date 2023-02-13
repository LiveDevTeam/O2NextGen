using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tests.O2NextGen.CertificateManagement.Application;

public class FakeDbSet<T> : DbSet<T>, IQueryable, IEnumerable<T> where T : class
{
    private readonly IQueryable _query;

    public FakeDbSet()
    {
        Local = new ObservableCollection<T>();
        _query = Local.AsQueryable();
    }

    public override IEntityType EntityType { get; }

    public ObservableCollection<T> Local { get; }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return Local.GetEnumerator();
    }

    Type IQueryable.ElementType => _query.ElementType;

    Expression IQueryable.Expression => _query.Expression;

    IQueryProvider IQueryable.Provider => _query.Provider;

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Local.GetEnumerator();
    }

    public virtual T Find(params object[] keyValues)
    {
        throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
    }

    public T Add(T item)
    {
        Local.Add(item);
        return item;
    }

    public T Remove(T item)
    {
        Local.Remove(item);
        return item;
    }

    public T Attach(T item)
    {
        Local.Add(item);
        return item;
    }

    public T Detach(T item)
    {
        Local.Remove(item);
        return item;
    }

    public T Create()
    {
        return Activator.CreateInstance<T>();
    }

    public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
    {
        return Activator.CreateInstance<TDerivedEntity>();
    }
}