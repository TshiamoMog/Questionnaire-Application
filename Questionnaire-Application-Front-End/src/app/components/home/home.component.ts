import { Component } from '@angular/core';
import { Questionnaire } from '../../models/questionnaire/questionnaire.model';
import { QuestionnaireService } from '../../services/questionnaire/questionnaire.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  questionnaires: Questionnaire[] = [];

  constructor(private questionnaireService: QuestionnaireService) {}

  ngOnInit() : void {
    this.questionnaireService.getQuestionnaires().subscribe((result: Questionnaire[]) => (this.questionnaires = result));
  }
}
