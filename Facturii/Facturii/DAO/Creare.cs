using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.SqlClient;
using Facturii.Models;
using System.Collections.Generic;
using System.Text;

namespace Facturii.Operatii
{
    public class Creare
    {
        static string idAdmin;
        static string idConsumator;
        static string idCompanie;
        public String createRolesandUsers(String email)
        {
            Models.ApplicationDbContext context = new Models.ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<Models.ApplicationUser>(new UserStore<Models.ApplicationUser>(context));

            var user = new ApplicationUser();
            string[] s = email.Split('@');
            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (s[1].Equals("admin.com"))
            {
                if (!roleManager.RoleExists("Admin"))
                {

                    // first we create Admin rool   
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);
                    idAdmin = role.Id;
                }
                else
                {
                    var val = roleManager.FindByName("Admin").Id;
                    idAdmin = val;
                }
                return idAdmin+" "+"admin";
            }

            if (s[1].Equals("gmail.com") || s[1].Equals("yahoo.com"))
            {
                if (!roleManager.RoleExists("consumator"))
                {
                    var roles = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    roles.Name = "consumator";
                    roleManager.Create(roles);
                    idConsumator = roles.Id;
                }
                else
                {
                    var val = roleManager.FindByName("consumator").Id;
                    idConsumator = val;
                }
                return idConsumator + " " + "consumator";
            }
            if (!s[1].Equals("gmail.com") && !s[1].Equals("yahoo.com") && !s[1].Equals("admin.com"))
            {
                if (!roleManager.RoleExists("companie"))
                {
                    var roles = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    roles.Name = "companie";
                    roleManager.Create(roles);
                    idCompanie = roles.Id;
                }
                else
                {
                    var val = roleManager.FindByName("companie").Id;
                    idCompanie = val;
                }
                return idCompanie + " " + "companie";


            }
            return null;

        }
            static string cale = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection myCommand = new SqlConnection(cale);
            public bool Introducere(string userId, string roleid)
            {
                myCommand.Open();
                string queryStr = "Insert into AspNetUserRoles(UserId,RoleId) values ('" + userId + "','" + roleid + "')";
                SqlCommand comend = new SqlCommand(queryStr);
                comend.Connection = myCommand;
                comend.ExecuteNonQuery();
                if (queryStr != null)
                    return true;
                return false;
            }
       
       
       
    }
    
    
}