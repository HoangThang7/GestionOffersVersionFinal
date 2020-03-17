import { Plis } from "./Plis";
import { Contract } from "./Contract";


export class Depouillement {

    constructor() {

    }

    id: number
    noteFinance: number
    noteTechnical: number
    transCript: string
    dateDepouille: Date
    comment: string
    plisId: number
    contract: Contract
}