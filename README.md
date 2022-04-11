# MovieTickets

ASP .NET Core MVC application designed for users to buy tickets for movies online. And also there is payment method for puchasing the tickets.
<br />
Link of the Website - .....

# Project Introduction
MovieTickets is a ASP.NET Core MVC 6.0 web application I builded during C# ASP.NET Core course at SoftUni (March-April 2022). <br />

# Built With
* ASP.NET Core 5 MVC
* Bootstrap
* MSSQL Server
* Entity Framework Core
* Font Awesome Icons

# Functionality
* There is Login/Register functionality.
* There is payment with paypal integration.
* When you start the applicaton on the main page you can see catalog with movies.And depending on what role you are logged in you get access to the functionalities for the role.

* User
1. Users role can go to movie details for more information about the movie.
2. Can add movie to shopping cart, aswell as remove movie from shopping cart.
3. Can go to producers page.
4. Can go to actors page.
5. Can go to cinemas page.

* Admin
1. Can add new movie.
2. Can edit movie.
3. Can delete movie.
4. Can also do CRUD operations on producers,cinemas,actors.
5. Can add movie to shopping cart.
6. Can see list of orders of users.
7. Can see list of users.

# Project Architecture
* The architecture is clean and easy to work with:

1. MovieTickets.Web - ASP.NET Core Web App MVC
2. MovieTickets.Data - Class Library,
3. MovieTickets.Services - Class Library,
4. MovieTickets.Test - NUnit Test Project, holding Service and Controllers Tests.

# Start using the project

# Database Diagram

<kbd><img src="https://github.com/kivanov22/MovieTickets/tree/main/MovieTickets/Img/DatabaseDiagramFull.png" /></kbd>
<br/><br/>

# Test
## Written Tests - ..
### Libraries used for testing:
* Nunit
* SQLite
* Fine Code Coverage
<kbd><img src="https://github.com/kivanov22/MovieTickets/tree/main/MovieTickets/Img/CoverageAsPercent2.png" /></kbd>
<br/><br/>