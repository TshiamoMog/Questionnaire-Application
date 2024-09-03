import { Component, Input } from '@angular/core';
import { Questionnaire } from '../../../models/questionnaire/questionnaire.model';

@Component({
  selector: 'app-my-questionnaire',
  templateUrl: './my-questionnaire.component.html',
  styleUrl: './my-questionnaire.component.css'
})
export class MyQuestionnaireComponent {
  @Input() questionnaire?: Questionnaire;

  constructor() {}

  ngOnInit() : void {}

  UpdateQuestionnaire(questionnaire: Questionnaire){}

  DeleteQuestionnaire(questionnaire: Questionnaire){}
}
