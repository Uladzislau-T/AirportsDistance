FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
WORKDIR /app   

    
COPY ./API/AirportsDistance.API/*.csproj ./API/AirportsDistance.API/
COPY ./API/AirportsDistance.Infrasturcture/*.csproj ./API/AirportsDistance.Infrasturcture/

RUN dotnet restore ./API/AirportsDistance.API/AirportsDistance.API.csproj

COPY . .
WORKDIR "/app/API/AirportsDistance.API"
RUN dotnet build "AirportsDistance.API.csproj" -c Release 

FROM build as publish
RUN dotnet publish "AirportsDistance.API.csproj" -c Release -o /app/publish
 

FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app 
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AirportsDistance.API.dll"]