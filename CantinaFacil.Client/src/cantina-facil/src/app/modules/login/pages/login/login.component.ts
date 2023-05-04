import { AfterViewInit, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AcceleratorAuthService, AcceleratorHideMasterPageService } from '@npdjunior/ngx-accelerator-tools';
import { Mensagens } from '../../mensagens/mensagens';

@Component({
  selector: 'cantina-facil-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, AfterViewInit {

  loginForm: any;

  mensagens = Mensagens

  constructor(
    private authService: AcceleratorAuthService,
    private hideMasterPageService: AcceleratorHideMasterPageService,
    private router: Router,
    private fb: FormBuilder,
    private changeDetectorRef: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.iniciarlizarFormulario();
  }

  ngAfterViewInit(): void {
    this.changeDetectorRef.detectChanges();
  }

  iniciarlizarFormulario(): void {
    this.loginForm = this.fb.group({
      inputEmail: [null],
      inputSenha: [null]
    });
  }

  logar(): void {
    if (this.loginForm.invalid)
      return;

    var email = this.loginForm.get('inputEmail').value;
    var senha = this.loginForm.get('inputSenha').value;
    
    this.authService.autenticar(email, senha).subscribe(token => {
      if (token && token.data) {
        this.authService.saveToken(token.data);
        this.router.navigate(['']);
        this.hideMasterPageService.show();
      }
    });
  }

  irParaCadastro(event: any): void {
    this.router.navigate(['cadastre-se']);
  }
}
