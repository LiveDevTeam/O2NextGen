#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:2.2 AS build
WORKDIR /src
COPY ["Services/smalltalk/O2NextGen.SmallTalk.Api/O2NextGen.SmallTalk.Api.csproj", "Services/smalltalk/O2NextGen.SmallTalk.Api/"]
COPY ["Services/smalltalk/O2NextGen.SmallTalk.Data/O2NextGen.SmallTalk.Data.csproj", "Services/smalltalk/O2NextGen.SmallTalk.Data/"]
COPY ["Services/smalltalk/O2NextGen.SmallTalk.Business/O2NextGen.SmallTalk.Business.csproj", "Services/smalltalk/O2NextGen.SmallTalk.Business/"]
COPY ["Services/smalltalk/O2NextGen.SmallTalk.Impl/O2NextGen.SmallTalk.Impl.csproj", "Services/smalltalk/O2NextGen.SmallTalk.Impl/"]
RUN dotnet restore "Services/smalltalk/O2NextGen.SmallTalk.Api/O2NextGen.SmallTalk.Api.csproj"
COPY . .
WORKDIR "/src/Services/smalltalk/O2NextGen.SmallTalk.Api"
RUN dotnet build "O2NextGen.SmallTalk.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "O2NextGen.SmallTalk.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O2NextGen.SmallTalk.Api.dll"]