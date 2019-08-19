using System;
using System.Collections.Generic;

namespace InCoqnito.Kalender.Data.KalenderEntities
{
    public partial class Invitation
    {
        public Invitation()
        {
            EmployeeInvitationMap = new HashSet<EmployeeInvitationMap>();
        }

        public int InvitationId { get; set; }
        public string InvitationDescription { get; set; }
        public DateTime InvDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int CreatedBy { get; set; }
        public double? Rating { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual ICollection<EmployeeInvitationMap> EmployeeInvitationMap { get; set; }
    }
}
