# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /out

# Stage 2: Serve the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build-env /out .

# Expose the API port (optional, adjust as needed)
#EXPOSE 7229

# Run the application
ENTRYPOINT ["dotnet", "Nentindo.dll", "--environment=Production"]


# docker build -t docker-backend .
# docker run -d -p 7229:7229 docker-backend



