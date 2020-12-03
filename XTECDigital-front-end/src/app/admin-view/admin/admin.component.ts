import { Component, OnInit } from '@angular/core';
import {AdminService} from '../admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  /*
    This var is called whenever the 'Inicializar Semestre' button is called, it should make
    the start-semester.component appear and the course-management.component disappear
   */
  isStartSemester: boolean;

  constructor(private aService: AdminService) {
    this.isStartSemester = false;
  }

  ngOnInit(): void {
  }

  onStartSemester(): void {
    this.isStartSemester = true;
  }
}
