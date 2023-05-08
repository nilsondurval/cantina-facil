import { AfterViewInit, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AcceleratorHideMasterPageService, AcceleratorMensagemService } from '@npdjunior/ngx-accelerator-tools';
import { Mensagens } from '../mensagens/mensagens';
import { PerfilService } from '../../../shared/services/perfil.service';
import { Perfil } from '../../../shared/models/perfil.model';
import { UsuarioService } from '../../../shared/services/usuario.service';
import { Usuario } from '../../../shared/models/usuario.model';

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
    private usuarioService: UsuarioService,
    private perfilService: PerfilService,
    private mensagemService: AcceleratorMensagemService,
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
      if (!response.success || !response.data)
        return;

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

    const usuario = this.obterUsuarioDoFormulario();
    const confirmacaoSenha = this.cadastreSeForm.get('inputConfirmarSenha').value;

    if (usuario.senha !== confirmacaoSenha) {
      this.mensagemService.mostrarMensagemDeAtencao(this.mensagens.CONFIRMACAO_SENHA_INVALIDA);
      return;
    }

    this.usuarioService.adicionar(usuario).subscribe(_ => {
      if (!_.success)
        return;

      this.mensagemService.mostrarMensagemDeSucesso(this.mensagens.USUARIO_CADASTRADO_SUCESSO);
      this.router.navigate(['login']);
    });
  }

  obterUsuarioDoFormulario(): Usuario {
    return {
      perfilId: this.cadastreSeForm.get('radioButtonPerfil').value,
      cpf: this.cadastreSeForm.get('maskCpf').value,
      nome: this.cadastreSeForm.get('inputNome').value,
      email: this.cadastreSeForm.get('inputEmail').value,
      senha: this.cadastreSeForm.get('inputSenha').value,
      telefone: this.cadastreSeForm.get('maskTelefone').value
    };
  }

  irParaLogin(event: any): void {
    this.router.navigate(['login']);
  }
}
