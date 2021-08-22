#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SampleApiToDeployOnOpenShift/SampleApiToDeployOnOpenShift.csproj", "SampleApiToDeployOnOpenShift/"]
#COPY ["SampleApiToDeployOnOpenShift.csproj", "SampleApiToDeployOnOpenShift/"]
RUN dotnet restore "SampleApiToDeployOnOpenShift/SampleApiToDeployOnOpenShift.csproj"
COPY . .
WORKDIR "/src/SampleApiToDeployOnOpenShift"
RUN dotnet build "SampleApiToDeployOnOpenShift.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SampleApiToDeployOnOpenShift.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleApiToDeployOnOpenShift.dll"]