import { AfterViewInit, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AcceleratorAuthService, AcceleratorHideMasterPageService } from '@npdjunior/ngx-accelerator-tools';
import { Mensagens } from '../mensagens/mensagens';

@Component({
  selector: 'cantina-facil-cadastre-se',
  templateUrl: './cadastre-se.component.html',
  styleUrls: ['./cadastre-se.component.scss']
})
export class CadastreSeComponent implements OnInit, AfterViewInit {

  cadastreSeForm: any;

  mensagens = Mensagens

  constructor(
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
  }

  ngAfterViewInit(): void {
    this.changeDetectorRef.detectChanges();
  }

  iniciarlizarFormulario(): void {
    this.cadastreSeForm = this.fb.group({
      maskCpf: [null],
      inputNome: [null],
      inputEmail: [null],
      maskTelefone: [null],
      inputSenha: [null],
      inputConfirmarSenha: [null]
    });
  }

  cadastrar(): void {
    if (this.cadastreSeForm.invalid)
      return;
  }

  irParaLogin(event: any): void {
    this.router.navigate(['login']);
  }
}
