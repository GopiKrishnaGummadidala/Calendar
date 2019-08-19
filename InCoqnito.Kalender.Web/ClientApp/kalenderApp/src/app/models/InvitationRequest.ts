export class InvitationRequest{
    public authorId: number;
    public date: Date;
    public startTime: string;
    public endTime: string;
    public description: string;
    constructor(authorId = 0, date = null, startTime = '', endTime = '', description = '') {
      this.authorId = authorId;
      this.date = date;
      this.startTime = startTime;
      this.endTime = endTime;
      this.description = description;
    }
}
