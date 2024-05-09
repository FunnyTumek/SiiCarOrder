# WARNING
# This Dockerfile needs to be build with context of the parent folder

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /app/build/contracts
COPY contracts/Sii.CarOrder.Contracts/Sii.CarOrder.Contracts.csproj Sii.CarOrder.Contracts/

WORKDIR /app/build/dealer
COPY dealer/Sii.Dealer.Api/Sii.Dealer.Api.csproj Sii.Dealer.Api/
COPY dealer/Sii.Dealer.ConsoleApp/Sii.Dealer.ConsoleApp.csproj Sii.Dealer.ConsoleApp/
COPY dealer/Sii.Dealer.Core.Application/Sii.Dealer.Core.Application.csproj Sii.Dealer.Core.Application/
COPY dealer/Sii.Dealer.Core.Base/Sii.Dealer.Core.Base.csproj Sii.Dealer.Core.Base/
COPY dealer/Sii.Dealer.Core.Domain/Sii.Dealer.Core.Domain.csproj Sii.Dealer.Core.Domain/
COPY dealer/Sii.Dealer.Core.Infrastructure/Sii.Dealer.Core.Infrastructure.csproj Sii.Dealer.Core.Infrastructure/
COPY dealer/Sii.Dealer.Customers/Sii.Dealer.Customers.csproj Sii.Dealer.Customers/
COPY dealer/Sii.Dealer.DependencyInjection/Sii.Dealer.DependencyInjection.csproj Sii.Dealer.DependencyInjection/
COPY dealer/Sii.Dealer.ReadModel/Sii.Dealer.ReadModel.csproj Sii.Dealer.ReadModel/
COPY dealer/Sii.Dealer.SharedKernel/Sii.Dealer.SharedKernel.csproj Sii.Dealer.SharedKernel/
COPY dealer/Sii.Dealer.UnitTests/Sii.Dealer.UnitTests.csproj Sii.Dealer.UnitTests/
COPY dealer/Sii.Dealer.sln .
RUN dotnet restore

WORKDIR /app/build/contracts
COPY contracts/ .

WORKDIR /app/build/dealer
COPY dealer/ .
RUN dotnet build --configuration Release --output out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime-env
WORKDIR /app
COPY --from=build-env /app/build/dealer/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "Sii.Dealer.Api.dll"]
