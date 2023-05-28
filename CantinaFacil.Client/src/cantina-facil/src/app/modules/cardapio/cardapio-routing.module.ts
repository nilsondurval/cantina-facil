import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CardapioComponent } from './pages/cardapio/cardapio.component';
import { CadastroEstabelecimentoComponent } from './pages/cadastro-estabelecimento/cadastro-estabelecimento.component';

const routes: Routes = [
  {
    path: '',
    component: CardapioComponent
  },
  {
    path: 'cadastro-estabelecimento',
    component: CadastroEstabelecimentoComponent
  },
  {
    path: 'cadastro-estabelecimento/:estabelecimentoId',
    component: CadastroEstabelecimentoComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CardapioRoutingModule { }
