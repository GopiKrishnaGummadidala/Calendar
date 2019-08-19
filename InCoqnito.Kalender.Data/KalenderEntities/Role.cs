using System;
using System.Collections.Generic;
using System.Text;

namespace InCoqnito.Kalender.Data.KalenderEntities
{
    public partial class Role
    {
        public Role()
        {
            Employee = new HashSet<Employee>();
        }

        public int RoleId { get; set; }
        public string RoleType { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
