#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["O2NextGen.OnTracker.Api/O2NextGen.OnTracker.Api.csproj", "O2NextGen.OnTracker.Api/"]
COPY ["O2NextGen.OnTracker.Business/O2NextGen.OnTracker.Business.csproj", "O2NextGen.OnTracker.Business/"]
COPY ["O2NextGen.OnTracker.Data/O2NextGen.OnTracker.Data.csproj", "O2NextGen.OnTracker.Data/"]
COPY ["O2NextGen.OnTracker.Impl/O2NextGen.OnTracker.Impl.csproj", "O2NextGen.OnTracker.Impl/"]
COPY ["O2NextGen.Tracker.DbUtility/O2NextGen.Tracker.DbUtility.csproj", "O2NextGen.Tracker.DbUtility/"]
RUN dotnet restore "O2NextGen.OnTracker.Api/O2NextGen.OnTracker.Api.csproj"
COPY . .
WORKDIR "/src/O2NextGen.OnTracker.Api"
RUN dotnet build "O2NextGen.OnTracker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "O2NextGen.OnTracker.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O2NextGen.OnTracker.Api.dll"]
