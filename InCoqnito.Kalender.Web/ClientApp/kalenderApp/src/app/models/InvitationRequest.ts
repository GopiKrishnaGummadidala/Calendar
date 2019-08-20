import { IEmployee } from './IEmployeeDto';

export class InvitationRequest{
    public authorId: number;
    public date: string;
    public startTime: string;
    public endTime: string;
    public description: string;
    public sharedEmails: IEmployee[];
    constructor(authorId = 0, date = '', startTime = '', endTime = '', description = '', sharedEmails = []) {
      this.authorId = authorId;
      this.date = date;
      this.startTime = startTime;
      this.endTime = endTime;
      this.description = description;
      this.sharedEmails = sharedEmails;
    }
}
