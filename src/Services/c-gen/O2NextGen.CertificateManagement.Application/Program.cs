using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using O2NextGen.CertificateManagement.Application;
using O2NextGen.CertificateManagement.Application.Helpers;
using O2NextGen.CertificateManagement.Application.IoC;
using O2NextGen.CertificateManagement.Infrastructure.Data;
using O2NextGen.CertificateManagement.StartupTasks.DatabaseInitializer;

 string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var environment = builder.Environment;
 
 var identityUrl = builder.Configuration.GetValue<string>("UrlsConfig:IdentityUrl");
 builder.Services.AddCors(options =>
 {
     options.AddPolicy("CorsPolicy",
         builder => builder
             .AllowAnyMethod()
             .AllowAnyHeader()
             .SetIsOriginAllowed((host) => true)
             .AllowCredentials());
 });

// Add services to the container.
builder.Services.AddMvc(_ =>
{
    _.EnableEndpointRouting = false;
});
builder.Services.AddEndpointsApiExplorer();
 
builder.Services.AddApiVersioning(o =>
{
    o.ReportApiVersions = true;
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
});

// prevent from mapping "sub" claim to nameidentifier.
//JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddCustomIntegrations(configuration);
 // var tokenValidationParameters = new TokenValidationParameters
 // {
 //
 //     RequireExpirationTime = true,
 //     RequireSignedTokens = false,
 //     ValidateIssuerSigningKey = true,
 //     ValidateIssuer = true,
 //     ValidIssuer = "cgen.api",
 //     ValidateAudience = true,
 //     ValidAudience = identityUrl,
 //     ValidateLifetime = false,
 //     ClockSkew = TimeSpan.Zero
 // };
 builder.Services
     .AddAuthentication("Bearer")
     .AddJwtBearer("Bearer", options =>
     {
     // identity server issuing token
     // options.Audience = "cgen.api";
     // // options.ClaimsIssuer = "https://sts.windows.net/a1d50521-9687-4e4d-a76d-ddd53ab0c668/";
     options.RequireHttpsMetadata= false;
     options.Authority = builder.Configuration.GetValue<string>("UrlsConfig:IdentityUrl");
     options.TokenValidationParameters = new TokenValidationParameters()
     {
         ValidateAudience = false,
     };
     // allow self-signed SSL certs
     options.BackchannelHttpHandler = new HttpClientHandler
     {
         ServerCertificateCustomValidationCallback = delegate { return true; }
     };
     
     options.IncludeErrorDetails = true;
     options.Audience = "cgen.api";
     // options.TokenValidationParameters = tokenValidationParameters;
     // options.SaveToken = true;
     // options.RequireHttpsMetadata = false;
         // options.SaveToken = true;
         // options.RequireHttpsMetadata = true;
         // // options.TokenValidationParameters.NameClaimType = "name";
         // // options.TokenValidationParameters.RoleClaimType = "role";
         // options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
         // {
         //     ValidateAudience = true,
         //     // ValidAudience = "cgen.api",
         //
         //     // ValidateIssuer = true,
         //     // //ValidIssuers = new[] { identityUrl },
         //     //
         //     // ValidateIssuerSigningKey = true,
         //     // //IssuerSigningKeys = openidconfig.SigningKeys,
         //     //
         //     // RequireExpirationTime = true,
         //     // ValidateLifetime = true,
         //     // RequireSignedTokens = true,
         // };
         //
         // options.RequireHttpsMetadata = false;
         //
         // options.IncludeErrorDetails = true;
         // {
         //     ValidIssuer = tokenOptions.Issuer,
         //     ValidAudience = tokenOptions.Audience,
         //     IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
         //     ClockSkew = TimeSpan.Zero 
         // };
     // allow self-signed SSL certs
     options.BackchannelHttpHandler = new HttpClientHandler
     {
         ServerCertificateCustomValidationCallback = delegate { return true; }
     };
     //        
     // // the scope id of this api
     options.Audience = "cgen.api";
 });
//
 // // builder.Services.AddAuthorization();
 // builder.Services.AddAuthorization(options =>
 // {
 //     options.AddPolicy("ApiScope", policy =>
 //     {
 //         policy.RequireAuthenticatedUser();
 //         policy.RequireClaim("scope", "mango");
 //     });
 // });
builder.Services.AddAuthorization(auth =>
{
    // auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
    //     .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
    //     .RequireAuthenticatedUser().Build());
});
 

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//             
// }).AddJwtBearer(options =>
// {
//     // identity server issuing token
//     options.Authority = Configuration.GetValue<string>("Urls:IdentityUrl");
//     
//     options.RequireHttpsMetadata = false;
//             
//     // allow self-signed SSL certs
//     options.BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };
//             
//     // the scope id of this api
//     options.Audience = "smalltalkapi";
// });

