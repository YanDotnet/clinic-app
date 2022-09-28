FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/ScheduleService/ScheduleService.Api/ScheduleService.Api.csproj", "ScheduleService.Api/"]
RUN dotnet restore "Services/ScheduleService/ScheduleService.Api/ScheduleService.Api.csproj"
COPY . .
WORKDIR "/src/ScheduleService.Api"
RUN dotnet build "ScheduleService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ScheduleService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScheduleService.Api.dll"]
