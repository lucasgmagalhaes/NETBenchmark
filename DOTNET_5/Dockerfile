#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DOTNET_5/DOTNET_5.csproj", "DOTNET_5/"]
RUN dotnet restore "DOTNET_5/DOTNET_5.csproj"
COPY . .
WORKDIR "/src/DOTNET_5"
RUN dotnet build "DOTNET_5.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DOTNET_5.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DOTNET_5.dll"]