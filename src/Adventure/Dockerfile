FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Adventure/Adventure.csproj", "Adventure/"]
RUN dotnet restore "src/Adventure/Adventure.csproj"
COPY . .
WORKDIR "/src/Adventure"
RUN dotnet build "Adventure.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adventure.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adventure.dll"]
