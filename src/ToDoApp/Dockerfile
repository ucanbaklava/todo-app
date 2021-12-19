FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src

COPY ToDoApp.Data/*.csproj ./ToDoApp.Data/
COPY ToDoApp.Domain/*.csproj ./ToDoApp.Domain/
COPY ToDoApp.Application/*.csproj ./ToDoApp.Application/
COPY ToDoApp.API/*.csproj ./ToDoApp.API/
COPY ToDoApp.Tests/*.csproj ./ToDoApp.Tests/

RUN dotnet restore  ToDoApp.API/ToDoApp.API.csproj
COPY . .
WORKDIR /src/ToDoApp.API
RUN dotnet build ToDoApp.API.csproj -c Release -o /app/build
RUN dotnet test
FROM build as publish
RUN dotnet publish ToDoApp.API.csproj -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish/ .
ENTRYPOINT ["dotnet", "ToDoApp.API.dll"]

