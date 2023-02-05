#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PFRCentr.App.MvcClient/PFRCentr.App.MvcClient.csproj", "src/PFRCentr.App.MvcClient/"]
RUN dotnet restore "src/PFRCentr.App.MvcClient/PFRCentr.App.MvcClient.csproj"
COPY . .
WORKDIR "/src/src/PFRCentr.App.MvcClient"
RUN dotnet build "PFRCentr.App.MvcClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PFRCentr.App.MvcClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PFRCentr.App.MvcClient.dll"]
