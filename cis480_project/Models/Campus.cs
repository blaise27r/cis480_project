using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace cis480_project.Models {
    public class Campus {
        public int Id { get; set; }
        public string Name { get; set; }

        //check entity documentation
//        public virtual List<Course> Courses { get; set; }
    }

}