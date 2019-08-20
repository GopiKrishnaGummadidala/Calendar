export class RatingRequest{
    public invId: number;
    public empId: number;
    public rating: number;
    constructor(invId = 0, empId = 0, rating = 0) {
      this.invId = invId;
      this.empId = empId;
      this.rating = rating;
    }
}