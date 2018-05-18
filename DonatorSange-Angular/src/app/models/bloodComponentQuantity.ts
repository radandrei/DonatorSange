import { BloodComponent } from "./bloodComponent";

export class BloodComponentQuantity{
    bloodComponent: BloodComponent;
    quantity: number;

    constructor(bloodComponent, quantity){
        this.bloodComponent=bloodComponent;
        this.quantity=quantity;
    }
}