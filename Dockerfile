FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

#Copy, restore and build csproj
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./FormulaApp.API/FormulaApp.API.csproj", "FormulaApp.API/"]
RUN dotnet restore "./FormulaApp.API/FormulaApp.API.csproj"
COPY . .
WORKDIR "/src/FormulaApp.API"
RUN dotnet build "./FormulaApp.API.csproj" -c Release -o /app/build

#Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FormulaApp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

#BUILD IMAGE
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FormulaApp.API.dll"]