FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Lzw/Lzw.csproj", "Lzw/"]
RUN dotnet restore "Lzw/Lzw.csproj"
COPY . .
WORKDIR "/src/Lzw"
RUN dotnet build "Lzw.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lzw.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lzw.dll"]
