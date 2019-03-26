
FROM microsoft/dotnet:2.2.104-sdk AS build
WORKDIR /src/KhufuServer

# Copy csproj and restore as distinct layers
COPY *.fsproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2.0-aspnetcore-runtime
EXPOSE 5000
EXPOSE 5001
WORKDIR /src/KhufuServer
COPY --from=build /src/KhufuServer/out .
ENTRYPOINT ["dotnet", "KhufuServer.dll"]