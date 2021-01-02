import { Component, OnInit } from '@angular/core';
import {Student} from '../../../models/student.model';
import {ProfessorService} from '../../professor.service';

@Component({
  selector: 'app-team-management',
  templateUrl: './team-management.component.html',
  styleUrls: ['./team-management.component.css']
})
export class TeamManagementComponent implements OnInit {
  groupStudents: Student[];

  constructor(private pService: ProfessorService) { }

  ngOnInit(): void {
    this.groupStudents = this.pService.gStudents;
  }

}
