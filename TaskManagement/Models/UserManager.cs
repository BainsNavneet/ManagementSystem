using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagment.Models;

namespace TaskManagement.Models
{
    public class UserManager
    {
        ApplicationDbContext db = new ApplicationDbContext();
        UserManager<ApplicationUser> usersManager;
        public UserManager(ApplicationDbContext db)
        {
            this.db = db;
            usersManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ;
        }
        
        public bool AddUserToRole(string userId, string roleName)
        {
            var result = usersManager.AddToRole(userId, roleName);
            return result.Succeeded;
        }
        public bool RemoveUserFromRole(string userId, string roleName)
        {
            var result = usersManager.RemoveFromRole(userId, roleName);
            return result.Succeeded;
        }
        public bool RemoveUser(string userId, string roleName)
        {
            var result = usersManager.AddToRole(userId, roleName);
            return result.Succeeded;
        }
        
    }
}