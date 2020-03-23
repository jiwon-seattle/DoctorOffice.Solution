# [Project Name](https://github.com/ayohana/ProjectName.git/)

#### C# Basic Web Applications Exercise for [Epicodus](https://www.epicodus.com/), 03.20.2020

#### By [**Adela Darmansyah**](https://ayohana.github.io/portfolio/)

## Description

**Describe project here**

## User Stories

* As a ..., I want to be able to ... so that ...

## Specs

<details>
  <summary>Click to expand!</summary>

| Spec | `Console` Input | `Console` Output |
| :-------------     | :------------- | :------------- |
| **Test** | input | output |

</details>

## Setup/Installation Requirements

* Download [.NET Core](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-c-and-net) (Mac/Windows OS) - _FREE!_
* Download [MySQL](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql) (Mac/Windows OS) - _FREE!_
* Clone this [repository](https://github.com/ayohana/ProjectName.git/)
  * Open the `Command Line Interface`.
  * Enter `$ cd Desktop` to navigate into your Desktop (or anywhere you'd like to save this repo into).
  * Enter `$ git clone https://github.com/ayohana/ProjectName.git/`.
* Create your database.
  * Open the `Command Line Interface` (CLI).
  * Enter `mysql -uroot -p` and the CLI will prompt for your MYSQL password.
  * Enter `CREATE DATABASE database_name;`
  * Enter `SHOW DATABASES;` to confirm your database was created in your server's list of databases.
  * Enter `USE database_name;` to connect to your database.
  * Enter `SELECT DATABASE();` to verify you are connected to the correct database.
  * Enter `CREATE TABLE stylists (StylistID serial PRIMARY KEY, Name VARCHAR (255), Specialty VARCHAR (255), HireDate DATETIME);` to create your table of stylists.
  * Enter `CREATE TABLE clients (ClientID serial PRIMARY KEY, Name VARCHAR(255), StylistID INT);` to create your table of clients.
  * Enter `DESCRIBE stylists;` or `DESCRIBE clients` to see your table columns.
* Run the application.
  * Navigate into the `ProjectName` directory `$ cd Desktop/ProjectName/ProjectName.Solution/ProjectName`
    * Enter the command `dotnet restore` to gather tools and dependencies for the application.
    * Enter `dotnet run` to run the application.

## Known Bugs

No known bugs at this time.

## Support and contact details

Feel free to provide feedback via email: adela.yohana@gmail.com.

## Technologies Used

* C#
* MVC Pattern
* [.NET Core](https://dotnet.microsoft.com/download/dotnet-core/) (Windows OS)
* [MySQL](https://dev.mysql.com/downloads/file/?id=484919) (Windows OS)
* [EF Core](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)

### License

This C# console application is licensed under the MIT license.

Copyright (c) 2020 **Adela Darmansyah**
