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
    /* COMS!
      Aca se deberia llamar api y enviar el input del login, y nos de una respuesta para saber
      si estuvo mal el input del cliente, o si estuvo bien saber para donde tengo que mover la ruta actual
      ademas si es estudiante o professor se deberia guardar la informacion de quien esta en session actualmente
     */

  }
}
