import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicalstaffRequestsComponent } from './medicalstaff-requests.component';

describe('MedicalstaffRequestsComponent', () => {
  let component: MedicalstaffRequestsComponent;
  let fixture: ComponentFixture<MedicalstaffRequestsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MedicalstaffRequestsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MedicalstaffRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
