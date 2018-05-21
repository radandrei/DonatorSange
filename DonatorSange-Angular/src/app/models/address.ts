export class Address{
    id:number;
    city:string;
    country:string;
    county:string;
    number:number;
    street:string;
    static initialize(){
        let address = new Address();
        address.id = 0;
        address.city = null;
        address.country = 'Romania';
        address.county = null;
        address.number = 0;
        address.street = null;
        return address;
    }
}