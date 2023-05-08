import { ModuleWithProviders, NgModule } from '@angular/core';
import { PerfilService } from './perfil.service';
import { UsuarioService } from './usuario.service';

@NgModule({})
export class SharedServicesModule {
  static forRoot(): ModuleWithProviders<SharedServicesModule> {
    return {
      ngModule: SharedServicesModule,
      providers: [
        PerfilService,
        UsuarioService
      ]
    };
  }
}
