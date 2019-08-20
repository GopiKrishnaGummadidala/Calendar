namespace InCoqnito.Kalender.Models.Models.Request
{
    public class InvitationUpdateRequest
    {
        public int InvId { get; set; }
        public int EmpId { get; set; }
        public bool Status { get; set; }
        public string Comments { get; set; }
    }
}
