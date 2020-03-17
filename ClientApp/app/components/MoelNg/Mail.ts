import { Bidder } from "./Bidder";
import { Offer } from "./Offer";

export class Mail {

    constructor() {
    
    }

    author: string
    destinations: Array<string>
    offer: Offer
    password: string
    documents: Array<string>
}