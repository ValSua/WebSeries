import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditGeneroComponent } from './edit-genero.component';

describe('EditGeneroComponent', () => {
  let component: EditGeneroComponent;
  let fixture: ComponentFixture<EditGeneroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditGeneroComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditGeneroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
