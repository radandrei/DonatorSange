export class UnitStatus{
    id:number;
    name:string;
    static initialize(){
        let status = new UnitStatus();
        status.id =1;
        status.name = 'Registered';
        return status;
    }
}