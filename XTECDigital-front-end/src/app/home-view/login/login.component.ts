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
    this.comService.login(this.loginForm.value.username,this.loginForm.value.password);
  }
}
