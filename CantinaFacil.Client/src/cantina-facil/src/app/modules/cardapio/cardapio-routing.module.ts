import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CardapioComponent } from './pages/cardapio/cardapio.component';
import { CadastroEstabelecimentoComponent } from './pages/cadastro-estabelecimento/cadastro-estabelecimento.component';
import { CadastroProdutoComponent } from './pages/cadastro-produto/cadastro-produto.component';

const routes: Routes = [
  {
    path: '',
    component: CardapioComponent
  },
  {
    path: 'estabelecimentos',
    component: CadastroEstabelecimentoComponent
  },
  {
    path: 'estabelecimentos/:estabelecimentoId',
    component: CadastroEstabelecimentoComponent
  },
  {
    path: 'estabelecimentos/:estabelecimentoId/produtos',
    component: CadastroProdutoComponent
  },
  {
    path: 'estabelecimentos/:estabelecimentoId/produtos/:produtoId',
    component: CadastroProdutoComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CardapioRoutingModule { }
