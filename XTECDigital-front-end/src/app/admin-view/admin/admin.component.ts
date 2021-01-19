import { Component, OnInit } from '@angular/core';
import {AdminService} from '../admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})

/**
 * This component is in charge of displaying the admin view
 */
export class AdminComponent implements OnInit {

  constructor(private aService: AdminService) {
  }

  ngOnInit(): void {
  }
}
