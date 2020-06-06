using _8_MVC_Login.Models.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _8_MVC_Login.Models.Data.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=REIS\MSSQL2014;Database=AccountDB;UID=sa;PWD=Qaz-1234";
        }

        public DbSet<ApplicationUser> User { get; set; }
    }
}