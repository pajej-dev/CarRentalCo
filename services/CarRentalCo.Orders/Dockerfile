FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build 

ENV ASPNETCORE_ENVIRONMENT=production

WORKDIR /app

COPY src/CarRentalCo.Orders.API/CarRentalCo.Orders.API.csproj CarRentalCo.Orders.API/
COPY src/CarRentalCo.Orders.Application/CarRentalCo.Orders.Application.csproj CarRentalCo.Orders.Application/
COPY src/CarRentalCo.Orders.Domain/CarRentalCo.Orders.Domain.csproj CarRentalCo.Orders.Domain/
COPY src/CarRentalCo.Orders.Infrastructure/CarRentalCo.Orders.Infrastructure.csproj CarRentalCo.Orders.Infrastructure/

RUN dotnet restore CarRentalCo.Orders.API/CarRentalCo.Orders.API.csproj

COPY src/CarRentalCo.Orders.API/.  CarRentalCo.Orders.API/
COPY src/CarRentalCo.Orders.Application/.  CarRentalCo.Orders.Application/
COPY src/CarRentalCo.Orders.Domain/.  CarRentalCo.Orders.Domain/
COPY src/CarRentalCo.Orders.Infrastructure/.  CarRentalCo.Orders.Infrastructure/

RUN dotnet build CarRentalCo.Orders.API/CarRentalCo.Orders.API.csproj -c Release --no-restore 

RUN dotnet publish CarRentalCo.Orders.API/CarRentalCo.Orders.API.csproj -c Release -o /app/out --no-restore


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS runtime

WORKDIR /app
COPY --from=build /app/out .

ENV ASPNETCORE_URLS http://+:8002
EXPOSE 8002

ENTRYPOINT [ "dotnet", "CarRentalCo.Orders.API.dll" ]
