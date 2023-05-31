import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { CardapioComponent } from './pages/cardapio/cardapio.component';
import { CardapioRoutingModule } from './cardapio-routing.module';
import { EstabelecimentoService } from './services/estabelecimento.service';
import { CadastroEstabelecimentoComponent } from './pages/cadastro-estabelecimento/cadastro-estabelecimento.component';
import { CadastroProdutoComponent } from './pages/cadastro-produto/cadastro-produto.component';

@NgModule({
  declarations: [
    CardapioComponent,
    CadastroEstabelecimentoComponent,
    CadastroProdutoComponent
  ],
  imports: [
    SharedModule,
    CardapioRoutingModule
  ],
  providers: [
    EstabelecimentoService
  ],
  exports: [

  ]
})
export class CardapioModule { }
