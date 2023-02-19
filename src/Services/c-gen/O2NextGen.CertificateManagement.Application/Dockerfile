#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt-get update && apt-get install -y libgdiplus
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["O2NextGen.CertificateManagement.Application/O2NextGen.CertificateManagement.Application.csproj", "O2NextGen.CertificateManagement.Application/"]
COPY ["O2NextGen.CertificateManagement.Domain/O2NextGen.CertificateManagement.Domain.csproj", "O2NextGen.CertificateManagement.Domain/"]
COPY ["O2NextGen.CertificateManagement.Infrastructure/O2NextGen.CertificateManagement.Infrastructure.csproj", "O2NextGen.CertificateManagement.Infrastructure/"]
COPY ["O2NextGen.CertificateManagement.StartupTasks/O2NextGen.CertificateManagement.StartupTasks.csproj", "O2NextGen.CertificateManagement.StartupTasks/"]
RUN dotnet restore "O2NextGen.CertificateManagement.Application/O2NextGen.CertificateManagement.Application.csproj"
COPY . .
WORKDIR "/src/O2NextGen.CertificateManagement.Application"
RUN dotnet build "O2NextGen.CertificateManagement.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "O2NextGen.CertificateManagement.Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O2NextGen.CertificateManagement.Application.dll"]
