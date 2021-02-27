#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["payapp.api/payapp.api.csproj", "payapp.api/"]
RUN dotnet restore "payapp.api/payapp.api.csproj"
COPY . .
WORKDIR "/src/payapp.api"
RUN dotnet build "payapp.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "payapp.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "payapp.api.dll"]