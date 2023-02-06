using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Tests.O2Bionics.Services.IdPortal;

public class VersionControllerTests
{
    [Test]
    public void VersionController_GetVersion_Test()
    {
        var moq = new Mock<IWebHostEnvironment>();
        var loggerMoq = new Mock<ILogger<StubVersionController>>();
        var stub = new StubVersionController(moq.Object, loggerMoq.Object)
        {
            VersionString = "1.0.0.0"
        };

        var result  = stub.Index();
        
        // Assert
        Assert.NotNull(result);
    }
}