builder.Services.AddSwaggerGen(options =>
{
    var scheme = new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri($"{identityUrl}/connect/authorize"),
                TokenUrl = new Uri($"{identityUrl}/connect/token"),
        }},
        Type = SecuritySchemeType.OAuth2
    };
    
    options.SwaggerDoc("v1.1", 
        new OpenApiInfo
        {
            Title = "Versioned Api v1.1", Version = "v1.1"
        });
    options.SwaggerDoc("v1.0",
        new OpenApiInfo
        {
            Title = "Versioned Api v1.0",
            Version = "v1.0"
        }
    );
    options.DescribeAllParametersInCamelCase();
     
    // Apply the filters
    options.OperationFilter<RemoveVersionFromParameter>();
    options.DocumentFilter<ReplaceVersionWithExactValueInPath>();

    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        var actionApiVersionModel = apiDesc.ActionDescriptor?.GetApiVersion();

        if (actionApiVersionModel == null) return true;

        return actionApiVersionModel.DeclaredApiVersions.Any()
            ? actionApiVersionModel.DeclaredApiVersions.Any(v => $"v{v.ToString()}" == docName)
            : actionApiVersionModel.ImplementedApiVersions.Any(v => $"v{v.ToString()}" == docName);
    });
    options.AddSecurityDefinition("OAuth", scheme);

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { 
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Id = "OAuth", Type = ReferenceType.SecurityScheme }
            }, 
            new List<string> { } 
        }
    });
    // options.AddSecurityRequirement(new OpenApiSecurityRequirement() {  
    //     {  
    //         new OpenApiSecurityScheme {  
    //             Reference = new OpenApiReference {  
    //                 Type = ReferenceType.SecurityScheme,  
    //                 Id = "oauth2"  
    //             },  
    //             Scheme = "oauth2",  
    //             Name = "oauth2",  
    //             In = ParameterLocation.Header  
    //         },  
    //         new List <string> ()  
    //     }  
    // }); 
    // options.OperationFilter<AuthorizeCheckOperationFilter>();
    // options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    // {
    //     Type = SecuritySchemeType.OAuth2,
    //     Flows = new OpenApiOAuthFlows
    //     {
    //         Implicit = new OpenApiOAuthFlow
    //         {
    //             //AuthorizationUrl = new Uri("your-auth-url", UriKind.Relative),
    //             
    //             AuthorizationUrl = new Uri($"{identityUrl}/connect/authorize"),
    //             TokenUrl = new Uri($"{identityUrl}/connect/token"),
    //             Scopes = new Dictionary<string, string>
    //             {
    //                 { "cgen.api", "CGen Api" }
    //             },
    //         }
    //     }
    // });
    // options.AddSecurityDefinition("oauth2", new OAuth2Scheme
    // {
    //     Type = "oauth2",
    //     Flow = "implicit",
    //     AuthorizationUrl = $"{Configuration.GetValue<string>("Urls:IdentityUrl")}/connect/authorize",
    //     TokenUrl = $"{Configuration.GetValue<string>("Urls:IdentityUrl")}/connect/token",
    //     Scopes = new Dictionary<string, string>()
    //     {
    //         { "smalltalkapi", "SmallTalk Api" }
    //     }
    //
    // });
});
builder.Services
    .AddConfigEf(configuration)
    .AddDatabaseInitializer<CGenDbContext>()
    .AddBusiness()
    .AddInfrastructure();

var app = builder.Build();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<CGenDbContext>();
SeedData.SeedAsync(context, configuration).Wait();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}


app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers.Add("X-Powered-By", "O2NextGen Platform");
        return Task.CompletedTask;
    });

    await next.Invoke();
});

app.UseHttpsRedirection();
 app.UseCors("CorsPolicy");
app.UseRouting();
 if (builder.Configuration["IsTests"] == bool.TrueString.ToLowerInvariant())
 {
     app.UseMiddleware<AutoAuthorizeMiddleware>();
 }
 else
 {
     app.UseAuthentication();
 }
 
 
 app.UseSwagger();
 app.UseSwaggerUI(options =>
 {
     
     options.SwaggerEndpoint("/swagger/v1.1/swagger.json", "O2Certificate Management API V1.1");
     options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "O2Certificate Management API V1.0");
     options.OAuthClientId("cgenswaggerui");
     options.OAuthScopes("profile", "openid", "cgen.api");
     options.OAuthUsePkce();
     options.EnablePersistAuthorization();
 });
 app.UseMvc();
 app.Run();

namespace O2NextGen.CertificateManagement.Application
{
    public partial class Program
    {
    }
    
    // protected override void ConfigureAuth(IApplicationBuilder app)
    // {
    //     if (Configuration["isTest"] == bool.TrueString.ToLowerInvariant())
    //     {
    //         app.UseMiddleware<AutoAuthorizeMiddleware>();
    //     }
    //     else
    //     {
    //         base.ConfigureAuth(app);
    //     }
    // }
}