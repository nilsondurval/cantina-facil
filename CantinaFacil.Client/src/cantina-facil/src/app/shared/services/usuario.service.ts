import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ResponseCustom, Usuario } from "@npdjunior/ngx-accelerator-tools";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";

@Injectable()
export class UsuarioService {

    constructor(
        private http: HttpClient
    ) { }

    adicionar(usuario: Usuario): Observable<ResponseCustom<void>> {
        return this.http.post<ResponseCustom<void>>(`${environment.pathApi}/usuarios`, usuario);
    }
}