using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.CertificateManagement.Application.Controllers;

namespace O2NextGen.CertificateManagement.Application.Features.Categories
{
    [Route("api/[controller]")]
    public class CategoriesControlller : ControllerBase
    {
        #region Fields

        private readonly IMediator mediator;
        private readonly ILogger<CertificatesController> logger;

        #endregion


        #region Ctors

        public CategoriesControlller(IMediator mediator, ILogger<CertificatesController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        #endregion


        #region Methods
        
        #endregion
    }
}

