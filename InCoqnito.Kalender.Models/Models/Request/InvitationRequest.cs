using InCoqnito.Kalender.Models.DTOs;
using System;
using System.Collections.Generic;

namespace InCoqnito.Kalender.Models.Models.Request
{
    public class InvitationRequest
    {
        public InvitationRequest()
        {
            SharedEmails = new List<EmployeeDto>();
        }
        public int AuthorId { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Description { get; set; }
        public List<EmployeeDto> SharedEmails { get; set; }
    }
}
