#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["Services/c-gen/O2NextGen.CertificateManagement.Api/O2NextGen.CertificateManagement.Api.csproj", "Services/c-gen/O2NextGen.CertificateManagement.Api/"]
COPY ["Services/c-gen/O2NextGen.CertificateManagement.Data/O2NextGen.CertificateManagement.Data.csproj", "Services/c-gen/O2NextGen.CertificateManagement.Data/"]
COPY ["Services/c-gen/O2NextGen.CertificateManagement.Impl/O2NextGen.CertificateManagement.Impl.csproj", "Services/c-gen/O2NextGen.CertificateManagement.Impl/"]
COPY ["Services/c-gen/O2NextGen.CertificateManagement.Business/O2NextGen.CertificateManagement.Business.csproj", "Services/c-gen/O2NextGen.CertificateManagement.Business/"]
RUN dotnet restore "Services/c-gen/O2NextGen.CertificateManagement.Api/O2NextGen.CertificateManagement.Api.csproj"
COPY . .
WORKDIR "/src/Services/c-gen/O2NextGen.CertificateManagement.Api"
RUN dotnet build "O2NextGen.CertificateManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "O2NextGen.CertificateManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O2NextGen.CertificateManagement.Api.dll"]