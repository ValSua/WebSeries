import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPeliculaComponent } from './edit-pelicula.component';

describe('EditPeliculaComponent', () => {
  let component: EditPeliculaComponent;
  let fixture: ComponentFixture<EditPeliculaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditPeliculaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditPeliculaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
