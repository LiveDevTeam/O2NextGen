#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["O2NextGen.SmartSubscriber.Application/O2NextGen.SmartSubscriber.Application.csproj", "O2NextGen.SmartSubscriber.Application/"]
COPY ["O2NextGen.SmartSubscriber.Domain/O2NextGen.SmartSubscriber.Domain.csproj", "O2NextGen.SmartSubscriber.Domain/"]
COPY ["O2NextGen.SmartSubscriber.StartupTasks/O2NextGen.SmartSubscriber.StartupTasks.csproj", "O2NextGen.SmartSubscriber.StartupTasks/"]
COPY ["O2NextGen.SmartSubscriber.Infrastructure/O2NextGen.SmartSubscriber.Infrastructure.csproj", "O2NextGen.SmartSubscriber.Infrastructure/"]
COPY ["Tests/Tests.O2NextGen.SmartSubscriber.StartupTasks/Tests.O2NextGen.SmartSubscriber.StartupTasks.csproj", "Tests/Tests.O2NextGen.SmartSubscriber.StartupTasks/"]
RUN dotnet restore "O2NextGen.SmartSubscriber.Application/O2NextGen.SmartSubscriber.Application.csproj"
COPY . .
WORKDIR "/src/O2NextGen.SmartSubscriber.Application"
RUN dotnet build "O2NextGen.SmartSubscriber.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "O2NextGen.SmartSubscriber.Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O2NextGen.SmartSubscriber.Application.dll"]
