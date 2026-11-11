FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Agent.Framework.HelloWorld/Agent.Framework.HelloWorld.csproj", "Agent.Framework.HelloWorld/"]
RUN dotnet restore "Agent.Framework.HelloWorld/Agent.Framework.HelloWorld.csproj"
COPY . .
WORKDIR "/src/Agent.Framework.HelloWorld"
RUN dotnet build "./Agent.Framework.HelloWorld.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Agent.Framework.HelloWorld.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Agent.Framework.HelloWorld.dll"]
