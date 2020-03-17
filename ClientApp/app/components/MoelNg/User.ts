import { Address } from "./Address";
import { Provider } from "./Provider";

export class User {

    constructor() { }

    id: number;
    firstName: string;
    lastName: string;
    mail: string;
    password: string;
    date: Date;
    numberTel: number;
    type: number;
    address: Address;
    provider: Provider;
}