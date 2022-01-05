# FROM ubuntu

# MAINTAINER stanvanbavel pal <461345@student.fontys.nl>

# RUN apt-get update

# CMD ["echo", "DockerImage Pushed"]

# FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
# WORKDIR /src
# COPY ["CarPartsOnline/CarPartsOnline.csproj", "CarPartsOnline/"]
# RUN dotnet restore "CarPartsOnline/CarPartsOnline.csproj"
# COPY . .
# WORKDIR "/src/CarPartsOnline"
# RUN dotnet build "CarPartsOnline\CarPartsOnline.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "CarPartsOnline\CarPartsOnline.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "CarPartsOnline.dll"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY CarPartsOnline/CarPartsOnline.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY .. ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "CarPartsOnline.dll"]

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "aspnetapp.dll"]
