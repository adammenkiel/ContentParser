FROM mcr.microsoft.com/dotnet/sdk:10.0

WORKDIR /app

COPY . .

RUN dotnet restore

EXPOSE 5036

ENTRYPOINT ["dotnet", "run", "--project", "src/API/API.csproj"]