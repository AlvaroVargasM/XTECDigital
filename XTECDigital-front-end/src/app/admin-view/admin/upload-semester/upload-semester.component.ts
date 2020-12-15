import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-upload-semester',
  templateUrl: './upload-semester.component.html',
  styleUrls: ['./upload-semester.component.css']
})
export class UploadSemesterComponent implements OnInit {
  semesterFile = null;

  constructor() { }

  ngOnInit(): void {
  }

  onSelectSemesterFile(event): void {
    this.semesterFile = event.target.files[0];
  }

  onUploadSemesterFile(): void {}
}
