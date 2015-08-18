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

        //tables
        public DbSet<Course> Courses { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<EnablingObjective> EnablingObjectives { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentEnablingObjective> AssignmentEnablingObjectives { get; set; }
        public DbSet<UnitAssignment> UnitAssignments { get; set; } 
       
    }
}
