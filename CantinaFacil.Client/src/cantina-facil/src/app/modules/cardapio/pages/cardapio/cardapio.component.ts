import { Component, OnInit } from '@angular/core';
import { Estabelecimento } from '../../models/estabelecimento.model';
import { EstabelecimentoService } from '../../services/estabelecimento.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AcceleratorAuthService, AcceleratorMensagemService } from '@npdjunior/ngx-accelerator-tools';
import { ConfirmationService, MenuItem } from 'primeng/api';
import { Mensagens } from '../../mensagens/mensagens';
import { Router } from '@angular/router';
import { Produto } from '../../models/produto.model';

@Component({
  selector: 'cantina-facil-cardapio',
  templateUrl: './cardapio.component.html',
  styleUrls: ['./cardapio.component.scss']
})
export class CardapioComponent implements OnInit {

  cardapioForm?: any;
  estabelecimentos?: Estabelecimento[] = [];
  estabelecimentoSelecionado?: Estabelecimento = new Estabelecimento();

  opcoes: MenuItem[] = [];

  mensagens = Mensagens;

  constructor(
    private estabelecimentoService: EstabelecimentoService,
    private authService: AcceleratorAuthService,
    private mensagemService: AcceleratorMensagemService,
    private confirmationService: ConfirmationService,
    private router: Router,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.iniciarlizarFormulario();
    this.inicializarOpcoes();
    this.obterEstabelecimentos();
  }

  iniciarlizarFormulario(): void {
    this.cardapioForm = this.fb.group({
      selectEstabelecimento: [null],
      inputPesquisa: [null]
    });
  }

  inicializarOpcoes() {
    this.opcoes = [
      {
        tooltipOptions: {
          tooltipLabel: 'Adicionar estabelecimento'
        },
        icon: 'pi pi-plus',
        command: () => {
          this.router.navigate(['cardapio/estabelecimentos']);
        }
      },
      {
        tooltipOptions: {
          tooltipLabel: 'Editar estabelecimento'
        },
        icon: 'pi pi-pencil',
        command: () => {
          this.router.navigate(['cardapio/estabelecimentos', this.estabelecimentoSelecionado?.id]);
        }
      },
      {
        tooltipOptions: {
          tooltipLabel: 'Adicionar produto'
        },
        icon: 'pi pi-tag',
        command: () => {
          this.router.navigate(['cardapio/estabelecimentos', this.estabelecimentoSelecionado?.id, 'produtos']);
        }
      },
    ]
  }

  obterEstabelecimentos(estabelecimentoId?: number): void {
    this.estabelecimentoService.obterTodos().subscribe(estabelecimentos => {
      this.estabelecimentos = estabelecimentos.data;

      if (estabelecimentos && !estabelecimentoId) {
        this.cardapioForm.get('selectEstabelecimento').setValue(this.estabelecimentos[0].id);
        this.estabelecimentoSelecionado = this.estabelecimentos[0];
      } else {
        this.cardapioForm.get('selectEstabelecimento').setValue(estabelecimentoId);
        this.estabelecimentoSelecionado = this.estabelecimentos.find(e => e.id == estabelecimentoId);
      }
    });
  }

  selecionarEstabelecimento(): void {
    const estabelecimentoSelecionadoId = this.cardapioForm?.get('selectEstabelecimento')?.value;
    this.estabelecimentoSelecionado = this.estabelecimentos?.find(e => e.id == estabelecimentoSelecionadoId);
  }

  removerProduto(produto: Produto): void {
    this.confirmationService.confirm({
      message: Mensagens.CONFIRMAR_EXCLUSAO_PRODUTO,
      key: 'confirm1',
      accept: () => {
        this.estabelecimentoService.removerProduto(produto.estabelecimentoId, produto.id).subscribe(_ => {
          this.obterEstabelecimentos(produto.estabelecimentoId);
          this.mensagemService.mostrarMensagemDeSucesso(this.mensagens.PRODUTO_EXCLUIDO_SUCESSO);
        });
      },
      reject: (type: any) => {

      }
    });
  }

  irParaEdicaoProduto(produtoId?: number): void {
    this.router.navigate(['cardapio/estabelecimentos/', this.estabelecimentoSelecionado?.id, 'produtos', produtoId]);
  }
}
