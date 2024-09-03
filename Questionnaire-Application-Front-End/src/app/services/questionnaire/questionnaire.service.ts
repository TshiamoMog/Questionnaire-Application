import { Injectable } from '@angular/core';
import { Questionnaire } from '../../models/questionnaire/questionnaire.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.development';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class QuestionnaireService {
  private url = "Questionnaire"

  constructor(private http: HttpClient) { }

  public getQuestionnaires() : Observable<Questionnaire[]> {
    return this.http.get<Questionnaire[]>(`${environment.apiUrl}/${this.url}`);
  }

  public getQuestionnaireById() : Observable<Questionnaire[]> {
    return this.http.get<Questionnaire[]>(`${environment.apiUrl}/${this.url}/id`);
  }
}
