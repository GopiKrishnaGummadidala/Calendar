using System;
using System.Collections.Generic;
using System.Text;

namespace InCoqnito.Kalender.Models.Models.Response
{
    public class InvitationVM
    {
        public int InvId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double? Rating { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
