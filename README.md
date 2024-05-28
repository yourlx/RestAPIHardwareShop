# Rest API Hardware Shop

This is a learning project to get acquainted with API development using ASP.NET.

# Installation and running

1. Clone the repository with the application:

```
git clone https://github.com/yourlx/Backend.Project_2.git
```

2. Navigate to `src` folder

```
cd src
```

## Local

1. Make sure that you have .NET 8 SDK and runtime installed.\
   Also, make sure that you have a PostgreSQL instance (local or in Docker container) running on the same port defined
   in [appsettings.json](src/HardwareStore.WebApi/appsettings.json), or change it to your preferred port.

2. Run application

```
dotnet run --project HardwareStore.WebApi
```

3. Make sure that application is running

## Docker

1. Make sure that you have Docker (and Docker Compose) installed.

2. Build Docker image and run containers using Docker Compose

```
ASPNETCORE_ENVIRONMENT=Development docker-compose up
```

3. Make sure that containers are running using `docker ps` command or Docker Desktop

# Check your application

In both ways (local and Docker) you will get the same result. \
Swagger documentation should be available on http://localhost:8080/swagger/index.html

# Licence

This repository code is under MIT License. See [LICENSE file](LICENSE) for more info.
