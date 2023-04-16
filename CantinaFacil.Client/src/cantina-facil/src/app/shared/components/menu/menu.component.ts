import { Component, OnInit } from '@angular/core';
import { AcceleratorAppConfigService, AcceleratorAuthService } from '@npdjunior/ngx-accelerator-tools';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'cantina-facil-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  items: MenuItem[] = [];

  constructor(
    private appCofigService: AcceleratorAppConfigService,
    private authService: AcceleratorAuthService
  ) { }

  ngOnInit() {
    this.obterMenu();
  }

  obterMenu(): void {
    this.appCofigService.menu.subscribe(res => {
      this.items = res;
    });
  }

  get bemVindo(): string {
    const token = this.authService.getDecodedToken();
    return `Seja bem vindo ${token?.nome?.toString().split(' ')[0] || ''}.`;
  }

  logout(): void {
    this.authService.doLogout();
  }
}
