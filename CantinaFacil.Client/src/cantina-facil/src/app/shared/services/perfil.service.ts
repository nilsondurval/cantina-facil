import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Perfil } from "../models/perfil.model";
import { ResponseCustom } from "@npdjunior/ngx-accelerator-tools";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";

@Injectable()
export class PerfilService {

    constructor(
        private http: HttpClient
    ) { }

    obterTodos(): Observable<ResponseCustom<Perfil[]>> {
        return this.http.get<ResponseCustom<Perfil[]>>(`${environment.pathApi}/perfis`);
    }
}