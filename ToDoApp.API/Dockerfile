FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/

COPY ./ToDoApp.DAL/ToDoApp.DAL.csproj ./ToDoApp.DAL/ToDoApp.DAL.csproj
COPY ./ToDoApp.BLL/ToDoApp.BLL.csproj ./ToDoApp.BLL/ToDoApp.BLL.csproj
COPY ./ToDoApp.API/ToDoApp.API.csproj ./ToDoApp.API/ToDoApp.API.csproj
RUN dotnet restore ./ToDoApp.API/

COPY ./ToDoApp.DAL/ ./ToDoApp.DAL/
COPY ./ToDoApp.BLL/ ./ToDoApp.BLL/
COPY ./ToDoApp.API/ ./ToDoApp.API/
RUN dotnet publish -c Release -o ./app/ ./ToDoApp.API/ --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app/
COPY --from=build /src/app/ .
ENV ASPNETCORE_HTTP_PORTS=5001
ENTRYPOINT [ "dotnet", "ToDoApp.API.dll" ]