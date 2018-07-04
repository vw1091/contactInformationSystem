
# Contact Information System

### .Net Web Api
- Type some Markdown on the left
- .Net web api's are build in web api2 which includes **Log4net** for logging purpose, **Exception filter** as exception handling and logging the exceptions
- Message handler for logging the request/response
- **Code first approach** which automatically creates the database and tables
- **swagger** for testing apis
- **Flune validation** for validations of models
- Extension methods for the converting viewmodel to entity and vice versa
- **Unity framework**  for dependency injections
- Returns the consistent responses for all apis
- **{Domain}/swagger** gives a nice UI for testing the api's separately
- Is having the mvc view as single home page which will interact with angular js
- Logging  is done using the **log4Net logging**

### UI Project
- Once Index.cshtml page loads the angular app and create the models and all things control will never return the cshtml and will remain in the client app
- angular **1.x** is used for building the angular app
 

### How to Run and Configure
- For web api, we will need to configure the database connection
- For running the app, just need to restore the nuget packages and run by either hosting on IIS or using IIS express
- For testing the Api, Used swagger which give the list of apis along with request/response object 
- For angular app, we dont need any configuration, we can directly use the app by running and redirecting to /Home
- For swagger, redirect the control to /swagger
