import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateDirectorComponent } from './create-director.component';

describe('CreateDirectorComponent', () => {
  let component: CreateDirectorComponent;
  let fixture: ComponentFixture<CreateDirectorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateDirectorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateDirectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
