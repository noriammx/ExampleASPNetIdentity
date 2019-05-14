using AspNetWithIdentity.ModelDB;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetWithIdentity.Models
{
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
}