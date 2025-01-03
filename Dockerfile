# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy the csproj file and restore any dependencies (via dotnet restore)
COPY BlockChain.csproj ./
RUN dotnet restore

# Copy the rest of the code and publish it
COPY . ./
RUN dotnet publish -c Release -o /publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

# Copy the published files from the build stage
COPY --from=build /publish .

# Set the entry point to the correct DLL
ENTRYPOINT ["dotnet", "BlockChain.dll"]
