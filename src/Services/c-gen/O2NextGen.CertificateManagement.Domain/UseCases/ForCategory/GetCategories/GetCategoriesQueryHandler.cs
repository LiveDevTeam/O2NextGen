﻿using MediatR;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.Data.Queries;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Domain.Mappings;

namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategories
{

    public class GetCategoriesQueryHandler
        : IRequestHandler<GetCategoriesQuery, GetCategoriesQueryResult>
    {
        private readonly IQueryHandler<CategoriesQuery, IReadOnlyCollection<Category>> queryHandler;

        public GetCategoriesQueryHandler(IQueryHandler<CategoriesQuery, IReadOnlyCollection<Category>> queryHandler)
        {
            this.queryHandler = queryHandler;
        }

        public async Task<GetCategoriesQueryResult> Handle(GetCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var certificates = await queryHandler.HandleAsync(
                new CategoriesQuery(),
                cancellationToken);

            return new GetCategoriesQueryResult(
                certificates.MapAsReadOnly(category =>
                    new GetCategoriesQueryResult.CategoryViewModel(
                        category.Id,
                        category.CategoryName,
                        category.CategoryDescription,
                        category.CategorySeries,
                        category.QuantityCertificates)));


        }
    }
}