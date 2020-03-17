import { Categorie } from "./Categorie";
import { Documents } from "./Documents";
import { Direction } from "./Direction";
import { Commission } from "./Commission";



export class Offer {


    constructor() {

    }

    id: number
    code: string
    categorie: Categorie
    direction: Direction
    etat: string
    intitule: string
    description: string
    placeDepot: string
    dateLimit: Date
    placeOpened: string
    dateOpened: Date
    dateCreation: Date
    timeOpened: string
    publish: boolean
    documents: Array<File>
    commission: Commission
    manager: string
}