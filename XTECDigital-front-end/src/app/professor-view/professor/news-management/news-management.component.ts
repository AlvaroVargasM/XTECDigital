import {Component, OnInit, ViewChild} from '@angular/core';
import {ProfessorService} from '../../professor.service';
import {News} from '../../../models/news.model';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-news-management',
  templateUrl: './news-management.component.html',
  styleUrls: ['./news-management.component.css']
})
export class NewsManagementComponent implements OnInit {
  @ViewChild('createNews') createNewsForm: NgForm;
  availableNews: News[];
  isEdit: boolean;

  constructor(private pService: ProfessorService) {
    this.isEdit = false;
  }

  ngOnInit(): void {
    this.availableNews = this.pService.news;
  }

  onCreateNews(): void {
    console.log(this.createNewsForm.value);

    /* COMS!
      En esta parte ocupamos mandar esta nueva noticia
      al back y asociarla con el curso que actualmente tengamos
      seleccionado
     */

    this.createNewsForm.reset();
    this.ngOnInit();
  }

  onDeleteNews(news: News): void {

    /* COMS!
      En esta parte le decimos al back cual noticia se elimina y volvemos
      a actualizar la lista de noticias del grupo
     */

    this.ngOnInit();
  }
}
