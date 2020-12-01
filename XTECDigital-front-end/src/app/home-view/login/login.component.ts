import {Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {CommunicationService} from '../../communication.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

/**
 * This class is in charge of holding the login form
 */
export class LoginComponent implements OnInit {
  @ViewChild('login') loginForm: NgForm;

  constructor(private comService: CommunicationService, private router: Router) { }

  ngOnInit(): void {
  }

  onLogin(): void {
    console.log(this.loginForm.value.username);
    /*
      Aca quiero que se llame a una funcion que valide con el api el input, y nos de una respuesta para saber
      si estuvo mal el input del cliente, o si estuvo bien para donde tengo que mover la ruta actual
     */

  }
}
