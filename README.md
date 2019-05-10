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
7.- This is the finish of the case

