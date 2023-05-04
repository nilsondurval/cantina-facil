import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastreSeComponent } from './pages/cadastre-se.component';

const routes: Routes = [
  {
    path: '',
    component: CadastreSeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CadastreSeRoutingModule { }
