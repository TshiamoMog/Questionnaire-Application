import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpcomingFeatureComponent } from './upcoming-feature.component';

describe('UpcomingFeatureComponent', () => {
  let component: UpcomingFeatureComponent;
  let fixture: ComponentFixture<UpcomingFeatureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpcomingFeatureComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpcomingFeatureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
