import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NaoAutenticadoComponent, NaoAutorizadoComponent, NaoEncontradoComponent } from '@npdjunior/ngx-accelerator-tools';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'login',
    loadChildren: () => import('./modules/login/login.module').then(m => m.LoginModule),
  },
  {
    path: 'nao-autorizado',
    component: NaoAutorizadoComponent,
    data: {
      breadcrumb: [
        {
          label: 'Não Autorizado'
        }
      ]
    },
  },
  {
    path: 'nao-autenticado',
    component: NaoAutenticadoComponent,
    data: {
      breadcrumb: [
        {
          label: 'Não Autenticado'
        }
      ]
    },
  },
  {
    path: 'nao-encontrado',
    component: NaoEncontradoComponent,
    data: {
      breadcrumb: [
        {
          label: 'Não Encontrado'
        }
      ]
    },
  },
  {
    path: '**',
    redirectTo: 'nao-encontrado'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
