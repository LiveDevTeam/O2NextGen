using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace O2NextGen.CertificateManagement.Domain.UseCases.Category.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResult>
    {
        public Task<CreateCategoryCommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // grab user by id

            // setup category info

            // persist category

            // return persisted category info

            throw new NotImplementedException();
        }
    }
}