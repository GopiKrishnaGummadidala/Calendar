using InCoqnito.Kalender.Data;
using InCoqnito.Kalender.Models.DTOs;
using InCoqnito.Kalender.Models.Models.Request;
using InCoqnito.Kalender.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InCoqnito.Kalender.Application.Invitation.Commands.Create
{
    public class CreateInvitationCommandHandler : IRequestHandler<CreateInvitationCommand, bool>
    {
        private readonly KalenderDBContext _kalenderDb;
        public CreateInvitationCommandHandler(KalenderDBContext kalenderDb)
        {
            _kalenderDb = kalenderDb;
        }
        public async Task<bool> Handle(CreateInvitationCommand request, CancellationToken cancellationToken)
        {
            bool response = false;
            try
            {
                var startTime = new TimeSpan(09, 00, 00);
                var endTime = new TimeSpan(09, 30, 00);
                var date = Convert.ToDateTime(request.invitationRequest.Date); // To Do
                await _kalenderDb.Invitation.AddAsync(new Data.KalenderEntities.Invitation
                {
                    CreatedBy = request.invitationRequest.AuthorId,
                    InvitationDescription = request.invitationRequest.Description,
                    InvDate = date,
                    StartTime = startTime,
                    EndTime = endTime,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                });

                var res = await _kalenderDb.SaveChangesAsync();
                if(res > 0)
                {
                    var invId = _kalenderDb.Invitation.OrderByDescending(i => i.InvitationId).FirstOrDefault().InvitationId;
                    response = MapEmployeeInvitation(invId, request.invitationRequest);
                }

            }
            catch (Exception e)
            {
                //TO DO Exception Logging
            }
            return response;
        }

        private bool MapEmployeeInvitation(int invitationId, InvitationRequest request)
        {
            bool retRes = false;
            try
            {
                foreach (var employee in request.SharedEmails)
                {
                    _kalenderDb.EmployeeInvitationMap.Add(new Data.KalenderEntities.EmployeeInvitationMap()
                    {
                        InvitationId = invitationId,
                        EmpId = employee.Id,
                    });
                }

                _kalenderDb.SaveChanges();
                retRes = EmailSending(request.SharedEmails.Select(s=>s.EmailId).ToList(),"", request.Description);
            }
            catch(Exception e)
            {
                //To do exception logging
            }

            return retRes;
        }

        private bool EmailSending(List<string> emailIds, string author, string invDescription)
        {
            bool retRes = false;

            try
            {
                var emailTemplate = _kalenderDb.EmailTemplate.FirstOrDefault(t => t.Template == "InvitationEmail");
                if(emailTemplate != null)
                {
                    emailTemplate.Template = emailTemplate.Template.Replace("[Author]", author).Replace("[Description]", invDescription);
                    retRes = MailHelper.SendMail(emailTemplate.Template, "", emailIds);
                }
            }
            catch(Exception e)
            {
                //To do exception logging
            }

            return retRes;
        }
    }
}
