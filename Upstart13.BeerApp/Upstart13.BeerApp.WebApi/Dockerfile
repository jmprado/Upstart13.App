#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Upstart13.BeerApp.WebApi/Upstart13.BeerApp.WebApi.csproj", "Upstart13.BeerApp.WebApi/"]
COPY ["Upstart13.BeerApp.Mapping/Upstart13.BeerApp.Mapping.csproj", "Upstart13.BeerApp.Mapping/"]
COPY ["Upstart13.BeerApp.Entities/Upstart13.BeerApp.Entities.csproj", "Upstart13.BeerApp.Entities/"]
COPY ["Upstart13.BeerApp.ViewModel/Upstart13.BeerApp.ViewModel.csproj", "Upstart13.BeerApp.ViewModel/"]
COPY ["Upstart13.BeerApp.Domain/Upstart13.BeerApp.Domain.csproj", "Upstart13.BeerApp.Domain/"]
COPY ["Upstart13.BeerApp.Dal/Upstart13.BeerApp.Dal.csproj", "Upstart13.BeerApp.Dal/"]
RUN dotnet restore "Upstart13.BeerApp.WebApi/Upstart13.BeerApp.WebApi.csproj"
COPY . .
WORKDIR "/src/Upstart13.BeerApp.WebApi"
RUN dotnet build "Upstart13.BeerApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Upstart13.BeerApp.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Upstart13.BeerApp.WebApi.dll"]