import { MedicalRequest } from "./medicalrequest";

export class RequestWithQuantity{
    constructor(
        public request: MedicalRequest,
        public distributionQuantity: number
    ){}
}