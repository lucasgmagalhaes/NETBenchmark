#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DOTNET_6/DOTNET_6.csproj", "DOTNET_6/"]
RUN dotnet restore "DOTNET_6/DOTNET_6.csproj"
COPY . .
WORKDIR "/src/DOTNET_6"
RUN dotnet build "DOTNET_6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DOTNET_6.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DOTNET_6.dll"]