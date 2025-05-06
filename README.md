# Order Processing API

This is a sample REST API built with ASP.NET Core (.NET 8) for processing orders in an e-commerce platform. The project simulates real-world order handling by forwarding orders to a mock payment gateway, saving them to a SQLite database, and returning receipts.

## Features

- REST API for processing and retrieving orders
- SQLite database integration (no external setup required)
- Data validation via attributes
- Manual DTO mapping
- Logging and error handling
- Swagger UI for testing

## Technologies

- .NET 8
- ASP.NET Core Web API
- SQLite (via EF Core)
- Swagger / Swashbuckle
- Entity Framework Core
- Moq for unit testing

## Endpoints

- **GET** `/orders/{id}` - Retrieves the order by its ID.

- **POST** `/orders` - Submits a new order.

## Getting Started

### Prerequisites

- Visual Studio 2022 or newer with .NET 8 SDK

### How to Run

To get the project up and running locally, follow these steps:

1. Clone the repository to your local machine.

2. Open the solution in Visual Studio 2022 or a compatible IDE.

3. Restore the required NuGet packages by running `dotnet restore`.

4. Update the database by applying the latest migrations with `dotnet ef database update`.

5. Run the project with `dotnet run`.

---
