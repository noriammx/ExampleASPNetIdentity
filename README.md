# Example ASP Net Identity
Project Example of ASP Net Identity

This project is about of ASP Net Identitu, is a how to implementation?.

This repository have two projects, one project created with the framework ASP Net identity and another without ASP Net Indentity, the last project is used for implementation asp net identity after created it.

## Case 1 - AspNetWithIdentity

In this case i have used the project by default, when you create a project from asp net mvc with security. But i needed use a custom database and them i created i database calle ExampleASPNetMVCIdentity.

Steps for replicate this case

1. Create a project ASP Net MVC with security. Single user
2. Create a database called ExampleASPNetMVCIdentity
3. Create a data model with Entity Framework, I called it Example Security Entities, but call it as you want
4. Change the db connection in the file web.config, use the db custom connection like this:

```xml
 <!--<add name="DefaultConnection" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-AspNetWithIdentity-20190510110134.mdf;Initial Catalog=aspnet-AspNetWithIdentity-20190510110134;Integrated Security=True" providerName="System.Data.SqlClient" />-->
    <add name="DefaultConnection" connectionString="Data Source=.;Initial Catalog=ExampleASPNetMVCIdentity;persist security info=True;user id=sa;password=Corepro1;multipleactiveresultsets=True;" providerName="System.Data.SqlClient" />
```
5. I changed the security policy for passwords, I used a very simple policy, but it's not recommended. This change is made inf file IdentityConfig
6. Try de web app, create a user and check the tables created, if every step is correct then you will able see the tables
7. This is the finish of the case

## Case 2 - AspNetWithOutIdentity

In this case, I have created a project without security, therefore, is necessary to add the asp net identity framework by way manually.

1. Create a project ASP Net MVC without security
2. Use the same database called ExampleASPNetMVCIdentity, created in the before case
3. After to create a project is necessary add the next Nuget Packages:

```
01) Install-Package EntityFramework (Entity Framework)
02) Install-Package EntityFramework.SqlServerCompact (Entity Framework SQL Server Compact)
03) Install-Package Microsoft.AspNet.Identity.Core (ASP.NET Identity Core)
04) Install-Package Microsoft.AspNet.Identity.EntityFramework (ASP.NET Identity EntityFramework)
05) Install-Package Microsoft.AspNet.Identity.Owin (ASP.NET Identity Owin)
06) Install-Package Microsoft.AspNet.WebApi.Client (ASP.NET Web API 2 Client)
07) Install-Package Microsoft.Owin.Host.SystemWeb (Owin.Host.SystemWeb)
```

4. After the installation of the Nuget Packages, is necessary to update the package number 05 and all dependencies with the name it containing the word OWIN
5. Of the folder App_Start the files IdentityConfig.cs y Startup.Auth.cs, add it to the folder App_Start of our project 
6. Of the folder Controllers the files  AccountController.cs  y ManageController.cs add it to the folder Controllers of our project 
7. Of the folder Models the files AccountViewModels.cs, IdentityModels.cs and ManageViewModels.cs add it to the folder Models of our project
8. Of the folder Views the folders Accounts and Manager, add it all to the folder Views of the our project.
9. Of the folder ..\Views\Shared the file _LoginPartial.cshtml add it to our project in the folder ..\Views\Shared or the root of the project
10. Copy the file Startup.cs of the roor of projecto to the root of our project

