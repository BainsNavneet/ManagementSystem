﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskManagment.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       
        public virtual ICollection<Task> Tasks { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class Project
    {
        public int Id { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public string ProjectName { get; set; }
        public bool Status { get; set; }
        public DateTime Complitiondate { get; set; }
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

    }
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<ApplicationUser> Developers { get; set; }
        public int? Percentage { get; set; }
        public Task()
        {
            Developers = new HashSet<ApplicationUser>();
            Percentage = 0;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}