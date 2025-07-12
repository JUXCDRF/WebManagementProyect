import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TareaRegisterComponent } from './tarea-register.component';

describe('TareaRegisterComponent', () => {
  let component: TareaRegisterComponent;
  let fixture: ComponentFixture<TareaRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TareaRegisterComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TareaRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
