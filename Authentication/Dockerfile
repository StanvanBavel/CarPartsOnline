FROM ubuntu

MAINTAINER stanvanbavel pal <461345@student.fontys.nl>

RUN apt-get update

CMD ["echo", "DockerImage Pushed"]

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 44319
EXPOSE 49172
EXPOSE 5000
ENV ASPNETCORE_URLS http://*:44319

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CarPartsOnline/Authentication.csproj", "Authentication/"]
RUN dotnet restore "CarPartsOnline/Authentication.csproj"
COPY . .
WORKDIR "/src/CarPartsOnline"
RUN dotnet build "Authentication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authentication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authentication.dll"]
