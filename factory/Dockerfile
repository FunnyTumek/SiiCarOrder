# WARNING
# This Dockerfile needs to be build with context of the parent folder

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /app/build/contracts
COPY contracts/Sii.CarOrder.Contracts/Sii.CarOrder.Contracts.csproj Sii.CarOrder.Contracts/

WORKDIR /app/build/factory
COPY factory/SiiCarOrder.Factory.Api/SiiCarOrder.Factory.Api.csproj SiiCarOrder.Factory.Api/
COPY factory/SiiCarOrder.Factory.Scheduler/SiiCarOrder.Factory.Scheduler.csproj SiiCarOrder.Factory.Scheduler/
COPY factory/SiiCarOrder.Factory.Application/SiiCarOrder.Factory.Application.csproj SiiCarOrder.Factory.Application/
COPY factory/SiiCarOrder.Factory.Domain/SiiCarOrder.Factory.Domain.csproj SiiCarOrder.Factory.Domain/
COPY factory/SiiCarOrder.Factory.Dtos/SiiCarOrder.Factory.Dtos.csproj SiiCarOrder.Factory.Dtos/
COPY factory/SiiCarOrder.Factory.Infrastructure/SiiCarOrder.Factory.Infrastructure.csproj SiiCarOrder.Factory.Infrastructure/
COPY factory/Sii.Factory.sln .
RUN dotnet restore

WORKDIR /app/build/contracts
COPY contracts/ .

WORKDIR /app/build/factory
COPY factory/ .
RUN dotnet build --configuration Release --output out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime-env
WORKDIR /app
COPY --from=build-env /app/build/factory/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "SiiCarOrder.Factory.Api.dll"]
