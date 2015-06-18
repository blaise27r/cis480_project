using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cis480_project.Models {
    public class Assignment {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public List<EnablingObjective> EnablingObjectives { get; set; }
    }
}