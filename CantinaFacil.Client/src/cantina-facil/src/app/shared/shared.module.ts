import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// Material
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';

// PrimeNg
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { AccordionModule } from 'primeng/accordion';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { BadgeModule } from 'primeng/badge';
import { TabViewModule } from 'primeng/tabview';
import { DividerModule } from 'primeng/divider';
import { DialogModule } from 'primeng/dialog';
import { FileUploadModule } from 'primeng/fileupload';
import { TooltipModule } from 'primeng/tooltip';
import { ProgressBarModule } from 'primeng/progressbar';

// ngx-bec
import {
  AcceleratorCheckboxModule,
  AcceleratorDatepickerModule,
  AcceleratorDatetimePickerModule,
  AcceleratorInputModule,
  AcceleratorRadioButtonModule,
  AcceleratorSelectModule,
  AcceleratorTableModule,
  AcceleratorTextareaModule,
  AcceleratorSplitButtonModule,
  AcceleratorInputMaskModule,
  AcceleratorAnexarArquivosModule,
  AcceleratorBotaoConfirmarModule,
  AcceleratorBotaoFecharModule,
  AcceleratorBotaoPesquisarModule,
  AcceleratorBotaoGravarModule,
  AcceleratorTituloConteudoModule,
  AcceleratorIconeLabelModule,
  AcceleratorPipesModule,
  AcceleratorDirectivesModule,
  AcceleratorOpcoesUsuarioModule
} from '@npdjunior/ngx-accelerator-tools'
import { MenubarModule } from 'primeng/menubar';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,

    // Material
    MatIconModule,
    MatSidenavModule,
    MatButtonModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatCardModule,
    MatDividerModule,
    MatListModule,

    // Primeng
    MenubarModule,
    OverlayPanelModule,
    AccordionModule,
    BreadcrumbModule,
    BadgeModule,
    TabViewModule,
    DialogModule,
    DividerModule,
    FileUploadModule,
    TooltipModule,
    ProgressBarModule,

    // ngx-bec
    AcceleratorOpcoesUsuarioModule,
    AcceleratorCheckboxModule,
    AcceleratorDatepickerModule,
    AcceleratorDatetimePickerModule,
    AcceleratorInputModule,
    AcceleratorRadioButtonModule,
    AcceleratorSelectModule,
    AcceleratorTableModule,
    AcceleratorTextareaModule,
    AcceleratorSplitButtonModule,
    AcceleratorInputMaskModule,
    AcceleratorAnexarArquivosModule,
    AcceleratorBotaoConfirmarModule,
    AcceleratorBotaoFecharModule,
    AcceleratorBotaoPesquisarModule,
    AcceleratorBotaoGravarModule,
    AcceleratorTituloConteudoModule,
    AcceleratorIconeLabelModule,
    AcceleratorPipesModule,
    AcceleratorDirectivesModule
  ],
  exports: [
    //Module
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,

    // Material
    MatIconModule,
    MatSidenavModule,
    MatButtonModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatCardModule,
    MatDividerModule,
    MatListModule,

    // Primeng
    MenubarModule,
    OverlayPanelModule,
    AccordionModule,
    BreadcrumbModule,
    BadgeModule,
    TabViewModule,
    DialogModule,
    DividerModule,
    FileUploadModule,
    TooltipModule,
    ProgressBarModule,

    // ngx-bec
    AcceleratorOpcoesUsuarioModule,
    AcceleratorCheckboxModule,
    AcceleratorDatepickerModule,
    AcceleratorDatetimePickerModule,
    AcceleratorInputModule,
    AcceleratorRadioButtonModule,
    AcceleratorSelectModule,
    AcceleratorTableModule,
    AcceleratorTextareaModule,
    AcceleratorSplitButtonModule,
    AcceleratorInputMaskModule,
    AcceleratorAnexarArquivosModule,
    AcceleratorBotaoConfirmarModule,
    AcceleratorBotaoFecharModule,
    AcceleratorBotaoPesquisarModule,
    AcceleratorBotaoGravarModule,
    AcceleratorTituloConteudoModule,
    AcceleratorIconeLabelModule,
    AcceleratorPipesModule,
    AcceleratorDirectivesModule,
  ],
  providers: []
})
export class SharedModule { }
