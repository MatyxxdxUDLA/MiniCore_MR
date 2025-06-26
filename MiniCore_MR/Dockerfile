# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MiniCore_MR.csproj", "./"]
RUN dotnet restore "MiniCore_MR.csproj"
COPY . .
RUN dotnet build "MiniCore_MR.csproj" -c Release -o /app/build

# Etapa de publicación
FROM build AS publish
RUN dotnet publish "MiniCore_MR.csproj" -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniCore_MR.dll"]