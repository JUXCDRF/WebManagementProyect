import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProyectoTareaComponent } from './proyecto-tarea.component';

describe('ProyectoTareaComponent', () => {
  let component: ProyectoTareaComponent;
  let fixture: ComponentFixture<ProyectoTareaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProyectoTareaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProyectoTareaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
