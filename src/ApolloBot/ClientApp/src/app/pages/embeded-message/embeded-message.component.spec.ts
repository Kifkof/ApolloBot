import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmbededMessageComponent } from './embeded-message.component';

describe('EmbededMessageComponent', () => {
  let component: EmbededMessageComponent;
  let fixture: ComponentFixture<EmbededMessageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmbededMessageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EmbededMessageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
