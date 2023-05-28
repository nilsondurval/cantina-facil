import { Produto } from "./produto.model";

export class Estabelecimento {
    id?: number;
    usuarioId?: number;
    nome?: string;
    cnpj?: string;
    produtos?: Produto[];

    constructor() {
        this.produtos = [];
    }
}