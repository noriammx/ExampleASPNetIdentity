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

**Remember, if you want use the custom database is necessary change the connection string as the step 4 of the case 1, like this:**

```xml
 <!--<add name="DefaultConnection" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-AspNetWithIdentity-20190510110134.mdf;Initial Catalog=aspnet-AspNetWithIdentity-20190510110134;Integrated Security=True" providerName="System.Data.SqlClient" />-->
    <add name="DefaultConnection" connectionString="Data Source=.;Initial Catalog=ExampleASPNetMVCIdentity;persist security info=True;user id=sa;password=Corepro1;multipleactiveresultsets=True;" providerName="System.Data.SqlClient" />
```

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
**Remember this files can be copied of the another project created with ASP Net Identity**

4. After the installation of the Nuget Packages, is necessary to update the package number 05 and all dependencies with the name it containing the word OWIN
5. Of the folder App_Start the files IdentityConfig.cs y Startup.Auth.cs, add it to the folder App_Start of our project 
6. Of the folder Controllers the files  AccountController.cs  y ManageController.cs add it to the folder Controllers of our project 
7. Of the folder Models the files AccountViewModels.cs, IdentityModels.cs and ManageViewModels.cs add it to the folder Models of our project
8. Of the folder Views the folders Accounts and Manager, add it all to the folder Views of the our project.
9. Of the folder ..\Views\Shared the file _LoginPartial.cshtml add it to our project in the folder ..\Views\Shared or the root of the project
10. Copy the file Startup.cs of the roor of projecto to the root of our project
11. That's all, We have finished

## Case 2 - Adding Custom Roles and Autorization to Controllers

1. In any case you can use custom roles, but is necessary add the next code in the file Startup.Auth.cs:

```c#
  public class CustomAuthAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/Home/AccessDenied");
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
```
*The code before is a class, therefore, is necessary add to the final the class in the same file.*

2. In the controllers at you want put security and autorization add de tag [Authorize] and the tag [CustomAuthAttribute(Roles = "Contabilidad")] with the custom role at you have created.

3. For create automatic way a custom roles and users, you can create a Class with the instrucctions, like this:

```c#

 public class IdentityInit
    {
        public static void InitializeIdentityForEF()
        {

            ApplicationDbContext context = new ApplicationDbContext();

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string adminName = "admin@coreprocesses.com.mx";

            //System's profiles
            var AdministradorSistema = "Administrador";
            var Contabilidad = "Contabilidad";

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(AdministradorSistema))
            {
                var roleresult = RoleManager.Create(new IdentityRole(AdministradorSistema));
            }

            if (!RoleManager.RoleExists(Contabilidad))
            {
                var roleresult = RoleManager.Create(new IdentityRole(Contabilidad));
            }

            //Create User Admin
            if (UserManager.FindByName(adminName) == null)
            {
                var user = new ApplicationUser();
                user.UserName = adminName;
                user.Email = "admin@coreprocesses.com.mx";
                var adminresult = UserManager.Create(user, "Corepro1");

                using (ExampleSecurityEntities db = new ExampleSecurityEntities())
                {
                    db.Database.ExecuteSqlCommand("INSERT INTO [CAT_USUARIOS] ([NOMBRE], [APPELIDO_PATERNO], [APELLIDO_MATERNO], [USUARIO], [ROL], [CORREO]) VALUES('Admin', 'Admin', 'Admin', 'admin', 'Administrador', 'notificaciones.hcud@coreprocesses.com.mx')");
                }

                //Add User Admin to Role Admin
                if (adminresult.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, AdministradorSistema);
                }
               
            }

            //Create Another user
            if (UserManager.FindByName("lmartinez") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "lmartinez@coreprocesses.com.mx";
                user.Email = "lmartinez@coreprocesses.com.mx";
                var adminresult = UserManager.Create(user, "Corepro1");

                using (ExampleSecurityEntities db = new ExampleSecurityEntities())
                {
                    db.Database.ExecuteSqlCommand("INSERT INTO [CAT_USUARIOS] ([NOMBRE], [APPELIDO_PATERNO], [APELLIDO_MATERNO], [USUARIO], [ROL], [CORREO]) VALUES('Luis', 'Martinez', 'Candelero', 'lmartinez', 'Contabilidad', 'lmartinez.hcud@coreprocesses.com.mx')");
                }

                //Add User Admin to Role Admin
                if (adminresult.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, Contabilidad);
                }

            }
        }

    }

```
4. Add the method at the beginning of file Startup.cs, like this:

```c#
  public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            IdentityInit.InitializeIdentityForEF();
        }
    }

```
5. And that's all about this example, thank you for reading me.


