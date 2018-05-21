export class Gender{
    id:number;
    name:string;
    static initialize(){
        let gender = new Gender();
        gender.id = 0;
        gender.name = null;
        return gender;
    }
}