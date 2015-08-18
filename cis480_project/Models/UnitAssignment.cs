using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cis480_project.Models {
    public class UnitAssignment {
        [Key]   //PK
        public int Id { get; set; }

        public int WeekNumber { get; set; }

        public Unit Unit { get; set; }
        [ForeignKey("Unit")]
        public int UnitId { get; set; }
    }
}