#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["Services/smalltalk/O2NextGen.SmallTalk.SignalrHub/O2NextGen.SmallTalk.SignalrHub.csproj", "Services/smalltalk/O2NextGen.SmallTalk.SignalrHub/"]
RUN dotnet restore "Services/smalltalk/O2NextGen.SmallTalk.SignalrHub/O2NextGen.SmallTalk.SignalrHub.csproj"
COPY . .
WORKDIR "/src/Services/smalltalk/O2NextGen.SmallTalk.SignalrHub"
RUN dotnet build "O2NextGen.SmallTalk.SignalrHub.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "O2NextGen.SmallTalk.SignalrHub.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "O2NextGen.SmallTalk.SignalrHub.dll"]