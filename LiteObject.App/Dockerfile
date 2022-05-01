#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
# Run this command (from root - where .sln is located - folder) to build the image:
# docker build -f ./LiteObject.App/Dockerfile --force-rm -t liteobject/liteobject-app:test . --label "created-by=mhoque" --no-cache --progress=plain
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
RUN pwd && ls -l
COPY ["../LiteObject.App/LiteObject.App.csproj", "LiteObject.App/"]
RUN pwd && ls -l
RUN pwd && ls -l ./LiteObject.App/
RUN dotnet restore "LiteObject.App/LiteObject.App.csproj"
COPY . .
RUN pwd && ls -l
WORKDIR "/src/LiteObject.App"
RUN pwd && ls -l
RUN dotnet build "LiteObject.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LiteObject.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LiteObject.App.dll"]