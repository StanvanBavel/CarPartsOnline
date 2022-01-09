# FROM ubuntu

# MAINTAINER stanvanbavel pal <461345@student.fontys.nl>

# RUN apt-get update

# CMD ["echo", "DockerImage Pushed"]
# mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build
# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src
COPY ["CarPartsOnline/CarPartsOnline.csproj", "CarPartsOnline/"]
RUN dotnet restore "CarPartsOnline/CarPartsOnline.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "CarPartsOnline/CarPartsOnline.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarPartsOnline/CarPartsOnline.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "CarPartsOnline.dll"

