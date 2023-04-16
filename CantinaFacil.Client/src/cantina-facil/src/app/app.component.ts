import { Component } from '@angular/core';
import { AcceleratorAppConfigService, AcceleratorAuthService } from '@npdjunior/ngx-accelerator-tools';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(
    private appConfigService: AcceleratorAppConfigService,
    private authService: AcceleratorAuthService
  ) { }

  ngOnInit() {
    this.configurar();
  }

  configurar(): void {
    this.appConfigService.init();
    this.authService.init();
  }
}
