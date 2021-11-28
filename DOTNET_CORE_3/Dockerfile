#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DOTNET_CORE_3/DOTNET_CORE_3.csproj", "DOTNET_CORE_3/"]
RUN dotnet restore "DOTNET_CORE_3/DOTNET_CORE_3.csproj"
COPY . .
WORKDIR "/src/DOTNET_CORE_3"
RUN dotnet build "DOTNET_CORE_3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DOTNET_CORE_3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DOTNET_CORE_3.dll"]