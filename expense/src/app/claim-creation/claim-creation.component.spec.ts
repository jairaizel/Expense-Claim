import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClaimCreationComponent } from './claim-creation.component';

describe('ClaimCreationComponent', () => {
  let component: ClaimCreationComponent;
  let fixture: ComponentFixture<ClaimCreationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClaimCreationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClaimCreationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
