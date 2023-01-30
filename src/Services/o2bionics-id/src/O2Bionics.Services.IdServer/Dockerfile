#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["O2Bionics.Services.IdServer/O2Bionics.Services.IdServer.csproj", "O2Bionics.Services.IdServer/"]
RUN dotnet restore "O2Bionics.Services.IdServer/O2Bionics.Services.IdServer.csproj"
COPY . .
WORKDIR "/src/O2Bionics.Services.IdServer"
RUN dotnet build "O2Bionics.Services.IdServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "O2Bionics.Services.IdServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O2Bionics.Services.IdServer.dll"]
