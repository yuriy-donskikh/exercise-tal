# Exercise project

Please find the project Exercise project wich allows you to create a meting room and assigne availability for particular room.

## Prerequisites 

### Backend

.Net 5

VisualStudio 2019

### Frontend

NodeJs

Angular CLI

## Build and Start application

### Command line for backend

From solution folder please execute following commands:

For building application:

```
dotnet build exerciseapi
```

For running all unit tests:

```
dotnet test exerciseunittest
```

For running Application Please execute command from ExerciseApi folder

```
dotnet run ExerciseApi
```

Open browser and navigate to https://localhost:44300/swagger

### From VisualStudio 2019 for backend

Please open solution in VisualStudio and rebuild.

For running test: open test explorer and run all tests.

For running project run ExerciseApi in debug mode it will open default browser for address: https://localhost:44300/swagger
 
### Command line for frontend

Before executing commands make sure you installed Angular CLI by executing:

```
npm install -g @angular/cli
```

From folder exercise-frontend please execute following commands:

For restoring dependencies:

```
npm install
```

For runing application:

```
ng serve
```

after that open browser and navigate to http://localhost:4200


### From VSCode for frontend

Please open folder exercise-frontend in VSCode.

Open terminal window and enter following commands:

```
npm install
ng serve
```

after that open browser and navigate to http://localhost:4200

## Solution elements

### Projects structure

Project was separated to following items:

1.	ExerciseApi – Backend startup project
2.	ExerciseData – contains entities and data seeding functionality
3.	ExerciseModel – contains models for returning to User
4.	ExerciseServices – contains all business logic for backend project
5.	ExerciseUnitTests – contains unit tests for all backend functionality
6.  exercise-frontend - Fronend startup project

### Database

Project using MSSQLLocalDB for data storage.

### Authentication

Project can use Auth2 Authentication for secure access endpoints, to activate this – please add following structure to corresponding Appsetting.json file

```
  "Auth": {
    "Authority": "https://Url_To_JWT_Provider",
    "Resource": "Product.API",
    "ClientId": "Product.API",
  },
```

Where:

Authority: Url to Auth2 server which can provide JWT token

Resource: is registered resource on Auth2 Server

ClientId: is registered ClientId on Auth2 Server


After that open Runtime.Json file and remove following element from all endpoints which have to be secured.

```
"NotAuthorize": true,
```


