# WARNING
# This Dockerfile needs to be build with context of the parent folder

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env

WORKDIR /app/build/contracts
COPY contracts/Sii.CarOrder.Contracts/Sii.CarOrder.Contracts.csproj Sii.CarOrder.Contracts/

WORKDIR /app/build/configurator/backend
COPY configurator/backend/Configurator.Api/Configurator.Api.csproj Configurator.Api/
COPY configurator/backend/Configurator.Api.Application/Configurator.Api.Application.csproj Configurator.Api.Application/
COPY configurator/backend/Configurator.Api.DataAccess/Configurator.Api.DataAccess.csproj Configurator.Api.DataAccess/
COPY configurator/backend/Configurator.Api.Dtos/Configurator.Api.Dtos.csproj Configurator.Api.Dtos/
COPY configurator/backend/Configurator.Api.sln .
RUN dotnet restore

WORKDIR /app/build/contracts
COPY contracts/ .

WORKDIR /app/build/configurator/backend
COPY configurator/backend/ .
RUN dotnet build --configuration Release --output out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime-env
WORKDIR /app
COPY --from=build-env /app/build/configurator/backend/out .
EXPOSE 80
ENTRYPOINT [ "dotnet", "Configurator.Api.dll" ]
