using System;
using System.Collections.Generic;

namespace InCoqnito.Kalender.Data.KalenderEntities
{
    public partial class EmployeeInvitationMap
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int InvitationId { get; set; }
        public bool? IsAccepted { get; set; }
        public string Comments { get; set; }
        public int? Rating { get; set; }

        public Employee Emp { get; set; }
        public Invitation Invitation { get; set; }
    }
}
