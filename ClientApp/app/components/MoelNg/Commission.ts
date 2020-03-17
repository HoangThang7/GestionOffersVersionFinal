import { User } from "./User";



export class Commission {

    constructor() {}

    id: number
    code: string;
    libelle: string;
    members: Array<User>;
}