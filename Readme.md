# Startup Role Management Project for Asp.Net Core 3.1  with PostGRE - perfect for deployment in Linux Server

This application is created with [ASP.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) and [PostGRE SQL](https://www.postgresql.org/download/) (any version, tested with v11-v13). This project is a perfect startup place (***boilerplate project***) for a project targetting to deploy in Linux server. HTML, CSS, JS minifire all are configured in the project for better performance.

## Table of Contents

* [Features](#features)
* [Getting Started](#getting-started)
* [Deployment](#deployment)
* [Upcoming Features](#upcoming-features)
* [Application Structure](#application-structure)
* [Gotchas](#gotchas)
* [FAQ](#faq---also-check-out-the-faq-issues-label-and-the-how-to-issues-label)
* [Special Thanks](#special-thanks)
* [License](#license)

## Features

1. Configuration with PostGRE SQL (Support for both NoSQL and SQL)
2. Frontend Library Manager
3. [CSS and JS code minifire with compresser](#css-and-js-library-with-bundling-and-minification)
4. Code First Approach - Database Migration
5. Seed fake data
6. Datatable Data view with custom action
7. Authorization and authentication
8. Role and claim Based Authintication
9. Role Management
   1. Assign action to specific role
   2. Assign any role to any user
   3. Create New Role
10. Easy deploy in Linux (Centos deploy command added)
11. Default Fallback Page Configured
12. HTML Compressor during deployment configured
13. Email Service Configured
    1. User verification mail configured
    2. User password reset mail configured
    3. Any promotional mail configured
    4. Mail configuration read from `appsettings.json` file
14. Role based control over razor elements
15. Cache Configuration for static files
16. Force web to Https over http with self signed certificate at port 5001 as default
17. Custom Identity pages in Identity Area
    1. Add custom actions and login
    2. Customize Identity URLs
    3. Customize Identity views
    4. Add User-name change limit
    5. Restrict user from login if wrong pasword is provided for several times
    6. Add 2FA login with QrCode and Google Authinticator
18. Support for receiving all headers forwarded from `Nginx` or `Apache` in Linux.

## Getting Started

1. Clone the repo-

```console
git clone https://github.com/BCC-CA/Asp.NetCore_3.1-PostGRE_Signing-ASP.git ASP
cd ./ASP
```

2. Copy the `appsettings` file-

```console
copy appsettings.json.example appsettings.json
```

3. Setup the Database in ***PostGRE server*** (*PgAdmin*) and modify the `appsettings.json` file with proper database crediantials.
4. Open the `.sln` file with Visual Studio. For this project, the solution file is- `StartupProject-Asp.NetCore-PostGRE.sln` (tested with VS 2019 Community). Then run the command-

    `Build`-> `Build Solution`.

5. Now, database tables should be created with migration and some demo data should be added with seed data. To do those, we should run the command-
```console
Update-Database
```
6. Run the Project with clicking the button `IIS Express` and project will run with default browser of windows / visual studio.

## Easy Deploy in Centos 8 with Requirements

Publish project command-

```console
dotnet publish -c Release -o /home/abrar/PublishedWebApp
```
More commands can be found in [here](https://www.c-sharpcorner.com/article/net-core-cli2/) and [here](./.doc/Links_and_Commands.md).

Complete deploy to a [Centos 8.x](http://isoredirect.centos.org/centos/8/) server can be found in [this documentation](./.doc/CentOs_8_Deploy.md).


### Prerequisite

1. [ASP.Net Core SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1)
2. [PostGRE SQL Server](https://www.postgresql.org/download/), tested with 11+, should work with any version
3. [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)

### Running with VS

To run this project with [Visual Studio 2019](https://visualstudio.microsoft.com/vs/), you need to install the dotnet SDK in PC and a PostGRE connection string (connection string comes from PostGRE server which can exists in dev PC or remote server). After having both, you need to change [this line in code](./appsettings.json#L3) with your connection string. Then if you build and run the code, everything would be OK.

To apply the migration, you need to run migration update command in package manager console. The command is-

	Update-Database

To get the package manager console, you need to go here in **VS 2019**-

- ***Tools*** -> *Library Package Manager* -> *Package Manager Console* 

Most common migration commands are added in this project and can be found in [here](./.doc/Links_and_Commands.md).

## CSS and JS library with bundling and minification

Minimal configuration and easy to deploy library manager, bundler and minifire is used in this project which can be easily deployed in linux along with windows easily with zero configuration.

### Library management with Libman with different source
All CSS and JS library are managed by [libman](https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/libman-vs?view=aspnetcore-3.1) which is one of the bset option for managing client side libraries. The file can be found in [here](./libman.json) and look like this-
![Libman file ](.doc/img/libman.jpg)
where default provider is set to ***cdnjs*** and can be set to anything like ***jsdelivr*** or anything. All file download directory is set and only required files are downloaded, so list of required files are found from the included file in the [libman.json](./libman.json) file.
No custom CSS and no custom JS are applied

### Bundling and Minification

Bundling and minification is configured with [this](./bundleconfig.json) file which is very easy to configure and used. More can be found in [here](https://docs.microsoft.com/en-us/aspnet/core/client-side/bundling-and-minification?view=aspnetcore-3.1). The file is looking like this-

![libman easy configuration](.doc/img/libman.jpg)

which generates a css file named **site.min.css** and a js file named **site.min.js** which includes all CSS and js file compliation including all libraries.

In the project, there is stored 1 custom CSS file can be found in [here](./wwwroot/css/site.css) and one custom js fle can be found in [here](./wwwroot/js/site.js) which is also configured with bundler and minifire. No code is added in the 2 file because of providing freedom to the developer who wishesh to use this project and customize it on his demand. AS well this 2 file is added to the bundler so that a developer who forks this repo, can know how to configure his own repo. And finally, version number is appended with the CSS and JS so that CSS and JS caching issue can't happen because after each build, browser will treat every CSS and JS as new one.

## Database and Migration with Seed

PostGRE SQL is used because it is most robust open source database having support for both relational DB and text based DB. In this project I am using the DB as a relational DB. The configuration of the database can be done from [here](/appsettings.json#L3) so that anyone can configure individual DB for both deployment and development.

### Migration
All migration files are configured to be stored in [this](./Data/ApplicationDbContext.cs) folder. Useful migration commands can be found from [here](./.doc/Links_and_Commands.md).

### Seed

Seeds are configured in [here](/Data/Seeds/SeedController.cs#L19). After adding a seed, you need to run this command-

	Add-Migration <Seed_Migration_Name>
	Update-Database

Replace `<Seed_Migration_Name>` with your seeder-migration name.

Default Superadmin set with seeder is-

- ***Username*** - `abrar@jahin.com`
- ***Password*** - `abrar@jahin.com`

## Authentication and Authorization

In this project Role based authintication is implemented. 

In this project, Role based authontication is implemented and some specific roles are created depending on an enum defined in [here](./Data/Enums/EClaims.cs). And also Any user can be assigned with any role and a user can have multiple roles. Moreover, the filtering based on different places are applied in following places-

1. Controller Level can be found in [here](./Controllers/SuperAdmin/RoleManagerController.cs#L11)
2. Action level can be found in [here](./Controllers/HomeController.cs#L30)
3. Razor page sections can be filtered with role can be found in [here](./Views/Shared/LayoutPartial/_navigator.cshtml#L27)
4. Add *multiple roles* on a *Cntroller*/*Action*/*Razor page* can be found in [here](./Controllers/HomeController.cs#L30)
5. Username change limit added and set limit to 10 by default
6. 2FA with Google authinticator is added
Custom [attributes are defined in here](./Attributes/AuthorizeRolesAttribute.cs#L11) which is used to convert *enum* to attribute.

## Application UI and Screen Shots

All forms has front end and back end validation at a same time. 

0. Landing Page ![Landing Page](./.doc/img/1.landing.jpg)
1. Registration page ![Login Page Design](./.doc/img/2.1.registration.jpg)
2. Login page ![Login Page Design](./.doc/img/2.2.login.jpg)
3. Normal User View ![Login Page Design](./.doc/img/3.normal_user_view.jpg)
4. Super-Admin User View ![Login Page Design](./.doc/img/6.super_admin.jpg)
5. Access Denied page for any unauthorised access ![Login Page Design](./.doc/img/9.access_denied.jpg)
6. 2FA for user ![Login Page Design](./.doc/img/5.2fa.jpg)
7. Profile Page ![Login Page Design](./.doc/img/4.profile.jpg)
8. Role Page ![Login Page Design](./.doc/img/7.roles.jpg)
9. User-Role Management Page ![Role List by User](./.doc/img/8.1.roles_user.jpg) and ![Change User Role](./.doc/img/8.2.roles_user.jpg)

and basic operation pages.

## Some important partials

1. Header partial are seperated and can be found in [here](./Views/Shared/LayoutPartial/_header.cshtml)
2. Footer partial are seperated and can be found in [here](./Views/Shared/LayoutPartial/_footer.cshtml)
3. Navbar partial are seperated and can be found in [here](./Views/Shared/LayoutPartial/_navigator.cshtml)