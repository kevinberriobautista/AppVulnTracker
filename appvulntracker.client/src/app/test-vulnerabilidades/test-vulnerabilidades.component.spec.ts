import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestVulnerabilidadesComponent } from './test-vulnerabilidades.component';

describe('TestVulnerabilidadesComponent', () => {
  let component: TestVulnerabilidadesComponent;
  let fixture: ComponentFixture<TestVulnerabilidadesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TestVulnerabilidadesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TestVulnerabilidadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
