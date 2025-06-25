import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarVulnerabilidadesComponent } from './editar-vulnerabilidades.component';

describe('EditarVulnerabilidadesComponent', () => {
  let component: EditarVulnerabilidadesComponent;
  let fixture: ComponentFixture<EditarVulnerabilidadesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditarVulnerabilidadesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditarVulnerabilidadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
