# Gambling App 

Following technologies are used to perform the test.

* API Backend: C# .NET5 
* Design Pattern: Command Query Responsibility Segregation (CQRS), MVC
* API Documentation: Swagger
* Storage: In Memory & SQL Server
* Authentication & Authoriztion: Bearer
* Validations: Fluent Api
* Inversion of Control container: Autofac


## Architecture overview
This reference application is cross-platform at the server-side developed in .NET5 is capable of running on Linux or Windows. Implementation of app based on CQRS and decision was made to use CQRS because of the following reasons.

* Simple understandable and best to perform basic read, write operations.
* Single responsibility of reading and writing.
* Scale read operations at any point in time.
* Can optimize read and write sides independently
* Cleanly separate the Command and Query sides of the domain model.
