export enum Status {
    AVAILABLE ="AVAILABLE", 
    NOT_AVAILABLE="NOT_AVAILABLE", 
    MISSED ="MISSED", 
    NOT_INITIALIZED ="NOT_INITIALIZED",
    CLAIMED ="CLAIMED"
  }
  
export class PrizeInfo {
    private expiration = 60*5 //minutes

    constructor(private status:Status,public description:string, public price:number, public id:number){
    }

    SetAvailable(){
        this.status = Status.AVAILABLE
    }

    IsAvailable () {
        return this.status === Status.AVAILABLE
    }
}
