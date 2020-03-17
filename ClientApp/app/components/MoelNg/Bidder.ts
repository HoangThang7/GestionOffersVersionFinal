import { Address } from "./Address";
import { Offer } from "./Offer";
import { Plis } from "./Plis";

export class Bidder {

    constructor() { }

    id: number;
    firstName: string;
    lastName: string;
    email: string;
    tel: number;
    fax: string;
    domaine: string;
    typeEnterprise: string;   
    address: Address;
    offer: Offer;
    plis: Array<Plis>;
}