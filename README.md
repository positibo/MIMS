# MIMS

A RESTful API built using ASP.NET Core with Clean Architecture, CQRS, Mediator pattern, JWT authentication, and API versioning.

## Setup Instructions

1. Clone this repository.
2. Run `dotnet restore` to restore dependencies.
3. Set up your **SQL Server** and configure the connection string in `appsettings.json`.
4. Run the Database scripts for create and insert of tables.
5. Run `dotnet run` to start the API.
6. Access Swagger documentation at `http://localhost:7257swagger`.

## Endpoints

- **POST /api/v1/authentication/login** - Login and get a JWT token.
- **POST /api/v1/authentication/register** - Register a new user.
- **GET /api/v1/product** - Get a list of products.
- **GET /api/v2/product** - Get a list of products with packaging details.
- **POST /api/v1/product** - Add a new product.
