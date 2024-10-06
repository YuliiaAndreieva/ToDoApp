# ToDoApp
This is a web application to manage your tasks that have categories. After registration/login you can create, update, delete, view details of a task. You can create your own categories and add them to tasks. Every task can have a group of categories.

Upon first launch the application will have 3 categories and 7 tasks for preregistered user:
```
"email":"testuser@example.com",
"password":"YourStrongP@ssword123"
```

## How To Run
### Using docker-compose
To run the app using docker compose:
1. Clone the repo
```
git clone https://github.com/YuliiaAndreieva/ToDoApp
```
2. Go into the created folder
```
cd ToDoApp
```
4. Run docker-compose
```
docker compose up
```
That's it, the app is preconfigured in the [compose file](compose.yaml), so no extra configuration is required. After all of the containers have started, you'll have 3 running containers:
- Angular application on port 5000 (http)
- ASP .NET Core API on port 5001 (http)
- MS SQL database on port 5002 (http)

### Running locally
To run locally, make sure you have installed:
- .NET 8 SDK
- Angular CLI
- MS SQL
1. Repeat steps 1-3 from [using docker-compose section](#using-docker-compose)
2. Replace the "DefaultConneciton" entry in [ToDoApp.API/appsettings.Development.json](ToDoApp.API/appsettings.Development.json#L9) with your own connection string to the MS SQL database.
3. Run the API
```
dotnet run --project ./ToDoApp.API/
```
4. In a new terminal, go to the ToDoApp.Web folder
```
cd ./ToDoApp.Web/
```
5. Install all of the dependencies
```
npm i
```
6. Run the Angular app
```
ng serve
```
After that, you should have:
- Angular application running on port 4200 (http)
- ASP .NET Core API running on port 7218 (http)