import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { CadastreSeRoutingModule } from './cadastre-se-routing.module';
import { CadastreSeComponent } from './pages/cadastre-se.component';

@NgModule({
  declarations: [
    CadastreSeComponent
  ],
  imports: [
    SharedModule,
    CadastreSeRoutingModule
  ],
  providers: [

  ],
  exports: [

  ]
})
export class CadastreSeModule { }
