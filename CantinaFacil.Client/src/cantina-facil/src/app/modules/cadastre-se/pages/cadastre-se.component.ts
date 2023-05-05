import { AfterViewInit, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AcceleratorAuthService, AcceleratorHideMasterPageService } from '@npdjunior/ngx-accelerator-tools';
import { Mensagens } from '../mensagens/mensagens';
import { PerfilService } from '../../../shared/services/perfil.service';
import { Perfil } from '../../../shared/models/perfil.model';

@Component({
  selector: 'cantina-facil-cadastre-se',
  templateUrl: './cadastre-se.component.html',
  styleUrls: ['./cadastre-se.component.scss']
})
export class CadastreSeComponent implements OnInit, AfterViewInit {

  cadastreSeForm: any;

  mensagens = Mensagens

  perfis: Perfil[] = [];

  constructor(
    private perfilService: PerfilService,
    private authService: AcceleratorAuthService,
    private hideMasterPageService: AcceleratorHideMasterPageService,
    private router: Router,
    private fb: FormBuilder,
    private changeDetectorRef: ChangeDetectorRef
  ) {
    this.hideMasterPageService.hide();
  }

  ngOnInit(): void {
    this.iniciarlizarFormulario();
    this.obterPerfis();
  }

  iniciarlizarFormulario(): void {
    this.cadastreSeForm = this.fb.group({
      radioButtonPerfil: [null],
      maskCpf: [null],
      inputNome: [null],
      inputEmail: [null],
      maskTelefone: [null],
      inputSenha: [null],
      inputConfirmarSenha: [null]
    });
  }

  obterPerfis(): void {
    this.perfilService.obterTodos().subscribe(response => {
      this.perfis = response.data;
      this.cadastreSeForm.get('radioButtonPerfil').disable();
      this.cadastreSeForm.get('radioButtonPerfil').setValue(this.perfis.find(p => p.nome == 'Cantina')?.id);
    });
  }

  ngAfterViewInit(): void {
    this.changeDetectorRef.detectChanges();
  }

  cadastrar(): void {
    if (this.cadastreSeForm.invalid)
      return;
  }

  irParaLogin(event: any): void {
    this.router.navigate(['login']);
  }
}
