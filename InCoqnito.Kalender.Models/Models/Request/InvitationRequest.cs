using InCoqnito.Kalender.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InCoqnito.Kalender.Models.Models.Request
{
    public class InvitationRequest
    {
        public int AuthorId { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Description { get; set; }
        public List<EmployeeDto> SharedEmails { get; set; }
    }
}
