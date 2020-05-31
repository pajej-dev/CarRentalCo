FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build 

ENV ASPNETCORE_ENVIRONMENT=production

WORKDIR /app

COPY src/CarRentalCo.Administration.API/CarRentalCo.Administration.API.csproj CarRentalCo.Administration.API/
COPY src/CarRentalCo.Administration.Application/CarRentalCo.Administration.Application.csproj CarRentalCo.Administration.Application/
COPY src/CarRentalCo.Administration.Domain/CarRentalCo.Administration.Domain.csproj CarRentalCo.Administration.Domain/
COPY src/CarRentalCo.Administration.Infrastructure/CarRentalCo.Administration.Infrastructure.csproj CarRentalCo.Administration.Infrastructure/

RUN dotnet restore CarRentalCo.Administration.API/CarRentalCo.Administration.API.csproj

COPY src/CarRentalCo.Administration.API/.  CarRentalCo.Administration.API/
COPY src/CarRentalCo.Administration.Application/.  CarRentalCo.Administration.Application/
COPY src/CarRentalCo.Administration.Domain/.  CarRentalCo.Administration.Domain/
COPY src/CarRentalCo.Administration.Infrastructure/.  CarRentalCo.Administration.Infrastructure/

RUN dotnet build CarRentalCo.Administration.API/CarRentalCo.Administration.API.csproj -c Release --no-restore 

RUN dotnet publish CarRentalCo.Administration.API/CarRentalCo.Administration.API.csproj -c Release -o /app/out --no-restore


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS runtime

WORKDIR /app
COPY --from=build /app/out .

ENV ASPNETCORE_URLS http://+:8001
EXPOSE 8001

ENTRYPOINT [ "dotnet", "CarRentalCo.Administration.API.dll" ]
