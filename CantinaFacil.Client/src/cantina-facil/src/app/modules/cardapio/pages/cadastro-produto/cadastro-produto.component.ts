import { AfterViewInit, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { EstabelecimentoService } from '../../services/estabelecimento.service';
import { FormBuilder } from '@angular/forms';
import { AcceleratorMensagemService } from '@npdjunior/ngx-accelerator-tools';
import { Mensagens } from '../../mensagens/mensagens';
import { ActivatedRoute, Router } from '@angular/router';
import { Produto } from '../../models/produto.model';
import { Estabelecimento } from '../../models/estabelecimento.model';

@Component({
  selector: 'cantina-facil-cadastro-produto',
  templateUrl: './cadastro-produto.component.html',
  styleUrls: ['./cadastro-produto.component.scss']
})
export class CadastroProdutoComponent implements OnInit, AfterViewInit {

  cadastroProdutoForm?: any;
  produtoId?: number;
  estabelecimentoId?: number;
  estabelecimentos?: Estabelecimento[] = [];
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

    this.produtoId = +this.route.snapshot.params['produtoId'];
    this.estabelecimentoId = +this.route.snapshot.params['estabelecimentoId'];

    this.obterEstabelecimentos();

    if (this.produtoId){
      this.obterProduto();
      this.textoCadastro = 'Atualizar'
    }
  }

  iniciarlizarFormulario(): void {
    this.cadastroProdutoForm = this.fb.group({
      selectEstabelecimento: [null],
      inputNomeProduto: [null],
      inputValorProduto: [null]
    });

    this.cadastroProdutoForm.get('selectEstabelecimento').disable();
  }

  obterEstabelecimentos(): void {
    this.estabelecimentoService.obterTodos().subscribe(estabelecimentos => {
      this.estabelecimentos = estabelecimentos.data;

      if (estabelecimentos && !this.produtoId) {
        this.cadastroProdutoForm.get('selectEstabelecimento').setValue(this.estabelecimentoId);
      }
    });
  }

  obterProduto(): void {
    if (!this.produtoId)
      return;

    this.estabelecimentoService.obterProduto(this.estabelecimentoId, this.produtoId).subscribe(produto => {
      this.carregarProdutoFormulario(produto.data);
    });
  }

  carregarProdutoFormulario(produto: Produto): void {
    this.cadastroProdutoForm.get('selectEstabelecimento').setValue(produto.estabelecimentoId);
    this.cadastroProdutoForm.get('inputNomeProduto').setValue(produto.nome);
    this.cadastroProdutoForm.get('inputValorProduto').setValue(produto.valor);
  }

  ngAfterViewInit(): void {
    this.changeDetectorRef.detectChanges();
  }

  cadastrarProduto(): void {
    if (this.cadastroProdutoForm.invalid)
      return;

    const produto = this.obterProdutoDoFormulario();
    if (!produto.id)
      this.adicionarProduto(produto);
    else
      this.atualizarProduto(produto);

  }

  adicionarProduto(produto: Produto): void {
    this.estabelecimentoService.adicionarProduto(produto).subscribe(_ => {
      if (!_.success)
        return;

      this.mensagemService.mostrarMensagemDeSucesso(this.mensagens.PRODUTO_CADASTRADO_SUCESSO);
      this.router.navigate(['cardapio']);
    });
  }

  atualizarProduto(produto: Produto): void {
    this.estabelecimentoService.atualizarProduto(produto).subscribe(_ => {
      if (!_.success)
        return;

      this.mensagemService.mostrarMensagemDeSucesso(this.mensagens.PRODUTO_ATUALIZADO_SUCESSO);
      this.router.navigate(['cardapio']);
    });
  }

  obterProdutoDoFormulario(): Produto {
    return {
      id: this.produtoId,
      estabelecimentoId: this.cadastroProdutoForm.get('selectEstabelecimento').value,
      nome: this.cadastroProdutoForm.get('inputNomeProduto').value,
      valor: this.cadastroProdutoForm.get('inputValorProduto').value
    };
  }
}
