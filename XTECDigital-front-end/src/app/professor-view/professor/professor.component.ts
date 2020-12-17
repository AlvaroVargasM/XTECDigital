import { Component, OnInit } from '@angular/core';
import {Rubric} from '../../models/rubric.model';
import {ProfessorService} from '../professor.service';
import {Group} from '../../models/group.model';

@Component({
  selector: 'app-professor',
  templateUrl: './professor.component.html',
  styleUrls: ['./professor.component.css']
})
export class ProfessorComponent implements OnInit {
  availableGroups: Group[];
  selectedGroup: Group;

  constructor(private pService: ProfessorService) { }

  ngOnInit(): void {
    this.availableGroups = this.pService.groups;
    this.selectedGroup = this.pService.currentGroup;
  }

  onGroupSelect(g: Group): void {
    this.pService.currentGroup = g;
    this.ngOnInit();
  }
}
