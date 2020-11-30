# Create base image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Create build environment and copy files
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["VegaIT.API/VegaIT.API.csproj", "VegaIT.API/"]
COPY ["VegaIT.Core/VegaIT.Core.csproj", "VegaIT.Core/"]
COPY ["VegaIT.Data/VegaIT.Data.csproj", "VegaIT.Data/"]
# Restore environment
RUN dotnet restore "VegaIT.API/VegaIT.API.csproj"
# Copy all
COPY . .
# Build
WORKDIR "/src/VegaIT.API"
RUN dotnet build "VegaIT.API.csproj" -c Release -o /app/build
# Publish
FROM build AS publish
RUN dotnet publish "VegaIT.API.csproj" -c Release -o /app/publish
# Finish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VegaIT.API.dll"]

