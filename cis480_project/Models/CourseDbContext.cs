using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cis480_project.Models {
    public class CourseDbContext : DbContext {

        //not sure if i need this yet
        //public CourseDbContext() : base("CourseDbContext") {
            
        //}

        public CourseDbContext() : base() { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Objective> Objectives { get; set; }
    }
}