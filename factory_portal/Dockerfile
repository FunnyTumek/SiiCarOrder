# WARNING
# This Dockerfile needs to be build with context of the parent folder

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /app/build/contracts
COPY contracts/Sii.CarOrder.Contracts/Sii.CarOrder.Contracts.csproj Sii.CarOrder.Contracts/

WORKDIR /app/build/factory_portal
COPY factory_portal/FactoryPortal/FactoryPortal.csproj FactoryPortal/
COPY factory_portal/FactoryPortal.sln .
RUN dotnet restore

WORKDIR /app/build/contracts
COPY contracts/ .

WORKDIR /app/build/factory_portal
COPY factory_portal/ .
RUN dotnet publish --no-restore -c Release -o output

FROM nginx:alpine
WORKDIR /var/www/web
COPY --from=build-env /app/build/factory_portal/output/wwwroot .
COPY factory_portal/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
