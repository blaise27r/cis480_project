using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cis480_project.Models {
    public class Unit {
        [Key]   //PK
        public int Id { get; set; }

        public int WeekNumber { get; set; }

        public Course Course { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
    }
}