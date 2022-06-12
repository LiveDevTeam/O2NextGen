#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:2.2 AS build
WORKDIR /src
COPY ["Services/media-basket/O2NextGen.MediaBasket.Api/O2NextGen.MediaBasket.Api.csproj", "Services/media-basket/O2NextGen.MediaBasket.Api/"]
COPY ["Services/media-basket/O2NextGen.MediaBasket.Impl/O2NextGen.MediaBasket.Impl.csproj", "Services/media-basket/O2NextGen.MediaBasket.Impl/"]
COPY ["Services/media-basket/O2NextGen.MediaBasket.Business/O2NextGen.MediaBasket.Business.csproj", "Services/media-basket/O2NextGen.MediaBasket.Business/"]
COPY ["Services/media-basket/O2NextGen.MediaBasket.Data/O2NextGen.MediaBasket.Data.csproj", "Services/media-basket/O2NextGen.MediaBasket.Data/"]
COPY ["SDKs/O2NG.Sdk.NetCore/O2NG.Sdk.NetCore.Models/O2NextGen.Sdk.NetCore.Models.csproj", "SDKs/O2NG.Sdk.NetCore/O2NG.Sdk.NetCore.Models/"]
RUN dotnet restore "Services/media-basket/O2NextGen.MediaBasket.Api/O2NextGen.MediaBasket.Api.csproj"
COPY . .
WORKDIR "/src/Services/media-basket/O2NextGen.MediaBasket.Api"
RUN dotnet build "O2NextGen.MediaBasket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "O2NextGen.MediaBasket.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O2NextGen.MediaBasket.Api.dll"]