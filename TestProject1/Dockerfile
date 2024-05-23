# Use the official .NET image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj file and restore the dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code and build the app
COPY . ./
RUN dotnet build --configuration Release --output ./out

# Use the official .NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Run the tests
ENTRYPOINT ["dotnet", "test"]
