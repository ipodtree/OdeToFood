namespace OdeToFood.Migrations
{
    using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            context.Restaurant.AddOrUpdate(r => r.Name,
            new Restaurant { Name = "abc", City = "Paris", Country = "France" },
            new Restaurant { Name = "def", City = "London", Country = "England" },
            new Restaurant
            {
                Name = "ghi",
                City = "Pekin",
                Country = "China",
                Reviews = new List<RestaurantReview>{
                new RestaurantReview{Rating=9,Body="great food!",ReviewerName="Scott"}
            }
            });

            for(int i=0;i<1000;i++)
            {
                context.Restaurant.AddOrUpdate(r => r.Name,
                new Restaurant { Name=i.ToString(), City="Nowhere", Country="USA"}
                    );
            }

            SeedMembership();
        }
        private void SeedMembership(){
              WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            
              var roles=(SimpleRoleProvider)Roles.Provider;
              var membership=(SimpleMembershipProvider)Membership.Provider;

            if(!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if(membership.GetUser("clement",false)==null)
            {
                membership.CreateUserAndAccount("clement","imalittleteapot");
            }
            if(!roles.GetRolesForUser("clement").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] {"clement"},new[]{"admin"});
            }
        }
        
    }
}
