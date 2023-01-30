FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/O2Bionics.Services.IdServer/O2Bionics.Services.IdServer.csproj", "src/O2Bionics.Services.IdServer/"]
RUN dotnet restore "src/O2Bionics.Services.IdServer/O2Bionics.Services.IdServer.csproj"
COPY . .
WORKDIR "/src/src/O2Bionics.Services.IdServer"
RUN dotnet build "O2Bionics.Services.IdServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "O2Bionics.Services.IdServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O2Bionics.Services.IdServer.dll"]
