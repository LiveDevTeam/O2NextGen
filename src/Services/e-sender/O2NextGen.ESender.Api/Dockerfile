#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:2.2 AS build
WORKDIR /src
COPY ["Services/e-sender/O2NextGen.ESender.Api/O2NextGen.ESender.Api.csproj", "Services/e-sender/O2NextGen.ESender.Api/"]
COPY ["Services/e-sender/O2NextGen.ESender.Impl/O2NextGen.ESender.Impl.csproj", "Services/e-sender/O2NextGen.ESender.Impl/"]
COPY ["Services/e-sender/O2NextGen.ESender.Data/O2NextGen.ESender.Data.csproj", "Services/e-sender/O2NextGen.ESender.Data/"]
COPY ["Services/e-sender/O2NextGen.ESender.Business/O2NextGen.ESender.Business.csproj", "Services/e-sender/O2NextGen.ESender.Business/"]
RUN dotnet restore "Services/e-sender/O2NextGen.ESender.Api/O2NextGen.ESender.Api.csproj"
COPY . .
WORKDIR "/src/Services/e-sender/O2NextGen.ESender.Api"
RUN dotnet build "O2NextGen.ESender.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "O2NextGen.ESender.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O2NextGen.ESender.Api.dll"]