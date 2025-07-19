import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProyectoTareaDetallesComponent } from './proyecto-tarea-detalles.component';

describe('ProyectoTareaDetallesComponent', () => {
  let component: ProyectoTareaDetallesComponent;
  let fixture: ComponentFixture<ProyectoTareaDetallesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProyectoTareaDetallesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProyectoTareaDetallesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
