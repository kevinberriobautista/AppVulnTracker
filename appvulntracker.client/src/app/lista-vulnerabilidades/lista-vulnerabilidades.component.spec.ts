import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaVulnerabilidadesComponent } from './lista-vulnerabilidades.component';

describe('ListaVulnerabilidadesComponent', () => {
  let component: ListaVulnerabilidadesComponent;
  let fixture: ComponentFixture<ListaVulnerabilidadesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListaVulnerabilidadesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListaVulnerabilidadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
