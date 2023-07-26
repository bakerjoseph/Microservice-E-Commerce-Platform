# Microservice-E-Commerce-Platform
 Developed for Service-Based Software Architecture (SEN300)

## Services Overview
- **Catalog Service** is built using Java Spring Boot with JPA and Hibernate to interact with a Microsoft SQL Database
- **Basket Service** is built using Java Spring Boot with a Redis Database
- **Account Service and Check-Out Service** are built in C#, .NET 7, web API format with Entity Framework to interact with a Microsoft SQL Database
- **Ocelot** is built in C#, .NET 7
- **Eureka** is built in a docker container

All services can be brought to life using the Docker-Compose.yaml file. The backing SQL Server databases will be created and data will be persisted once the Docker-Compose.yaml file is run. Currently, this project is set up to replicate all services (besides Eureka and Ocelot) three times to provide service redundancy. Although this can be easily changed in the Docker-Compose.yaml file for as few or as many service replications as needed.
