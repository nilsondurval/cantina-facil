import { Component, OnInit } from '@angular/core';
import { Estabelecimento } from '../../models/estabelecimento.model';
import { EstabelecimentoService } from '../../services/estabelecimento.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AcceleratorAuthService } from '@npdjunior/ngx-accelerator-tools';
import { MenuItem } from 'primeng/api';
import { Mensagens } from '../../mensagens/mensagens';
import { Router } from '@angular/router';

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
      selectEstabelecimento: [null]
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

  obterEstabelecimentos(): void {
    this.estabelecimentoService.obterTodos().subscribe(estabelecimentos => {
      this.estabelecimentos = estabelecimentos.data;

      if (estabelecimentos) {
        this.cardapioForm.get('selectEstabelecimento').setValue(this.estabelecimentos[0].id);
        this.estabelecimentoSelecionado = this.estabelecimentos[0];
      }
    });
  }

  selecionarEstabelecimento(): void {
    const estabelecimentoSelecionadoId = this.cardapioForm?.get('selectEstabelecimento')?.value;
    this.estabelecimentoSelecionado = this.estabelecimentos?.find(e => e.id == estabelecimentoSelecionadoId);
  }

  irParaEdicaoProduto(produtoId?: number): void {
    this.router.navigate(['cardapio/estabelecimentos/', this.estabelecimentoSelecionado?.id, 'produtos', produtoId]);
  }
}
