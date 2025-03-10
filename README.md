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

## Database

- Foreign keys ensure referential integrity between products, packaging, and items.

- The PackagingType column allows flexibility to support different types of packaging (e.g., box, pallet, wrapper).

- The RecursivePackaging CTE is used to fetch packaging at all levels, including nested packaging.

- The ParentPackagingID allows us to represent hierarchical relationships between packaging items (e.g., a box within another box).

- create.table.script - This script create the tables.
- insert.table.script - This script inserts the data.
- product.query.script - This Recursive Query for fetches the product with the packaging Hierarchy.
- packaging.query.script - This query fetches the packaging associated with a specific item using a JOIN between Packaging and Items.

- Consider indexing ProductID and PackagingID in the Packaging and Items tables for efficient queries.
- CREATE INDEX IX_Packaging_ProductID ON Packaging(ProductID);
- CREATE INDEX IX_Items_PackagingID ON Items(PackagingID);


