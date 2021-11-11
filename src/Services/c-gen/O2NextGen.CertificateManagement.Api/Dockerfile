#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["O2NextGen.CertificateManagement.Api/O2NextGen.CertificateManagement.Api.csproj", "O2NextGen.CertificateManagement.Api/"]
COPY ["O2NextGen.CertificateManagement.Business/O2NextGen.CertificateManagement.Business.csproj", "O2NextGen.CertificateManagement.Business/"]
COPY ["O2NextGen.CertificateManagement.Data/O2NextGen.CertificateManagement.Data.csproj", "O2NextGen.CertificateManagement.Data/"]
COPY ["O2NextGen.CertificateManagement.Impl/O2NextGen.CertificateManagement.Impl.csproj", "O2NextGen.CertificateManagement.Impl/"]
RUN dotnet restore "O2NextGen.CertificateManagement.Api/O2NextGen.CertificateManagement.Api.csproj"
COPY . .
WORKDIR "/src/O2NextGen.CertificateManagement.Api"
RUN dotnet build "O2NextGen.CertificateManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "O2NextGen.CertificateManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O2NextGen.CertificateManagement.Api.dll"]
