#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/IdPortal.App.MvcClient/IdPortal.App.MvcClient.csproj", "src/IdPortal.App.MvcClient/"]
RUN dotnet restore "src/IdPortal.App.MvcClient/IdPortal.App.MvcClient.csproj"
COPY . .
WORKDIR "/src/src/IdPortal.App.MvcClient"
RUN dotnet build "IdPortal.App.MvcClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdPortal.App.MvcClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdPortal.App.MvcClient.dll"]
