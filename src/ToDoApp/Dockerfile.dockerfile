FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src

COPY ToDoApp.Data/*.csproj ./ToDoApp.Data/
COPY ToDoApp.Domain/*.csproj ./ToDoApp.Domain/
COPY ToDoApp.Application/*.csproj ./ToDoApp.Application/
COPY ToDoApp.Web/*.csproj ./ToDoApp.Web/
COPY ToDoApp.Tests/*.csproj ./ToDoApp.Tests/


RUN dotnet restore  ToDoApp.Web/ToDoApp.Web.csproj
COPY . .
WORKDIR /src/ToDoApp.Web
RUN dotnet build ToDoApp.Web.csproj -c Release -o /app/build
RUN dotnet test
FROM build as publish
RUN dotnet publish ToDoApp.Web.csproj -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish/ .
ENTRYPOINT ["dotnet", "ToDoApp.Web.dll"]

