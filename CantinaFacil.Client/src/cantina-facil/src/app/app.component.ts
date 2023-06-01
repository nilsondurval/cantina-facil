import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { AcceleratorAppConfigService, AcceleratorAuthService } from '@npdjunior/ngx-accelerator-tools';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(
    private appConfigService: AcceleratorAppConfigService,
    private authService: AcceleratorAuthService,
    private location: Location
  ) { }

  ngOnInit() {
    this.configurar();
  }

  configurar(): void {
    this.appConfigService.init();
    this.authService.init(this.location.path());
  }
}
