using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using O2NextGen.CertificateManagement.Application.Controllers.Features.Categories;
using Tests.O2NextGen.CertificateManagement.Application.Base;

namespace Tests.O2NextGen.CertificateManagement.Application.Controllers.Features.Categories;

[TestFixture]
public class CategoriesControllerTests
    : BaseControllerTests<CategoriesController>
{
    #region Tests for Attributes

    [Test]
    [TestCase("CategoriesController")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }

    [Test]
    public void ControllerBaseTests_AttributeApiVersion_Supported_v1_0()
    {
        Assert.IsTrue(
            Attribute.GetCustomAttributes(typeof(CategoriesController), typeof(ApiVersionAttribute)).Any(att =>
                ((ApiVersionAttribute) att).Versions.Any(x => x.MajorVersion == 1 && x.MinorVersion == 0)));
    }

    [Test]
    public void ControllerBaseTests_AttributeApiVersion_Supported_v1_1()
    {
        Assert.IsTrue(
            Attribute.GetCustomAttributes(typeof(CategoriesController), typeof(ApiVersionAttribute)).Any(att =>
                ((ApiVersionAttribute) att).Versions.Any(x => x.MajorVersion == 1 && x.MinorVersion == 1)));
    }

//
//     #endregion
//
//     #region Tests for Logging Methods
//
//      [Test]
//     public async Task CategoryControllerTests_GetById_LoggerInfo_Tests()
//     {
//         //Arrange
//         var mediator = new Mock<IMediator>();
//         
//         CancellationTokenSource cts = new();
//         
//         var cancellationToken = cts.Token;
//
//         var categoryQueryResult = new Mock<GetCategoryQueryResult>();
//         
//         mediator.Setup(_ => _.Send(It.IsAny<GetCategoryQuery>(), cancellationToken))
//             .Returns(() => Task.FromResult(
//                 It.IsAny<GetCategoryQueryResult>()
//             ));
//         
//         var logger = new Mock<ILogger<CategoriesController>>();
//
//         // Act
//         var controller = new CategoriesController(mediator.Object, logger.Object);
//         const long id = 1;
//         var result = await controller.GetByIdAsync(id, cancellationToken);
//
//         // Asser 
//         logger.VerifyLog(_ => _.LogInformation(It.IsAny<string>()));
//         logger.VerifyLog(_ => _.LogInformation(It.IsNotNull<string>()));
//         logger.VerifyLog(_ => _.LogInformation(It.Is<string>(msg => msg.Length > 0)));
//         logger.VerifyLog(_ => _.LogInformation("Call API method {ByIdAsyncName}: id = {Id}", "GetByIdAsync", id));
//     }
//     
//      [Test]
//     public async Task CategoryControllerTests_GetById_Ok_LoggerInfo_Tests()
//     {
//         //Arrange
//         var mediator = new Mock<IMediator>();
//         
//         CancellationTokenSource cts = new();
//         
//         var cancellationToken = cts.Token;
//
//         var categoryQueryResult = new Mock<GetCategoryQueryResult>();
//         
//         mediator.Setup(_ => _.Send(It.IsAny<GetCategoryQuery>(), cancellationToken))
//             .Returns(() => Task.FromResult(
//                 It.IsAny<GetCategoryQueryResult>()
//             ));
//         
//         var logger = new Mock<ILogger<CategoriesController>>();
//
//         // Act
//         var controller = new CategoriesController(mediator.Object, logger.Object);
//         const long id = 1;
//         var result = await controller.GetByIdAsync(id, cancellationToken);
//
//         // Asser 
//         logger.VerifyLog(_ => _.LogInformation(It.IsAny<string>()));
//         logger.VerifyLog(_ => _.LogInformation(It.IsNotNull<string>()));
//         logger.VerifyLog(_ => _.LogInformation(It.Is<string>(msg => msg.Length > 0)));
//         logger.VerifyLog(_ => _.LogInformation("GetByIdAsync: OK"));
//     }
//     
//      [Test]
//     public async Task CategoryControllerTests_GetById_LoggerError_Tests()
//     {
//         //Arrange
//         var mediator = new Mock<IMediator>();
//         CancellationTokenSource cts = new();
//         CancellationToken cancellationToken = cts.Token;
//
//         var categoryQueryResult = new Mock<GetCategoryQueryResult>();
//         mediator.Setup(_ => _.Send(It.IsAny<GetCategoryQuery>(), cancellationToken))
//             .Returns(() => Task.FromResult(
//                 null as GetCategoryQueryResult
//             ));
//         // .Returns(Task.Run(async () => { await Task.Delay(1000, cancellationToken) }, cancellationToken))  
//         // .Callback<GetCategoryQuery, string>((roles, databaseName) =>  
//         // {  
//         //     cts.Cancel();  
//         // });  
//         var logger = new Mock<ILogger<CategoriesController>>();
//
//         // Act
//         var controller = new CategoriesController(mediator.Object, logger.Object);
//         const long id = 1;
//         var result = await controller.GetByIdAsync(id, cancellationToken);
//
//         // Asser 
//         logger.VerifyLog(_ => _.LogError(It.IsAny<string>()));
//         logger.VerifyLog(_ => _.LogError(It.IsNotNull<string>()));
//         logger.VerifyLog(_ => _.LogError(It.Is<string>(msg => msg.Length > 0)));
//         logger.VerifyLog(_ => _.LogError("GetByIdAsync: not found  id = {Id}", id));
//     }
//
//     #endregion
//
//     #region Tests for Func Methods
//
//      [Test]
//     public async Task CategoryControllerTests_GetById_Test()
//     {
//         //Arrange
//         var mediator = new Mock<IMediator>();
//         
//         CancellationTokenSource cts = new();
//         
//         var cancellationToken = cts.Token;
//
//         var expectedResult = new GetCategoryQueryResult(
//             id: 1,
//             modifiedDate: 1,
//             addedDate: 1,
//             deletedDate: 1,
//             isDeleted: false,
//             customerId: "1",
//             categoryName: "categoryName",
//             categoryDescription: "categoryDescription",
//             quantityCertificates: 1,
//             quantityPublishCode: 1,
//             categorySeries: "categorySeries"
//         );
//         
//         mediator.Setup(_ => _.Send(It.IsAny<GetCategoryQuery>(), cancellationToken))
//             .Returns(() => Task.FromResult(
//                 expectedResult
//             ));
//         
//         var logger = new Mock<ILogger<CategoriesController>>();
//         
//         // Act
//         var controller = new CategoriesController(mediator.Object, logger.Object);
//         const long id = 1;
//         var actionResult = await controller.GetByIdAsync(id, cancellationToken);
//         var okObjectResult = actionResult as OkObjectResult;
//
//         // Assert
//         Assert.NotNull(okObjectResult);
//         Assert.Equal(expectedResult,okObjectResult?.Value);
//     }
//     
//

    #endregion
}