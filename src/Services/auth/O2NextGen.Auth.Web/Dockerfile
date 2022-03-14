#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:2.2 AS build
WORKDIR /src
COPY ["Services/auth/O2NextGen.Auth.Web/O2NextGen.Auth.Web.csproj", "Services/auth/O2NextGen.Auth.Web/"]
RUN dotnet restore "Services/auth/O2NextGen.Auth.Web/O2NextGen.Auth.Web.csproj"
COPY . .
WORKDIR "/src/Services/auth/O2NextGen.Auth.Web"
RUN dotnet build "O2NextGen.Auth.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "O2NextGen.Auth.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O2NextGen.Auth.Web.dll"]