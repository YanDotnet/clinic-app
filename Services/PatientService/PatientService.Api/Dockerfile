FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/PatientService/PatientService.Api/PatientService.Api/PatientService.Api.csproj", "PatientService.Api/"]
RUN dotnet restore "Services/PatientService/PatientService.Api/PatientService.Api/PatientService.Api.csproj"
COPY . .
WORKDIR "/src/PatientService.Api"
RUN dotnet build "PatientService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatientService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientService.Api.dll"]
