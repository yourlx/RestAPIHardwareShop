# Rest API Hardware Shop

This is a sample project designed to learn how to build and work with RESTful APIs using ASP.NET.

# Table of Contents

- [Installation and Running](#installation-and-running)
   - [Local](#local)
   - [Docker](#docker)
- [Usage](#usage)
- [License](#license)

# Installation and Running

1. Clone the repository with the application:

```bash
git clone https://github.com/yourlx/RestAPIHardwareShop
```

2. Navigate to the `src` folder:

```bash
cd src
```

## Local

1. Make sure that you have .NET 8 SDK and runtime installed. Also, ensure that you have a PostgreSQL instance (local or
   in a Docker container) running on the same port defined
   in [appsettings.json](src/HardwareStore.WebApi/appsettings.json), or change it to your preferred port.

2. Run the application:

```bash
dotnet run --project HardwareStore.WebApi
```

3. Verify that the application is running.

## Docker

1. Make sure that you have Docker (and Docker Compose) installed.

2. Build the Docker image and run the containers using Docker Compose:

```bash
ASPNETCORE_ENVIRONMENT=Development docker-compose up
```

3. Ensure that the containers are running using the `docker ps` command or Docker Desktop.

# Usage

To interact with the API, you can use tools like `curl`, Postman, or the built-in Swagger UI. The Swagger documentation
should be available at http://localhost:8080/swagger/index.html.

Example:

- Get all products:

```http request
GET /api/v1/products
```

- Create a new product:

```http request
POST /api/v1/products
{
  "name": "Wooden Chair",
  "category": "Furniture",
  "price": 15,
  "availableStock": 100,
  "supplierId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

# License

This repository code is under MIT License. See [LICENSE file](LICENSE) for more info.
