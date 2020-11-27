import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AdminComponent } from './admin/admin/admin.component';
import { ProfessorComponent } from './professor/professor/professor.component';
import { StudentComponent } from './student/student/student.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    ProfessorComponent,
    StudentComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
