import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDirectorComponent } from './edit-director.component';

describe('EditDirectorComponent', () => {
  let component: EditDirectorComponent;
  let fixture: ComponentFixture<EditDirectorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditDirectorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditDirectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
