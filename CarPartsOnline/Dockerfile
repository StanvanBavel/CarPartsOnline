FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 44344
EXPOSE 44334
EXPOSE 5000
ENV ASPNETCORE_URLS http://*:44344

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CarPartsOnline/CarPartsOnline.csproj", "CarPartsOnline/"]
RUN dotnet restore "CarPartsOnline/CarPartsOnline.csproj"
COPY . .
WORKDIR "/src/CarPartsOnline"
RUN dotnet build "CarPartsOnline.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarPartsOnline.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarPartsOnline.dll"]
