#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./src/LiteObject.App/LiteObject.App.csproj", "LiteObject.App/"]
RUN dotnet restore "/src/LiteObject.App/LiteObject.App.csproj"

WORKDIR "/src/LiteObject.App"
COPY . .
RUN dotnet build "./src/LiteObject.App/LiteObject.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./src/LiteObject.App/LiteObject.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LiteObject.App.dll"]