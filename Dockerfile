# FROM ubuntu

# MAINTAINER stanvanbavel pal <461345@student.fontys.nl>

# RUN apt-get update

# CMD ["echo", "DockerImage Pushed"]
# mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build
FROM mcr.microsoft.com/dotnet/aspnet:3.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.0-alpine AS build
WORKDIR /src
COPY ["CarPartsOnline/CarPartsOnline.csproj", "CarPartsOnline/"]
RUN dotnet restore "CarPartsOnline/CarPartsOnline.csproj"
COPY . .
WORKDIR "/src/CarPartsOnline"
RUN dotnet build "CarPartsOnline/CarPartsOnline.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarPartsOnline/CarPartsOnline.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarPartsOnline.dll"

