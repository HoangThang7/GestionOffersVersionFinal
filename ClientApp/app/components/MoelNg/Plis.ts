import { Depouillement } from './Depouillement';
import { Offer } from './Offer';
import { Bidder } from './Bidder';

export class Plis {

    constructor() {

    }

    id: number
    code: string
    libelle: string
    dateDepot: Date
    typeDepot: string
    offerId: number
    bidderId: number
    depouille: Depouillement
}

