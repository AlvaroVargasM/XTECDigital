import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-upload-semester',
  templateUrl: './upload-semester.component.html',
  styleUrls: ['./upload-semester.component.css']
})
export class UploadSemesterComponent implements OnInit {
  semesterFile: File = null;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  onSelectSemesterFile(event): void {
    console.log(event);
    this.semesterFile = <File>event.target.files[0];
  }

  onUploadSemesterFile(): void {
    const fd = new FormData();
    fd.append('semesterExcel', this.semesterFile, this.semesterFile.name)
    this.http.post('', fd).subscribe(
      res => {
        console.log(res);
      }
    );
  }
}
