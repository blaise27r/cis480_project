using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cis480_project.Models {
    public class EnablingObjective {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public Objective Objective { get; set; }
        [ForeignKey("Objective")]
        public int ObjectiveId { get; set; }
    }
}