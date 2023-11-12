import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmbededMsgFieldComponent } from './embeded-msg-field.component';

describe('EmbededMsgFieldComponent', () => {
  let component: EmbededMsgFieldComponent;
  let fixture: ComponentFixture<EmbededMsgFieldComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmbededMsgFieldComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EmbededMsgFieldComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
