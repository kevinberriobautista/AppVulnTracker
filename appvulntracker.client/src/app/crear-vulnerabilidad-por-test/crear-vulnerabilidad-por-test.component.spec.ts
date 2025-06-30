import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrearVulnerabilidadPorTestComponent } from './crear-vulnerabilidad-por-test.component';

describe('CrearVulnerabilidadPorTestComponent', () => {
  let component: CrearVulnerabilidadPorTestComponent;
  let fixture: ComponentFixture<CrearVulnerabilidadPorTestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrearVulnerabilidadPorTestComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CrearVulnerabilidadPorTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
