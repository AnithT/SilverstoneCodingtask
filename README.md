## SilverstoneCodingtask

I have created this .NET MVC web application , based on all the criterias and conditions mentioned in the technical test(even the optional).  This web application allows a user to enter a location and view current weather information. Also it shows the previosly searched location of the particular user. I have used weatherapi.com for fetching the weather details. 

When a user enters the invalid location, it will show error message above text field. A valid information will show weather information about that location and it will get store in the search history. I have used in-memory for storing the data. The search history will get save along with the user details like UserID and Name . I have hardcoded the name and id from the UI of this application as it do not have any sign in services.If we are adding the sign in services,those UserID and Username can be replaced.The search history will be shown based on the UserID.

 
# Technologies used       

**Backend** – C#.net (.NET 7), .NET core  ,EF Core(ver - 7) , XUnit , Moq 

**Frontend** – React Framework(ver 18), Material UI(MAUI) 

**Database** – In-memory(EntityFrameworkCore.InMemory package)

**API Documentation** – Swagger

 
# Architecture 

This .NET MVC project have been developed following Clean architecture, which consist of different layers, which make it more manageable , loosely coupled and scalable following **SOLID** principles. 

- WeatherForecast.Core - This layer contains all the core entities,models and interfaces that are used in the web application  

- WeatherForecast.Infrastructure -  This layer contains all the repositories and service layer changes of the web application like WeatherRepositories.cs for managing database operation,WeatherService.cs for managing the service logics used in the application, ExceptionMiddleware.cs for exception middleware handling , WeatherForecastContext.cs for database context etc 

- WeatherForecast.Web - This layer contains the controller classes where the API requests first hit the application, registration of services and configurations. 

- WeatherForecast.Unit_test - The unit testing scenarios are developed in this layer

- WeatherForecast.UI - Contains all the UI part of this web application. The UI part is built using React framework and have used React functionalitites like hooks such as usestate, useeffect and AXIOS service for fetching APIs.

 # Commits
 
There are 6 commits that I have done on building this web application 

 Commit 1  

  - Created the project . 

  - Made it more manageable following the clean architecture pattern 

Commit 2 

  - Modified models to match the weather api endpoints 

  - Done some changes related to swagger in program.cs and launchsettings.json 

  - Added repository section for managing database operation 

  - Changed the weather forecast fetching api to api.weatherapi.com as it is more easy for fetching details 

Commit 3 

  - Added database operation to save the searched details using in-memory. 

  - Added user ids so that all the searched details will be saved with the ids. 

 
Commit 4  

 - Added exception middleware class to handle all the exception happening in the application 

 - Added error response class to handle error coming from weatherapi and also to handle invalid location scenario. 

Commit 5 

 - Added Unit testing scenarios 

 - Modified and moved weather api common base URL and API key to common appsettings.json 

Commit 6 

 - UI changes created using React and Material UI.

# Unit Test

 Unit testing of this web application is done using Xunit framework and MOQ (only added two basic scenarios)
