# LibraryAPI

## Functionality:
For unauthorized users:
- registration and authorization

For authorized users:
- adding, deleting, changing authors
- retrieve list of all books
- retrieve a certain book by its Id or ISBN
- adding a new book
- change information about an existing book
- book deletion

## Technology Stack:
.Net 8.0
Entity Framework Core
AutoMapper
JWTBearer
Swagger
Serilog
FluentValidation

## Before Running
1. Check out the repository:
```sh
$ git clone https://github.com/Wertuyrw/LibraryAPI.git
```
Then change directory to LibraryAPI:
```sh
$ cd LibraryAPI/LibraryAPI
```
2.Find and open a file appsettings.json
Change the connection string
```sh
"ConnectionStrings": {
    "DefaultConnection": "Data Source=(yourServer);Integrated Security=True;Initial Catalog=Library;MultipleActiveResultSets=True;TrustServerCertificate=True"
  }
```
Apply the migrations to your database with the command
```sh
$  dotnet ef database update
```
Launch the application with the command
```sh
$  dotnet run --project .\Library.API.csproj --launch-profile https
```
3.Go to the application page
