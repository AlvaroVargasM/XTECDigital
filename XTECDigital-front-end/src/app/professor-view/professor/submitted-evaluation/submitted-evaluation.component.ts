import { Component, OnInit } from '@angular/core';
import {CommunicationService} from '../../../communication.service';
import * as fileSaver from 'file-saver';

@Component({
  selector: 'app-submitted-evaluation',
  templateUrl: './submitted-evaluation.component.html',
  styleUrls: ['./submitted-evaluation.component.css']
})
export class SubmittedEvaluationComponent implements OnInit {

  constructor(private comService: CommunicationService) { }

  ngOnInit(): void {
  }

  download() {
    this.comService.downloadFile('').subscribe(
      response => {
        let blob:any = new Blob([response], { type: 'text/json; charset=utf-8' });
        const url = window.URL.createObjectURL(blob);
        fileSaver.saveAs(blob, 'test.json');
      }), error => console.log('Error downloading the file'),
      () => console.info('File downloaded successfully');
  }
}
