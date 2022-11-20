#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM node as react

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs

WORKDIR /src
COPY ["Services/auth/O2NextGen.Auth.Web/O2NextGen.Auth.Web.csproj", "Services/auth/O2NextGen.Auth.Web/"]
RUN dotnet restore "Services/auth/O2NextGen.Auth.Web/O2NextGen.Auth.Web.csproj"
COPY . .
WORKDIR "/src/Services/auth/O2NextGen.Auth.Web"
RUN dotnet build "O2NextGen.Auth.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "O2NextGen.Auth.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O2NextGen.Auth.Web.dll"]
