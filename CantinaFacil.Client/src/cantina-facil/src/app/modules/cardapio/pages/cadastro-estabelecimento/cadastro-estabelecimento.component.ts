import { AfterViewInit, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { EstabelecimentoService } from '../../services/estabelecimento.service';
import { FormBuilder } from '@angular/forms';
import { AcceleratorMensagemService } from '@npdjunior/ngx-accelerator-tools';
import { Mensagens } from '../../mensagens/mensagens';
import { Estabelecimento } from '../../models/estabelecimento.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'cantina-facil-cadastro-estabelecimento',
  templateUrl: './cadastro-estabelecimento.component.html',
  styleUrls: ['./cadastro-estabelecimento.component.scss']
})
export class CadastroEstabelecimentoComponent implements OnInit, AfterViewInit {

  cadastroEstabelecimentoForm?: any;
  estabelecimentoId?: number;
  mensagens = Mensagens;
  textoCadastro?: string = 'Adicionar';

  constructor(
    private estabelecimentoService: EstabelecimentoService,
    private mensagemService: AcceleratorMensagemService,
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private changeDetectorRef: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.iniciarlizarFormulario();

    this.estabelecimentoId = +this.route.snapshot.params['estabelecimentoId'];

    if (this.estabelecimentoId){
      this.obterEstabelecimento();
      this.textoCadastro = 'Atualizar'
    }
  }

  iniciarlizarFormulario(): void {
    this.cadastroEstabelecimentoForm = this.fb.group({
      inputNomeEstabelecimento: [null],
      maskCnpj: [null]
    });
  }

  obterEstabelecimento(): void {
    if (!this.estabelecimentoId)
      return;

    this.estabelecimentoService.obter(this.estabelecimentoId).subscribe(estabelecimento => {
      this.carregarEstabelecimentoFormulario(estabelecimento.data);
    });
  }

  carregarEstabelecimentoFormulario(estabelecimento: Estabelecimento): void {
    this.cadastroEstabelecimentoForm.get('inputNomeEstabelecimento').setValue(estabelecimento.nome);
    this.cadastroEstabelecimentoForm.get('maskCnpj').setValue(estabelecimento.cnpj);
  }

  ngAfterViewInit(): void {
    this.changeDetectorRef.detectChanges();
  }

  cadastrarEstabelecimento(): void {
    if (this.cadastroEstabelecimentoForm.invalid)
      return;

    const estabelecimento = this.obterEstabelecimentoDoFormulario();
    if (!estabelecimento.id)
      this.adicionarEstabelecimento(estabelecimento);
    else
      this.atualizarEstabelecimento(estabelecimento);

  }

  adicionarEstabelecimento(estabelecimento: Estabelecimento): void {
    this.estabelecimentoService.adicionar(estabelecimento).subscribe(_ => {
      if (!_.success)
        return;

      this.mensagemService.mostrarMensagemDeSucesso(this.mensagens.ESTABELECIMENTO_CADASTRADO_SUCESSO);
      this.router.navigate(['cardapio']);
    });
  }

  atualizarEstabelecimento(estabelecimento: Estabelecimento): void {
    this.estabelecimentoService.atualizar(estabelecimento).subscribe(_ => {
      if (!_.success)
        return;

      this.mensagemService.mostrarMensagemDeSucesso(this.mensagens.ESTABELECIMENTO_ATUALIZADO_SUCESSO);
      this.router.navigate(['cardapio']);
    });
  }

  obterEstabelecimentoDoFormulario(): Estabelecimento {
    return {
      id: this.estabelecimentoId,
      nome: this.cadastroEstabelecimentoForm.get('inputNomeEstabelecimento').value,
      cnpj: this.cadastroEstabelecimentoForm.get('maskCnpj').value
    };
  }
}
