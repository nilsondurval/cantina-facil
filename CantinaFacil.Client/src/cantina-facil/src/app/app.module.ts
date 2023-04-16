import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AcceleratorAuthGuard, AcceleratorConfirmationModule, AcceleratorCookieBannerModule, AcceleratorInterceptorsModule, AcceleratorLayoutModule, AcceleratorRootStoreModule, AcceleratorServicesModule, AcceleratorToastModule, NgxAcceleratorModule } from '@npdjunior/ngx-accelerator-tools';
import { BlockUIModule } from 'ng-block-ui';
import { environment } from 'src/environments/environment';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomPaginator } from './shared/custom/custom-paginator-configuration';
import { SharedModule } from './shared/shared.module';
import { MenuComponent } from './shared/components/menu/menu.component';
import { RodapeComponent } from './shared/components/rodape/rodape.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    RodapeComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,

    SharedModule,

    BlockUIModule.forRoot({
      delayStart: 0,
      delayStop: 800
    }),

    NgxAcceleratorModule.forRoot(environment),
    AcceleratorInterceptorsModule.forRoot(),
    AcceleratorRootStoreModule,

    AcceleratorServicesModule,
    AcceleratorToastModule,
    AcceleratorConfirmationModule,
    AcceleratorLayoutModule,
    AcceleratorCookieBannerModule,
  ],
  providers: [
    {
      provide: MatPaginatorIntl,
      useValue: CustomPaginator()
    },
    AcceleratorAuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
