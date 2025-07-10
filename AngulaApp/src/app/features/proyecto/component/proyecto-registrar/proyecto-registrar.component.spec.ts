import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProyectoRegistrarComponent } from './proyecto-registrar.component';

describe('ProyectoRegistrarComponent', () => {
  let component: ProyectoRegistrarComponent;
  let fixture: ComponentFixture<ProyectoRegistrarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProyectoRegistrarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProyectoRegistrarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
