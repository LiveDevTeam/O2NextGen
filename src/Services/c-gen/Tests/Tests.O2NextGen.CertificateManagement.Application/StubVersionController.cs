using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using O2NextGen.CertificateManagement.Application.Controllers;

namespace Tests.O2NextGen.CertificateManagement.Application;

public class StubVersionController : VersionController
{
#pragma warning disable CS8618
    public StubVersionController(IWebHostEnvironment environment,
#pragma warning restore CS8618
        // ReSharper disable once ContextualLoggerProblem
        ILogger<VersionController> logger)
        : base(environment, logger)
    {
    }

    public string VersionString { get; init; }

    protected override Version GetVersion()
    {
        return Version.Parse(VersionString);
    }
}