﻿using MediatR;

namespace O2NextGen.SmartSubscriber.Domain.UseCases.ForProduct.GetProduct;

public sealed class GetCategoryQuery : IRequest<GetProductQueryResult>
{
    public GetCategoryQuery(long id)
    {
        Id = id;
    }

    public long Id { get; }
    public string CategoryName { get; set; }
}