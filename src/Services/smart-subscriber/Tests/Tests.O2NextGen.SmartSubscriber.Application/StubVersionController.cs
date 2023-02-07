using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using O2NextGen.SmartSubscriber.Application.Controllers;

namespace Tests.O2Bionics.Services.IdPortal;

public class StubVersionController : VersionController
{
    public string VersionString { get; init; }

#pragma warning disable CS8618
    public StubVersionController(IWebHostEnvironment environment,
#pragma warning restore CS8618
        // ReSharper disable once ContextualLoggerProblem
        ILogger<VersionController> logger)
        : base(environment, logger)
    {
    }

    protected override Version GetVersion() => Version.Parse(VersionString);
}