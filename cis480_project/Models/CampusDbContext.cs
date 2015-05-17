using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cis480_project.Models {
    public class CampusDbContext : DbContext {

        //not sure if i need this yet
        //public CampusDbContext() : base("CampusDbContext") {
            
        //}

        public CampusDbContext() : base() { }

        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}