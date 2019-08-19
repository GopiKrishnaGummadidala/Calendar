using System;
using System.Collections.Generic;

namespace InCoqnito.Kalender.Data.KalenderEntities
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeInvitationMap = new HashSet<EmployeeInvitationMap>();
            Invitation = new HashSet<Invitation>();
        }

        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmailId { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<EmployeeInvitationMap> EmployeeInvitationMap { get; set; }
        public virtual ICollection<Invitation> Invitation { get; set; }
    }
}
