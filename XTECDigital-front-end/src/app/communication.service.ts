import { Injectable } from '@angular/core';
import {HttpClient, HttpEvent} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommunicationService {

  private mongoApi = 'https://xtecdigitalapi20201217234131.azurewebsites.net/api/'

  constructor(private http: HttpClient) { }

  downloadFile(file: string): any{
    return this.http.get(file, {responseType: 'blob'});
  }

  login(id,password){
    let params = {
      "id": id,
      "password": password
    }
    this.http.post(this.mongoApi + 'Student/LogIn' , params).subscribe(res=>console.log(res))
  }
}
