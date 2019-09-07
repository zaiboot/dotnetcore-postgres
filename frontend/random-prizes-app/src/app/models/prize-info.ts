export enum Status {
    Missed,
    Available,
    Unavailable,
    Unknown
  }
  
export class PrizeInfo {
    private expiration = 60*5 //minutes

    constructor(private status:Status,public description:string, public price:number, public id:number){
    }

    SetAvailable(){
        this.status = Status.Available
    }

    IsAvailable () {
        return this.status === Status.Available
    }
}
