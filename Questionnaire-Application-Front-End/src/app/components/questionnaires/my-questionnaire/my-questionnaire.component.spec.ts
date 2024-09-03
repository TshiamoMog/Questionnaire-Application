import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyQuestionnaireComponent } from './my-questionnaire.component';

describe('MyQuestionnaireComponent', () => {
  let component: MyQuestionnaireComponent;
  let fixture: ComponentFixture<MyQuestionnaireComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MyQuestionnaireComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MyQuestionnaireComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
