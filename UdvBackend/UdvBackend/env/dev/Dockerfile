FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UdvBackend/UdvBackend.csproj", "UdvBackend/"]
RUN dotnet restore "UdvBackend/UdvBackend.csproj"
COPY . .
WORKDIR "/src/UdvBackend"
RUN dotnet build "UdvBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UdvBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UdvBackend.dll"]
