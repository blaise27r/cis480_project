using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cis480_project.Models {
    public class AssignmentEnablingObjective {
        //bridge entity for m:n relationship

        [Key]
        public int Id { get; set; }

        public Assignment Assignment { get; set; }
        [ForeignKey("Assignment")]
        public int AssignmentId { get; set; }

        public EnablingObjective EnablingObjective { get; set; }
        [ForeignKey("EnablingObjective")]
        public int EnablingObjectiveId { get; set; }
    }
}