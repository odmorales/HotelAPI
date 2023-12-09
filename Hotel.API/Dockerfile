#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hotel.API/Hotel.API.csproj", "Hotel.API/"]
COPY ["Hotal.Infrastructure/Hotel.Infrastructure.csproj", "Hotal.Infrastructure/"]
COPY ["Hotel.Aplication/Hotel.Application.csproj", "Hotel.Aplication/"]
COPY ["Hotel.Domain/Hotel.Domain.csproj", "Hotel.Domain/"]
COPY ["Hotel.Identity/Hotel.Identity.csproj", "Hotel.Identity/"]
RUN dotnet restore "Hotel.API/Hotel.API.csproj"
COPY . .
WORKDIR "/src/Hotel.API"
RUN dotnet build "Hotel.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hotel.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hotel.API.dll"]