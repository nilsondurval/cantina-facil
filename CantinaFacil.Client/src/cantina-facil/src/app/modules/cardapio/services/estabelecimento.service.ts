import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ResponseCustom } from "@npdjunior/ngx-accelerator-tools";
import { Observable } from "rxjs";
import { Estabelecimento } from "../models/estabelecimento.model";
import { environment } from "../../../../environments/environment";
import { Produto } from "../models/produto.model";

@Injectable()
export class EstabelecimentoService {

    constructor(
        private http: HttpClient
    ) { }

    adicionar(estabelecimento: Estabelecimento): Observable<ResponseCustom<void>> {
        return this.http.post<ResponseCustom<void>>(`${environment.pathApi}/estabelecimentos`, estabelecimento);
    }
    
    obter(estabelecimentoId: number): Observable<ResponseCustom<Estabelecimento>> {
        return this.http.get<ResponseCustom<Estabelecimento>>(`${environment.pathApi}/estabelecimentos/${estabelecimentoId}`);
    }
    
    obterTodos(): Observable<ResponseCustom<Estabelecimento[]>> {
        return this.http.get<ResponseCustom<Estabelecimento[]>>(`${environment.pathApi}/estabelecimentos`);
    }

    atualizar(estabelecimento: Estabelecimento): Observable<ResponseCustom<void>> {
        return this.http.put<ResponseCustom<void>>(`${environment.pathApi}/estabelecimentos/${estabelecimento.id}`, estabelecimento);
    }

    remover(estabelecimentoId: number): Observable<ResponseCustom<void>> {
        return this.http.delete<ResponseCustom<void>>(`${environment.pathApi}/estabelecimentos/${estabelecimentoId}`);
    }

    adicionarProduto(produto: Produto): Observable<ResponseCustom<void>> {
        return this.http.post<ResponseCustom<void>>(`${environment.pathApi}/estabelecimentos/${produto.estabelecimentoId}/produtos`, produto);
    }

    atualizarProduto(produto: Produto): Observable<ResponseCustom<void>> {
        return this.http.put<ResponseCustom<void>>(`${environment.pathApi}/estabelecimentos/${produto.estabelecimentoId}/produtos`, produto);
    }

    removerProduto(produto: Produto): Observable<ResponseCustom<void>> {
        return this.http.delete<ResponseCustom<void>>(`${environment.pathApi}/estabelecimentos/${produto.estabelecimentoId}/produtos/${produto.id}`);
    }
}